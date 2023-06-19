using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemistry_app.View
{
    internal class TheoryPage
    {
        public int WordSize { get; set; }
        public List<string> BoldWords { get; set; }
        public string Content { get; set; }
        public List<string> BoldCombinations { get; set; }  // Добавленное поле
        public Dictionary<string, int> WordSizes { get; set; }  // Добавленное поле
    }
}
