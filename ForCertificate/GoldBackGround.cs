using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemistry_app
{
    internal class GoldBackGround : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            // Установка золотого цвета фона страницы
            PdfContentByte canvas = writer.DirectContentUnder;
            canvas.SetColorFill(new BaseColor(255, 215, 0)); // Золотой цвет (Gold)
            canvas.Rectangle(document.Left, document.Bottom, document.PageSize.Width, document.PageSize.Height);
            canvas.Fill();
        }
    }
}
