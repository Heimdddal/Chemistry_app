using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemistry_app
{
    internal class BronzeBackGround : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            // Установка бронзового цвета фона страницы
            PdfContentByte canvas = writer.DirectContentUnder;
            canvas.SetColorFill(new BaseColor(255, 174, 136)); // Бронзовый цвет
            canvas.Rectangle(document.Left, document.Bottom, document.PageSize.Width, document.PageSize.Height);
            canvas.Fill();
        }
    }
}
