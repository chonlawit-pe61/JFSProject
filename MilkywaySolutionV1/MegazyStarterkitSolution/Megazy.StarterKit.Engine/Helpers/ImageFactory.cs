
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
namespace Megazy.StarterKit.Engine.Helpers
{
    public class ImageFactory
    {
        public enum ImageType
        {
            Undefined,
            MemoryBMP,
            bmp,
            emf,
            wmf,
            jpg,
            png,
            gif,
            tiff,
            exif,
            icon
        }

        /// <summary>
        /// Base64ToImage รูปต้องเป็นไฟล์ .jpg,.png,gif เท่านั้น
        /// </summary>
        /// <param name="base64String">encodebase64</param>
        /// <returns>Image</returns>
        public Image Base64ToImage(string base64String)
        {
            // if the file extension is unknown
            var extension = "";
            // do something like this
            var lowerCase = base64String.ToLower();
            if (lowerCase.IndexOf("data:image/png") != -1)
                extension = "png";
            else if (lowerCase.IndexOf("data:image/gif") != -1)
                extension = "gif";
            else if (lowerCase.IndexOf("data:image/jpg") != -1)
                extension = "jpg";
            else //lowerCase.IndexOf("data:image/jpeg") != -1) 
                extension = "jpeg";
            //data:image/jpeg;base64,
            base64String = base64String.Replace("data:image/" + extension + ";base64,", "");
            byte[] imageBytes = Convert.FromBase64String(base64String);

            //MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            //ms.Write(imageBytes, 0, imageBytes.Length);
            //Image image = Image.FromStream(ms, true);
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);
                ms.Flush();
                return image;
            }
        }

        public Image ResizeAsthumbImage(Image originImage, int squareSize)
        {

            Image source = originImage;

            int newWidth = 0;
            int newHeight = 0;
            int newX = 0;
            int newY = 0;

            if (originImage.Width > squareSize || originImage.Height > squareSize) //if there are any side of image greater than [canvasSquareSize]
            {

                int reduceSizePercentage = 0;
                int sizeToCalPercentage = 0;
                string largestSizeSide = string.Empty;
                if (originImage.Height > originImage.Width)
                {
                    sizeToCalPercentage = originImage.Height;
                }
                else if (originImage.Width > originImage.Height)
                {
                    sizeToCalPercentage = originImage.Width;
                }
                else // if both sides are equal.
                {
                    sizeToCalPercentage = originImage.Width;
                }

                reduceSizePercentage = 100 - ((squareSize * 100) / sizeToCalPercentage);
                newWidth = originImage.Width - ((originImage.Width * reduceSizePercentage) / 100);
                newHeight = originImage.Height - ((originImage.Height * reduceSizePercentage) / 100);

                if (newWidth > newHeight)
                {
                    newX = 0;
                    newY = (squareSize - newHeight) / 2;
                }
                else if (newHeight > newWidth)
                {
                    newX = (squareSize - newWidth) / 2;
                    newY = 0;
                }
            }
            else // case image smaller than canvas size
            {
                newWidth = originImage.Width;
                newHeight = originImage.Height;
                newX = (squareSize - originImage.Width) / 2;
                newY = (squareSize - originImage.Height) / 2;
            }

            Bitmap bitmap = new Bitmap(squareSize, squareSize);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.Black);
                //set the resize quality modes to high quality
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                //draw the image into the target bitmap
                graphics.DrawImage(source, newX, newY, newWidth, newHeight);
                //bitmap.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                source = bitmap;
                graphics.Dispose();
                //}
                //source.Dispose();
            }
            return source;
        }
        public Image ResizingImageAsImage(Image imgSource, string imageSizeType)
        {
            int maxWidth = 0;
            int maxHeight = 0;
            switch (imageSizeType)
            {
                case "cover":
                    maxWidth = 1125;
                    maxHeight = 750;
                    break;
                case "thumb":
                    maxWidth = 300;
                    maxHeight = 200;
                    break;
                case "sharefb":
                    maxWidth = 600;
                    maxHeight = 315;
                    break;
            }

            int newWidth = 0;
            int newHeight = 0;

            Image source = imgSource;

            if (source.Width > maxWidth || source.Height > maxHeight)
            {
                if (source.Width > source.Height)
                {
                    newWidth = maxWidth;
                    newHeight = (source.Height * maxWidth) / source.Width;
                    if (newHeight > maxHeight)
                    {
                        newHeight = maxHeight;
                        newWidth = (source.Width * maxHeight) / source.Height;
                    }
                }
                else if (source.Height > source.Width)
                {
                    newWidth = (source.Width * maxHeight) / source.Height;
                    newHeight = maxHeight;
                    if (newWidth > maxWidth)
                    {
                        newWidth = maxWidth;
                        newHeight = (source.Height * maxWidth) / source.Width;
                    }
                }
                else
                {
                    if (maxWidth > maxHeight)
                    {
                        newWidth = maxHeight;
                        newHeight = maxHeight;
                    }
                    else
                    {
                        newWidth = maxWidth;
                        newHeight = maxWidth;
                    }
                }
            }
            else
            {
                newWidth = source.Width;
                newHeight = source.Height;
            }

            Bitmap bitmap = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                //set the resize quality modes to high quality
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                //draw the image into the target bitmap
                graphics.DrawImage(source, 0, 0, newWidth, newHeight);
                //bitmap.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                source = bitmap;
                graphics.Dispose();
                //}
                //source.Dispose();
            }
            return source;
        }
        public Image ResizingImage(Image imgSource, string imageSizeType,int maxWidth=0, int maxHeight=0)
        {
            //int maxWidth = 0;
            //int maxHeight = 0;
            switch (imageSizeType)
            {
                case "cover":
                case "main":
                    if (maxWidth ==0)
                        maxWidth = 1125;
                    if(maxHeight ==0)
                        maxHeight = 750;
                    break;
                case "search":
                case "thumb":
                    if (maxWidth == 0)
                        maxWidth = 300;
                    if (maxHeight == 0)
                        maxHeight = 200;
                    break;
                case "sharefb":
                    maxWidth = 600;
                    maxHeight = 315;
                    break;
            }

            int newWidth = 0;
            int newHeight = 0;

            Image source = imgSource;

            if (source.Width > maxWidth || source.Height > maxHeight)
            {
                if (source.Width > source.Height)
                {
                    newWidth = maxWidth;
                    newHeight = (source.Height * maxWidth) / source.Width;
                    if (newHeight > maxHeight)
                    {
                        newHeight = maxHeight;
                        newWidth = (source.Width * maxHeight) / source.Height;
                    }
                }
                else if (source.Height > source.Width)
                {
                    newWidth = (source.Width * maxHeight) / source.Height;
                    newHeight = maxHeight;
                    if (newWidth > maxWidth)
                    {
                        newWidth = maxWidth;
                        newHeight = (source.Height * maxWidth) / source.Width;
                    }
                }
                else
                {
                    if (maxWidth > maxHeight)
                    {
                        newWidth = maxHeight;
                        newHeight = maxHeight;
                    }
                    else
                    {
                        newWidth = maxWidth;
                        newHeight = maxWidth;
                    }
                }
            }
            else
            {
                newWidth = source.Width;
                newHeight = source.Height;
            }

            Bitmap bitmap = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                //set the resize quality modes to high quality
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                //draw the image into the target bitmap
                graphics.DrawImage(source, 0, 0, newWidth, newHeight);
                //bitmap.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                source = bitmap;
                graphics.Dispose();
                //}
                //source.Dispose();
            }
            return source;
        }
        public byte[] ResizingImageAsByte(Image imgSource, string imageSizeType)
        {
            int maxWidth = 0;
            int maxHeight = 0;
            switch (imageSizeType)
            {
                case "cover":
                    maxWidth = 1000;
                    maxHeight = 1000;
                    break;
                case "thumb":
                    maxWidth = 120;
                    maxHeight = 120;
                    break;
            }

            int newWidth = 0;
            int newHeight = 0;

            Image source = imgSource;

            if (source.Width > maxWidth || source.Height > maxHeight)
            {
                if (source.Width > source.Height)
                {
                    newWidth = maxWidth;
                    newHeight = (source.Height * maxWidth) / source.Width;
                    if (newHeight > maxHeight)
                    {
                        newHeight = maxHeight;
                        newWidth = (source.Width * maxHeight) / source.Height;
                    }
                }
                else if (source.Height > source.Width)
                {
                    newWidth = (source.Width * maxHeight) / source.Height;
                    newHeight = maxHeight;
                    if (newWidth > maxWidth)
                    {
                        newWidth = maxWidth;
                        newHeight = (source.Height * maxWidth) / source.Width;
                    }
                }
                else
                {
                    if (maxWidth > maxHeight)
                    {
                        newWidth = maxHeight;
                        newHeight = maxHeight;
                    }
                    else
                    {
                        newWidth = maxWidth;
                        newHeight = maxWidth;
                    }
                }
            }
            else
            {
                newWidth = source.Width;
                newHeight = source.Height;
            }

            Bitmap bitmap = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                //set the resize quality modes to high quality
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                //draw the image into the target bitmap
                graphics.DrawImage(source, 0, 0, newWidth, newHeight);
                //bitmap.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                source = bitmap;
                graphics.Dispose();
                //}
                //source.Dispose();
                return ImageHelper.GetBitmapBytes(bitmap);
            }
            //  return source;
        }

        public ImagesCollection SaveProfileFromBase64(string saveImagePath,string imageName, string base64Image)
        {
            ImagesCollection images = new ImagesCollection();
            Image image = Base64ToImage(base64Image);
            Image imageResized = image;
            imageResized = ResizingImageAsImage(image, "cover");

            var fileType = "png";
            ImageFormat ImageFormat = ImageFormat.Jpeg;
            ImageCodecInfo ImageCodecInfo = null;
            if (ImageFormat.Jpeg.Equals(image.RawFormat))
            {
                // JPEG
                fileType = ImageType.png.ToString();
                ImageFormat = ImageFormat.Png;
            }
            else if (ImageFormat.Png.Equals(image.RawFormat))
            {
                // PNG
                fileType = ImageType.png.ToString();
                ImageFormat = ImageFormat.Png;
            }
            else if (ImageFormat.Gif.Equals(image.RawFormat))
            {
                // GIF
                fileType = ImageType.png.ToString();
                ImageFormat = ImageFormat.Png;
            }
            ImageCodecInfo = GetEncoder(ImageFormat);
            var pp = image.PropertyItems;
            string imgName = string.Format("{0}.{1}",imageName, fileType);
            string filename = Path.Combine(saveImagePath, imgName);// @"\\" + dict.Value + imgName;

            try
            {

                FileHelper.SaveFile(imageResized, filename, ImageCodecInfo);
            }
            catch (Exception)
            {
                //Log an error     
                //return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }

            images.CoverImage = imgName;



            return images;
        }
        public ImagesCollection SaveImageFromBase64(string saveImagePath, string imageName, string base64Image)
        {
            ImagesCollection images = new ImagesCollection();
            //string saveImagePath = ConfigurationManager.AppSettings["ImageSchool"];
            //Dictionary<string, string> dictSaveImageInfo = new Dictionary<string, string>()
            //    {
            //        {"cover", saveImagePath },
            //        {"thumb", string.Format(saveImagePath + "Thumbnail" + @"\") },
            //    };

            Image image = Base64ToImage(base64Image);
            Image imageResized = image;
            imageResized = ResizingImageAsImage(image, "cover");
            ////        break;
            ////    case "thumb":
            ////        imageResized = ResizingImageAsImage(image, dict.Key);//ResizeAsthumbImage2(image, 120);
            ////        break;
            ////}

            var fileType = "jpg";
            ImageFormat ImageFormat = ImageFormat.Jpeg;
            ImageCodecInfo ImageCodecInfo = null;
            if (ImageFormat.Jpeg.Equals(image.RawFormat))
            {
                // JPEG
                fileType = ImageType.jpg.ToString();
                ImageFormat = ImageFormat.Jpeg;
            }
            else if (ImageFormat.Png.Equals(image.RawFormat))
            {
                // PNG
                fileType = ImageType.png.ToString();
                ImageFormat = ImageFormat.Png;
            }
            else if (ImageFormat.Gif.Equals(image.RawFormat))
            {
                // GIF
                fileType = ImageType.gif.ToString();
                ImageFormat = ImageFormat.Gif;
            }
            ImageCodecInfo = GetEncoder(ImageFormat);
            var pp = image.PropertyItems;
            string imgName = string.Format("{0}.{1}", imageName, fileType);
            string filename = Path.Combine(saveImagePath, imgName);// @"\\" + dict.Value + imgName;

            try
            {

                FileHelper.SaveFile(imageResized, filename, ImageCodecInfo);
                //FileHelper.SaveFile(imageResized, filename);//return byte[]
            }
            catch (Exception)
            {
                //Log an error     
                //return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }

            images.CoverImage = imgName;



            return images;
        }
        /// <summary>
        /// สำหรับบันทึกรูปหลักของสินค้า
        /// </summary>
        /// <param name="productNo"></param>
        /// <param name="base64Image"></param>
        /// <returns>CoverImage</returns>
        public ImagesCollection SaveProductCoverImageFromBase64(string productNo, string base64Image,string savepath)
        {
            ImagesCollection images = new ImagesCollection();
            string saveImagePath = savepath;
            Dictionary<string, string> dictSaveImageInfo = new Dictionary<string, string>()
                {
                    {"cover", saveImagePath },
                    {"thumb", string.Format(saveImagePath + "Thumbnail" + @"\") },
                };

            Image image = Base64ToImage(base64Image);
            var fileType = "jpg";
            ImageFormat ImageFormat = ImageFormat.Jpeg;
            ImageCodecInfo ImageCodecInfo = null;
            if (ImageFormat.Jpeg.Equals(image.RawFormat))
            {
                // JPEG
                fileType = ImageType.jpg.ToString();
                ImageFormat = ImageFormat.Jpeg;
            }
            else if (ImageFormat.Png.Equals(image.RawFormat))
            {
                // PNG
                fileType = ImageType.png.ToString();
                ImageFormat = ImageFormat.Png;
            }
            else if (ImageFormat.Gif.Equals(image.RawFormat))
            {
                // GIF
                fileType = ImageType.gif.ToString();
                ImageFormat = ImageFormat.Gif;
            }

            var pp = image.PropertyItems;// Util.GetExtraEpoch().ToString()
            string imgName = string.Format("{0}.{1}", productNo, fileType);

            foreach (KeyValuePair<string, string> dict in dictSaveImageInfo)
            {
                Image imageResized = image;
                //byte[] imageResized = null;
                switch (dict.Key)
                {
                    case "cover":
                        imageResized = ResizingImageAsImage(image, dict.Key);
                        break;
                    case "thumb":
                        imageResized = ResizingImageAsImage(image, dict.Key);//ResizeAsthumbImage2(image, 120);
                        break;
                }

                string filename = Path.Combine(dict.Value, imgName);
                ImageCodecInfo = GetEncoder(ImageFormat);
                try
                {

                    FileHelper.SaveFile(imageResized, filename, ImageCodecInfo);
                    //FileHelper.SaveFile(imageResized, filename);//return byte[]
                }
                catch (Exception)
                {
                    //Log an error     
                    //return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
                }
                if (!dict.Value.Contains("Thumbnail"))
                {
                    images.CoverImage = imgName;
                }
                else
                {
                    images.ThumbImage = imgName;
                }
            }

            return images;
        }
        public ImagesCollection SaveImageFromBase64(string id, string base64Image, ImageSize comverSize, ImageSize thumbnail, string saveImagePath)
        {
            ImagesCollection images = new ImagesCollection();
            //if (saveImagePath == "")
            //    saveImagePath = ConfigurationManager.AppSettings["Images"];
            Dictionary<string, string> dictSaveImageInfo = new Dictionary<string, string>()
                {
                    {"cover", saveImagePath },
                    {"thumb", string.Format(saveImagePath + "Thumbnail" + @"\") },
                };

            Image image = Base64ToImage(base64Image);
            var fileType = "jpg";
            ImageFormat ImageFormat = ImageFormat.Jpeg;
            ImageCodecInfo ImageCodecInfo = null;
            if (ImageFormat.Jpeg.Equals(image.RawFormat))
            {
                // JPEG
                fileType = ImageType.jpg.ToString();
                ImageFormat = ImageFormat.Jpeg;
            }
            else if (ImageFormat.Png.Equals(image.RawFormat))
            {
                // PNG
                fileType = ImageType.png.ToString();
                ImageFormat = ImageFormat.Png;
            }
            else if (ImageFormat.Gif.Equals(image.RawFormat))
            {
                // GIF
                fileType = ImageType.gif.ToString();
                ImageFormat = ImageFormat.Gif;
            }

            var pp = image.PropertyItems;// Util.GetExtraEpoch().ToString()
            string imgName = string.Format("{0}.{1}", id, fileType);

            foreach (KeyValuePair<string, string> dict in dictSaveImageInfo)
            {
                Image imageResized = image;
                switch (dict.Key)
                {
                    case "cover":
                        imageResized = ResizingImage(image, dict.Key, comverSize.Width, comverSize.Height);
                        break;
                    case "thumb":
                        imageResized = ResizingImage(image, dict.Key, thumbnail.Width, thumbnail.Height);
                        break;
                }

                string filename = Path.Combine(dict.Value, imgName);
                ImageCodecInfo = GetEncoder(ImageFormat);
                try
                {

                    FileHelper.SaveFile(imageResized, filename, ImageCodecInfo);
                }
                catch (Exception)
                {
                }
                if (!dict.Value.Contains("Thumbnail"))
                {
                    images.CoverImage = imgName;
                }
                else
                {
                    images.ThumbImage = imgName;
                }
            }

            return images;
        }

        public ImagesCollection SaveProductImageFromBase64(string productNo, string base64Image,string saveImagePath)
        {
            ImagesCollection images = new ImagesCollection();
           // string saveImagePath = ConfigurationManager.AppSettings["ImageProduct"];
            Dictionary<string, string> dictSaveImageInfo = new Dictionary<string, string>()
                {
                    {"cover", saveImagePath },
                    {"thumb", string.Format(saveImagePath + "Thumbnail" + @"\") },
                };

            Image image = Base64ToImage(base64Image);
            var fileType = "jpg";
            ImageFormat ImageFormat = ImageFormat.Jpeg;
            ImageCodecInfo ImageCodecInfo = null;
            if (ImageFormat.Jpeg.Equals(image.RawFormat))
            {
                // JPEG
                fileType = ImageType.jpg.ToString();
                ImageFormat = ImageFormat.Jpeg;
            }
            else if (ImageFormat.Png.Equals(image.RawFormat))
            {
                // PNG
                fileType = ImageType.png.ToString();
                ImageFormat = ImageFormat.Png;
            }
            else if (ImageFormat.Gif.Equals(image.RawFormat))
            {
                // GIF
                fileType = ImageType.gif.ToString();
                ImageFormat = ImageFormat.Gif;
            }

            var pp = image.PropertyItems;// Util.GetExtraEpoch().ToString()
            string imgName = string.Format("{0}{1}.{2}", productNo, Utility.GetExtraEpoch().ToString(), fileType);

            foreach (KeyValuePair<string, string> dict in dictSaveImageInfo)
            {
                Image imageResized = image;
                //byte[] imageResized = null;
                switch (dict.Key)
                {
                    case "cover":
                        imageResized = ResizingImageAsImage(image, dict.Key);
                        break;
                    case "thumb":
                        imageResized = ResizingImageAsImage(image, dict.Key);//ResizeAsthumbImage2(image, 120);
                        break;
                }

                string filename = Path.Combine(dict.Value, imgName);
                ImageCodecInfo = GetEncoder(ImageFormat);
                try
                {

                    FileHelper.SaveFile(imageResized, filename, ImageCodecInfo);
                    //FileHelper.SaveFile(imageResized, filename);//return byte[]
                }
                catch (Exception)
                {
                    //Log an error     
                    //return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
                }
                if (!dict.Value.Contains("Thumbnail"))
                {
                    images.CoverImage = imgName;
                }
                else
                {
                    images.ThumbImage = imgName;
                }
            }

            return images;
        }
        public ImagesCollection SaveImageGallery(string base64Image, string saveImagePath)
        {
            ImagesCollection images = new ImagesCollection();
            Dictionary<string, string> dictSaveImageInfo = new Dictionary<string, string>()
                {
                    {"cover", saveImagePath },
                    {"thumb", string.Format(saveImagePath + "Thumbnail" + @"\") },
                };

            Image image = Base64ToImage(base64Image);
            var fileType = "jpg";
            ImageFormat ImageFormat = ImageFormat.Jpeg;
            ImageCodecInfo ImageCodecInfo = null;
            if (ImageFormat.Jpeg.Equals(image.RawFormat))
            {
                // JPEG
                fileType = ImageType.jpg.ToString();
                ImageFormat = ImageFormat.Jpeg;
            }
            else if (ImageFormat.Png.Equals(image.RawFormat))
            {
                // PNG
                fileType = ImageType.png.ToString();
                ImageFormat = ImageFormat.Png;
            }
            else if (ImageFormat.Gif.Equals(image.RawFormat))
            {
                // GIF
                fileType = ImageType.gif.ToString();
                ImageFormat = ImageFormat.Gif;
            }

            var pp = image.PropertyItems;// Util.GetExtraEpoch().ToString()
            string imgName = string.Format("{0}.{1}", Utility.GetExtraEpoch().ToString(), fileType);

            foreach (KeyValuePair<string, string> dict in dictSaveImageInfo)
            {
                Image imageResized = image;
                //byte[] imageResized = null;
                switch (dict.Key)
                {
                    case "cover":
                        imageResized = ResizingImageAsImage(image, dict.Key);
                        break;
                    case "thumb":
                        imageResized = ResizingImageAsImage(image, dict.Key);//ResizeAsthumbImage2(image, 120);
                        break;
                }

                string filename = Path.Combine(dict.Value, imgName);
                ImageCodecInfo = GetEncoder(ImageFormat);
                try
                {

                    FileHelper.SaveFile(imageResized, filename, ImageCodecInfo);
                }
                catch (Exception)
                {
                }
                if (!dict.Value.Contains("Thumbnail"))
                {
                    images.CoverImage = imgName;
                }
                else
                {
                    images.ThumbImage = imgName;
                }
            }

            return images;
        }

        public ImagesCollection SaveBannerImageFromBase64(string base64Image,string savepath)
        {
            ImagesCollection images = new ImagesCollection();
            string saveImagePath = savepath;// ConfigurationManager.AppSettings["Banner"];
            Dictionary<string, string> dictSaveImageInfo = new Dictionary<string, string>()
                {
                    {"cover", saveImagePath },
                    {"thumb", string.Format(saveImagePath + "Thumbnail" + @"\") },
                };

            Image image = Base64ToImage(base64Image);
            var fileType = "jpg";
            ImageFormat ImageFormat = ImageFormat.Jpeg;
            ImageCodecInfo ImageCodecInfo = null;
            if (ImageFormat.Jpeg.Equals(image.RawFormat))
            {
                // JPEG
                fileType = ImageType.jpg.ToString();
                ImageFormat = ImageFormat.Jpeg;
            }
            else if (ImageFormat.Png.Equals(image.RawFormat))
            {
                // PNG
                fileType = ImageType.png.ToString();
                ImageFormat = ImageFormat.Png;
            }
            else if (ImageFormat.Gif.Equals(image.RawFormat))
            {
                // GIF
                fileType = ImageType.gif.ToString();
                ImageFormat = ImageFormat.Gif;
            }

            var pp = image.PropertyItems;// Util.GetExtraEpoch().ToString()
            string imgName = string.Format("{0}.{1}", Utility.GetExtraEpoch().ToString(), fileType);

            foreach (KeyValuePair<string, string> dict in dictSaveImageInfo)
            {
                Image imageResized = image;
                //byte[] imageResized = null;
                switch (dict.Key)
                {
                    case "cover":
                        imageResized = ResizingImage(image, dict.Key,1920,850);
                        break;
                    case "thumb":
                        imageResized = ResizingImage(image, dict.Key,200,200);//ResizeAsthumbImage2(image, 120);
                        break;
                }

                string filename = Path.Combine(dict.Value, imgName);
                ImageCodecInfo = GetEncoder(ImageFormat);
                try
                {

                    FileHelper.SaveFile(imageResized, filename, ImageCodecInfo);
                    //FileHelper.SaveFile(imageResized, filename);//return byte[]
                }
                catch (Exception)
                {
                    //Log an error     
                    //return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
                }
                if (!dict.Value.Contains("Thumbnail"))
                {
                    images.CoverImage = imgName;
                }
                else
                {
                    images.ThumbImage = imgName;
                }
            }

            return images;
        }

        public ImagesCollection SaveResultQuizImageFromBase64(string saveImagePath, string imageName, string base64Image)
        {
            ImagesCollection images = new ImagesCollection();
            //string saveImagePath = ConfigurationManager.AppSettings["ImageSchool"];
            //Dictionary<string, string> dictSaveImageInfo = new Dictionary<string, string>()
            //    {
            //        {"cover", saveImagePath },
            //        {"thumb", string.Format(saveImagePath + "Thumbnail" + @"\") },
            //    };

            Image image = Base64ToImage(base64Image);
            Image imageResized = image;
            imageResized = ResizingImageAsImage(image, "sharefb");
            //        break;
            //    case "thumb":
            //        imageResized = ResizingImageAsImage(image, dict.Key);//ResizeAsthumbImage2(image, 120);
            //        break;
            //}

            var fileType = "jpg";
            ImageFormat ImageFormat = ImageFormat.Jpeg;
            ImageCodecInfo ImageCodecInfo = null;
            if (ImageFormat.Jpeg.Equals(image.RawFormat))
            {
                // JPEG
                fileType = ImageType.jpg.ToString();
                ImageFormat = ImageFormat.Jpeg;
            }
            else if (ImageFormat.Png.Equals(image.RawFormat))
            {
                // PNG
                fileType = ImageType.png.ToString();
                ImageFormat = ImageFormat.Png;
            }
            else if (ImageFormat.Gif.Equals(image.RawFormat))
            {
                // GIF
                fileType = ImageType.gif.ToString();
                ImageFormat = ImageFormat.Gif;
            }
            ImageCodecInfo = GetEncoder(ImageFormat);
            var pp = image.PropertyItems;
            string imgName = string.Format("{0}.{1}", imageName, fileType);
            string filename = Path.Combine(saveImagePath, imgName);// @"\\" + dict.Value + imgName;

            try
            {

                FileHelper.SaveFile(imageResized, filename, ImageCodecInfo);
                //FileHelper.SaveFile(imageResized, filename);//return byte[]
            }
            catch (Exception)
            {
                //Log an error     
                //return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }

            images.CoverImage = imgName;



            return images;
        }

        public ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    } //End of class ImageFactory
    public class ImagesCollection
    {
        public string CoverImage { get; set; }
        public string ThumbImage { get; set; }
        public string CoverImageUrl { get; set; }
        public string ThumbImageUrl { get; set; }
        public int CoverImageWidth { get; set; }
        public int CoverImageHeight { get; set; }
    }
    public class ImageInfo
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }

    }
    public class ImageSize {
        public int Width { get; set; }
        public int Height { get; set; }
    }

}