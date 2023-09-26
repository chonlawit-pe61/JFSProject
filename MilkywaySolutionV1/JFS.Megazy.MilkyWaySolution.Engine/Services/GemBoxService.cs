using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using GemBox.Document;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;


namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class GemBoxService
    {
        public bool addimg(int caseid , int applicationid , string formpath)
        {
            // If using Professional version, put your serial key below.
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            var document = new DocumentModel();

            var section = new Section(document);
            document.Sections.Add(section);

            var paragraph = new Paragraph(document);
            section.Blocks.Add(paragraph);

            View_CaseAttachFileCollection_Base atimg = new View_CaseAttachFileCollection_Base(CSystems.ProcessID);
            var imgarray = atimg.GetTopAsArray(2, new List<SqlParameter>(), $"[CaseID] = {caseid} AND [ApplicantID] = {applicationid} AND [FileType] IN ('.JPG','.PNG')", "[ModifiedDate]");
            atimg.Dispose();
            if (imgarray.Length > 0)
            {
                foreach (var img in imgarray)
                {
                    string img64 = "";
                    img64 = HttpContext.Current.Server.MapPath($"/filesupload/case/{caseid}/{applicationid}/{img.FileName}");

                    // Create and add a floating picture with PNG image.
                    Picture picture = new Picture(document, img64, 600, 450, LengthUnit.Pixel);
                    FloatingLayout layout = new FloatingLayout(
                        new HorizontalPosition(HorizontalPositionType.Center, HorizontalPositionAnchor.Page),
                        new VerticalPosition(2, LengthUnit.Inch, VerticalPositionAnchor.Page),
                        picture.Layout.Size);
                    layout.WrappingStyle = TextWrappingStyle.InFrontOfText;

                    picture.Layout = layout;
                    paragraph.Inlines.Add(picture);
                }
            }
            document.Save(formpath);
            return true;
        }

        public void addimgtoword(string formpath , string img)
        {
            // If using Professional version, put your serial key below.
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            var document = new DocumentModel();

            var paragraph = new Paragraph(document);

            // Create and add a floating picture with PNG image.
            Picture picture = new Picture(document, img, 400, 300, LengthUnit.Pixel);
            FloatingLayout layout = new FloatingLayout(
                new HorizontalPosition(HorizontalPositionType.Center, HorizontalPositionAnchor.Page),
                new VerticalPosition(2, LengthUnit.Inch, VerticalPositionAnchor.Page),
                picture.Layout.Size);
            layout.WrappingStyle = TextWrappingStyle.InFrontOfText;

            picture.Layout = layout;
            paragraph.Inlines.Add(picture);
            //return true;
        }


        public void img(string formpath, string img)
        {
            // If using Professional version, put your serial key below.
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            var document = DocumentModel.Load("MergePictures.docx");

            // Using picture's path, stream and byte array as a data source.
            var dataSource = new
            {
                Img1 = "Penguins.png",
                Img2 = File.OpenRead("Penguins.png"),
                Img3 = File.ReadAllBytes("Penguins.png"),
            };

            document.MailMerge.Execute(dataSource);

            document.Save("Merge Pictures.docx");
        }


    }
}
