using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Nodus.Elluris.Domain.Util
{
    public static class FuncoesComuns
    {
        public static string ReduzirImagem(string imagem)
        {
            var imagemNew = imagem;

            var Tipo = imagem.Split(',')[0].Split(':')[1].Split(';')[0];
            string t = Uri.UnescapeDataString(imagem);
            var data = $"data:{Tipo};base64,";
            t = t.Replace($"data:{Tipo};base64,", "");
            byte[] imageBytes = Convert.FromBase64String(t);
            if (imageBytes.Length > (200000))
            {
                var porcent = 90;
                while (imageBytes.Length > (200000) && porcent >= 85)
                    using (MemoryStream mem = new MemoryStream(imageBytes))
                    {
                        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
                        ImageCodecInfo jgpEncoder = codecs[1];

                        Image imgImage = Image.FromStream(mem);
                        //var bmp = new Bitmap(imgImage, new Size(180, 200));
                        var bmp1 = new Bitmap(mem);

                        var myEncoderParameter = new EncoderParameter(Encoder.Quality, porcent);
                        var param = new EncoderParameters(1);
                        param.Param[0] = myEncoderParameter;

                        var msSave = new MemoryStream();
                        bmp1.Save(msSave, jgpEncoder, param);

                        //Image imgImage = Image.FromStream(msSave);

                        imageBytes = msSave.ToArray();
                        imagemNew = data + Convert.ToBase64String(imageBytes);
                        porcent = porcent - 5;
                    }

            }
            return imagemNew;
        }
    }
}
