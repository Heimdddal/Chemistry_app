using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chemistry_app.Models
{
    public class Element
    {
        public string Symbol { get; set; }

        public int AtomicNumber { get; set; }

        public double AtomicWeight { get; set; }

        public Element(string symbol, int atomicNumber, double atomicWeight)
        {
            this.Symbol = symbol;
            AtomicNumber = atomicNumber;
            AtomicWeight = atomicWeight;
        }

        public override string ToString()
        {
            return Symbol + AtomicNumber + AtomicWeight;
        }

    }
}
