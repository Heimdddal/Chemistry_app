using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemistry_app
{
    internal class SilverBackGround : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            // Установка серебряного цвета фона страницы
            PdfContentByte canvas = writer.DirectContentUnder;
            canvas.SetColorFill(new BaseColor(204, 204, 204)); // Серебряный цвет (Silver)
            canvas.Rectangle(document.Left, document.Bottom, document.PageSize.Width, document.PageSize.Height);
            canvas.Fill();
        }
    }
}
