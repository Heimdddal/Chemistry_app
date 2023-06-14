using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chemistry_app.ViewModel
{
    internal class TestResults
    {
        private Grid grid;
        private string results;

        public TestResults(ref Grid grid, string results)
        {
            this.grid = grid;
            this.grid.Children.Clear();
            this.results = results;

            Label Results = new Label() 
            {
                Content = results,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            };

            this.grid.Children.Add(Results);



        }
    }
}
