using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Dominios.Interfaces;
using Entidades;
using Managers.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using Modelos;

namespace Managers {
	public class cManagerUsuarios: IManagerUsuarios {
		private IDominioUsuarios iDominio;
		private JwtConfigModelo iJwtCfg;

		public cManagerUsuarios(
			IDominioUsuarios pDominio
			, JwtConfigModelo pJwtCfg) {

			iDominio = pDominio;
			iJwtCfg = pJwtCfg;
		}

		public async Task<UsuariosModelo> LoginUsuario(
			string pUsuario
			, string pContrasenia) {

			tUsuarios lUsuario = await iDominio.LoginUsuario(pUsuario, pContrasenia);
			return new UsuariosModelo() {
				IDUsuario = lUsuario.IDUsuario
				, Usuario = lUsuario.Usuario
				, Contrasenia = lUsuario.Contrasenia
				, Salt = lUsuario.Salt
				, Token = GenerateToken(lUsuario)
				, EstaActivo = lUsuario.EstaActivo
			};
		}

		public async Task<tUsuarios> GuardarUsuario(
			int pIDUsuario
			, string pUsuario
			, string pContrasenia
			, bool pEstaActivo) {

			IDictionary<string, string> lDatos = EncryptPassword(pContrasenia);
			return await iDominio.GuardarUsuario(
				pIDUsuario
				, pUsuario
				, lDatos["Hash"]
				, lDatos["Salt"]
				, pEstaActivo
			);
		}

		public async Task EliminarUsuario(int pIDUsuario) {
			await iDominio.EliminarUsuario(pIDUsuario);
		}

		private IDictionary<string, string> EncryptPassword(string pPassword) {
			byte[] lSalt = new byte[128 / 8];
			using(var lRng = RandomNumberGenerator.Create()) {
				lRng.GetBytes(lSalt);
			}

			string lEncryptedPassw = Convert.ToBase64String(
				KeyDerivation.Pbkdf2(
					password: pPassword
					, salt: lSalt
					, prf: KeyDerivationPrf.HMACSHA1
					, iterationCount: 10000
					, numBytesRequested: 256 / 8
				)
			);

			return new Dictionary<string, string>() {
				{ "Hash", lEncryptedPassw }
				, { "Salt", Convert.ToBase64String(lSalt) }
			};
		}

		private string GenerateToken(tUsuarios pUsuario) {
			var lClaimsIdentity = new ClaimsIdentity(new[] {
				new Claim(ClaimTypes.NameIdentifier, pUsuario.IDUsuario.ToString())
				, new Claim(ClaimTypes.Email, pUsuario.Usuario)
			});

			var lKey = Convert.FromBase64String(iJwtCfg.SecretKey);
			var lSigningCredentials = new SigningCredentials(
				new SymmetricSecurityKey(lKey)
				, SecurityAlgorithms.HmacSha256Signature
			);

			var lTokenDescriptor = new SecurityTokenDescriptor {
				Subject = lClaimsIdentity
				, Issuer = iJwtCfg.Issuer
				, Audience = iJwtCfg.Audience
				, Expires = DateTime.UtcNow.AddMinutes(60)
				, SigningCredentials = lSigningCredentials
			};

			var lTokenHandler = new JwtSecurityTokenHandler();
			var lToken = lTokenHandler.CreateToken(lTokenDescriptor);

			return lTokenHandler.WriteToken(lToken);
		}
	}
}
