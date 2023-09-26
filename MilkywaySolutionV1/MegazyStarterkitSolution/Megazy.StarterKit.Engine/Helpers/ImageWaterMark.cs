using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using Megazy.StarterKit.Engine.Dal;

namespace Megazy.StarterKit.Engine.Helpers
{
  public  class ImageWaterMark
    {
        public void WaterMark(string pathfile, string pathfilezip)
        {
            string imageWaterMark =  CSystems.ImagePath + @"\tooktee-logo.png";
            //using (Image image = Image.FromFile(@"D:\2K19Zone\GuildAreaSolution\Area.Megazy.GuildSolution.WebMvc\images\property\2018-9.jpg"))
            using (Image image = Image.FromFile(@""+ pathfilezip + ""))
            using (Image watermarkImage = Image.FromFile(imageWaterMark))
            using (Graphics imageGraphics = Graphics.FromImage(image))
            {
                RectangleF newRectangleF = new RectangleF(0.0f, 0.0f, watermarkImage.Width, watermarkImage.Height);
                using (ImageAttributes IA = new ImageAttributes())
                {
                    ColorMatrix CM = new ColorMatrix();
                    CM.Matrix33 = 0.4F;// Opacity;
                    IA.SetColorMatrix(CM);
                    using (TextureBrush watermarkBrush = new TextureBrush(watermarkImage, newRectangleF, IA))
                    {
                        int x = (image.Width / 2 - watermarkImage.Width / 2);
                        int y = (image.Height / 2 - watermarkImage.Height / 2);
                        watermarkBrush.TranslateTransform(x, y);
                        imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new Point(x, y), new Size(watermarkImage.Width + 1, watermarkImage.Height)));
                        string pathImgwatermark = CSystems.FilePath + @"watermark\" + pathfile;
                        image.Save(pathImgwatermark);
                    }
                }
            }            
            //using (Graphics G = Graphics.FromImage(image))
            //{
            //    using (ImageAttributes IA = new ImageAttributes())
            //    {
            //        ColorMatrix CM = new ColorMatrix();
            //        CM.Matrix33 = 0.5F;// Opacity;
            //        IA.SetColorMatrix(CM);
            //        G.DrawImage(Watermark, new Rectangle(WatermarkPosition, Watermark.Size), 0, 0, Watermark.Width, Watermark.Height, GraphicsUnit.Pixel, IA);
            //    }
            //}
        }
    }
}
