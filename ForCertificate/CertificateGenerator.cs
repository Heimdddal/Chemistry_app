using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Xml.Linq;

namespace Chemistry_app
{
    internal class CertificateGenerator
    {
        public static void GenerateCertificate(string userName, string nameOfTest, string ID, float percentResult)
        {
            string pathToImage = "";
            string pathToSign = "";
            string kindOfCertificate = "";

            StringBuilder date = new StringBuilder();

            date.Append(DateTime.Now.Date);
            date.Length -= 8;

            Document certificate = new Document();

            certificate.SetMargins(0, 0, 0, 0);


            PdfWriter writer = PdfWriter.GetInstance(certificate, new FileStream("certificate.pdf", FileMode.Create));
            checkResults(ref writer, percentResult, ref pathToImage, ref pathToSign, ref kindOfCertificate);

            writer.SetEncryption(PdfWriter.STANDARD_ENCRYPTION_128, null, null, PdfWriter.AllowPrinting);
            writer.ViewerPreferences = PdfWriter.PageLayoutOneColumn | PdfWriter.PageModeUseNone;

            certificate.Open();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string fontPath = "C:/Windows/Fonts/comic.ttf"; // путь к файлу шрифта
            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font titleFont = new Font(baseFont, 32, Font.BOLD, BaseColor.BLACK);
            Font subtitleFont = new Font(baseFont, 26, Font.BOLD, BaseColor.BLACK);
            Font textFont = new Font(baseFont, 26, Font.NORMAL, BaseColor.BLACK);
            Font idFont = new Font(baseFont, 12, Font.NORMAL, BaseColor.BLACK);


            Paragraph title = new Paragraph($"{kindOfCertificate} сертефикат", titleFont);
            title.Alignment = Element.ALIGN_CENTER;

            Paragraph subtitle = new Paragraph($"За успешное прохождение теста {nameOfTest}", subtitleFont);
            subtitle.Alignment = Element.ALIGN_CENTER;

            Paragraph congrats = new Paragraph($"Поздравляем студента {userName}" +
                $"\nс успешной сдачей теста!", textFont);
            congrats.Alignment = Element.ALIGN_CENTER;

            Paragraph result = new Paragraph($"\nРезультат: {percentResult}%", textFont);
            result.Alignment = Element.ALIGN_CENTER;

            Paragraph dateText = new Paragraph($"Дата: {date}", textFont);
            dateText.Alignment = Element.ALIGN_CENTER;

            Paragraph uniqueID = new Paragraph($"ID: {ID}", idFont);

            var image = Image.GetInstance(pathToSign);
            var medalImage = Image.GetInstance(pathToImage);

            medalImage.Alignment = Element.ALIGN_CENTER;
            uniqueID.Alignment = Element.ALIGN_CENTER;


            image.Alignment = Element.ALIGN_CENTER;

            certificate.Add(title);
            certificate.Add(subtitle);
            certificate.Add(medalImage);
            certificate.Add(congrats);
            certificate.Add(result);
            certificate.Add(dateText);
            certificate.Add(image);
            certificate.Add(uniqueID);




            certificate.Close();
            writer.Close();
        }

        private static void checkResults(ref PdfWriter writer, in float percentResult, ref string pathToMedalImage,
            ref string pathToSignImage, ref string kindOfCerticicate)
        {
            if (percentResult == 100)
            {
                pathToMedalImage = "goldMedal.png";
                pathToSignImage = "podpisGold.png";
                kindOfCerticicate = "\nЗолотой";
                writer.PageEvent = new GoldBackGround();
            }

            else if (percentResult < 90)
            {
                pathToMedalImage = "bronzeMedal.png";
                pathToSignImage = "podpisBronze.png";
                kindOfCerticicate = "\nБронзовый";
                writer.PageEvent = new BronzeBackGround();
            }

            else
            {
                pathToMedalImage = "silverMedal.png";
                pathToSignImage = "podpisSilver.png";
                kindOfCerticicate = "\nСеребряный";
                writer.PageEvent = new SilverBackGround();
            }
        }

    }


}
