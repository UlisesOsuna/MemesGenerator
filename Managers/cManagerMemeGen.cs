using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Managers.Interfaces;
using Modelos;

namespace Managers {
	public class cManagerMemeGen: IManagerMemeGen {
		public MemeModelo GenerarMeme(
			string pBase64
			, string pTextoOnTop
			, string pTextoOnBottom) {

			if(!string.IsNullOrEmpty(pBase64)) {
				Image lBitmap = Base64ToImage(pBase64);
				Graphics lGraphicsImg = Graphics.FromImage(lBitmap);

				bool lFlagTxtTop = !string.IsNullOrEmpty(pTextoOnTop);
				bool lFlagTxtBottom = !string.IsNullOrEmpty(pTextoOnBottom);

				if(lFlagTxtTop || lFlagTxtBottom) {
					if(lFlagTxtTop) {
						StringFormat lStrFormatTop = new StringFormat();
						lStrFormatTop.Alignment = StringAlignment.Center;
						lStrFormatTop.LineAlignment = StringAlignment.Center;
						Color StringColor = Color.White;

						lGraphicsImg.DrawString(
							pTextoOnTop
							, new Font("Tahoma", 30, FontStyle.Bold)
							, new SolidBrush(StringColor)
							, new Point((lBitmap.Width / 2), 20)
							, lStrFormatTop
						);
					}

					if(lFlagTxtBottom) {
						StringFormat lStrFormatBottom = new StringFormat();
						lStrFormatBottom.Alignment = StringAlignment.Center;
						lStrFormatBottom.LineAlignment = StringAlignment.Center;
						Color StringColor = Color.White;

						lGraphicsImg.DrawString(
							pTextoOnBottom
							, new Font("Tahoma", 30, FontStyle.Bold)
							, new SolidBrush(StringColor)
							, new Point((lBitmap.Width / 2), lBitmap.Height - 17)
							, lStrFormatBottom
						);
					}

					return new MemeModelo() {
						Base64 = ImageToBase64(lBitmap, ImageFormat.Jpeg)
					};
				}
				else {
					throw new ArgumentException("Debes Propocionar un Texto para Generar el Meme...");
				}
			}
			else {
				throw new ArgumentException("Debes Propocionar la Imagen para Generar el Meme...");
			}
		}

		private Image Base64ToImage(string pBase64) {
			byte[] lImgBytes = Convert.FromBase64String(pBase64);

			using(var lMemStream = new MemoryStream(lImgBytes, 0, lImgBytes.Length)) {
				return Image.FromStream(lMemStream, true);
			}
		}

		private string ImageToBase64(
			Image pImage
			, ImageFormat pFormat) {

			using(MemoryStream lMemStream = new MemoryStream()) {
				pImage.Save(lMemStream, pFormat);
				byte[] lImgBytes = lMemStream.ToArray();

				return Convert.ToBase64String(lImgBytes);
			}
		}
	}
}
