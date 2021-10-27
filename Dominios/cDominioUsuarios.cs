using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominios.Interfaces;
using Entidades;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Repositorios.Interfaces;

namespace Dominios {
	public class cDominioUsuarios: IDominioUsuarios {
		private IRepositorioUsuarios iRepositorio;

		public cDominioUsuarios(IRepositorioUsuarios pRepositorio) {
			iRepositorio = pRepositorio;
		}

		public async Task<tUsuarios> LoginUsuario(
			string pUsuario
			, string pContrasenia) {

			tUsuarios lUsuario = null;
			if(EsUsuarioValido(pUsuario)) {
				lUsuario = await iRepositorio.FindAsync(x =>
					x.Usuario == pUsuario
					&& x.EstaActivo
				);

				bool lEsUsuarioValido = VerifyPassword(
					pContrasenia
					, lUsuario.Contrasenia
					, lUsuario.Salt
				);

				if(!lEsUsuarioValido)
					throw new ArgumentException("Usuario No Existe o es Invalido...");
			}
			else {
				throw new ArgumentException("Nombre de Usuario No Valido...");
			}

			return lUsuario;
		}

		public async Task<tUsuarios> GuardarUsuario(
			int pIDUsuario
			, string pUsuario
			, string pContrasenia
			, string pSalt
			, bool pEstaActivo) {

			if(EsUsuarioValido(pUsuario)) {
				tUsuarios lUsuario = null;
				
				bool lFlagUsuario = !string.IsNullOrEmpty(pUsuario);
				bool lFlagContrasenia = !string.IsNullOrEmpty(pContrasenia);
				bool lFlagSalt = !string.IsNullOrEmpty(pSalt);

				if(lFlagUsuario && lFlagContrasenia && lFlagSalt) {
					lUsuario = new tUsuarios() {
						Usuario = pUsuario
						, Contrasenia = pContrasenia
						, Salt = pSalt
						, EstaActivo = pEstaActivo
					};

					if(pIDUsuario > 0)
						lUsuario = await ActualizarUsuario(pIDUsuario, lUsuario);
					else
						lUsuario = await InsertarUsuario(lUsuario);
				}

				return lUsuario;
			}
			else {
				throw new ArgumentException("Nombre de Usuario No Valido...");
			}
		}

		public async Task EliminarUsuario(int pIDUsuario){
			await iRepositorio.DeleteAsync<int>(pIDUsuario, true);
		}

		private async Task<tUsuarios> InsertarUsuario(tUsuarios pUsuario) {
			return await iRepositorio.InsertAsync(pUsuario, true);
		}

		private async Task<tUsuarios> ActualizarUsuario(
			int pIDUsuario
			, tUsuarios pUsuario) {

			pUsuario.IDUsuario = pIDUsuario;
			return await iRepositorio.UpdateAsync<int>(pUsuario, pIDUsuario, true);
		}

		private bool EsUsuarioValido(string pUsuario) {
			bool lReturn = false;
			bool lFlagUsuario = !string.IsNullOrEmpty(pUsuario);

			if(lFlagUsuario) {
				bool lIsEmail = Regex.IsMatch(pUsuario, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);

				if(lIsEmail)
					lReturn = true;
			}

			return lReturn;
		}

		private bool VerifyPassword(
			string pInputPassword
			, string pStoredPassword
			, string pSalt) {

			byte[] lSalt = Convert.FromBase64String(pSalt);
			string lEncryptedPassw = Convert.ToBase64String(
				KeyDerivation.Pbkdf2(
					password: pInputPassword
					, salt: lSalt
					, prf: KeyDerivationPrf.HMACSHA1
					, iterationCount: 10000
					, numBytesRequested: 256 / 8
				)
			);

			return lEncryptedPassw == pStoredPassword;
		}
	}
}

