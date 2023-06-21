using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chemistry_app.Models;

namespace Chemistry_app
{
    /// <summary>
    /// Логика взаимодействия для MendeleevTablePage.xaml
    /// </summary>
    public partial class MendeleevTablePage : Page
    {
        public ObservableCollection<Models.Element> Elements { get; set; }
        public MendeleevTablePage()
        {
            InitializeComponent();
            DataContext = this;
            Elements = new ObservableCollection<Models.Element>();

            Elements.Add(new Models.Element("H", 1, 1.00794));
            Elements.Add(new Models.Element("He", 2, 4.00260));
            Elements.Add(new Models.Element("Li", 3, 6.94100));
            Elements.Add(new Models.Element("Be", 4, 9.01218));
            Elements.Add(new Models.Element("B", 5, 10.81100));
            Elements.Add(new Models.Element("C", 6, 12.01070));
            Elements.Add(new Models.Element("N", 7, 14.00670));
            Elements.Add(new Models.Element("O", 8, 15.99940));
            Elements.Add(new Models.Element("F", 9, 18.99840));
            Elements.Add(new Models.Element("Ne", 10, 20.17970));
            Elements.Add(new Models.Element("Na", 11, 22.98976));
            Elements.Add(new Models.Element("Mg", 12, 24.30500));
            Elements.Add(new Models.Element("Al", 13, 26.98153));
            Elements.Add(new Models.Element("Si", 14, 28.08550));
            Elements.Add(new Models.Element("P", 15, 30.97696));
            Elements.Add(new Models.Element("S", 16, 32.06500));
            Elements.Add(new Models.Element("Cl", 17, 35.45300));
            Elements.Add(new Models.Element("Ar", 18, 39.94800));
            Elements.Add(new Models.Element("K", 19, 39.09830));
            Elements.Add(new Models.Element("Ca", 20, 40.07800));
            Elements.Add(new Models.Element("Sc", 21, 44.95591));
            Elements.Add(new Models.Element("Ti", 22, 47.86700));
            Elements.Add(new Models.Element("V", 23, 50.94150));
            Elements.Add(new Models.Element("Cr", 24, 51.99620));
            Elements.Add(new Models.Element("Mn", 25, 54.93804));
            Elements.Add(new Models.Element("Fe", 26, 55.84500));
            Elements.Add(new Models.Element("Co", 27, 58.93319));
            Elements.Add(new Models.Element("Ni", 28, 58.69340));
            Elements.Add(new Models.Element("Сu", 29, 63.54600));
            Elements.Add(new Models.Element("Zn", 30, 65.38000));
            Elements.Add(new Models.Element("Ga", 31, 69.72300));
            Elements.Add(new Models.Element("Ge", 32, 72.64000));
            Elements.Add(new Models.Element("As", 33, 74.92160));
            Elements.Add(new Models.Element("Se", 34, 78.96000));
            Elements.Add(new Models.Element("Br", 35, 79.90400));
            Elements.Add(new Models.Element("Kr", 36, 83.79800));
            Elements.Add(new Models.Element("Rb", 37, 85.46780));
            Elements.Add(new Models.Element("Sr", 38, 87.62000));
            Elements.Add(new Models.Element("Y", 39, 88.90585));
            Elements.Add(new Models.Element("Zr", 40, 91.22400));
            Elements.Add(new Models.Element("Nb", 41, 92.90638));
            Elements.Add(new Models.Element("Mo", 42, 95.95000));
            Elements.Add(new Models.Element("Tc", 43, 98.00000));
            Elements.Add(new Models.Element("Ru", 44, 101.07000));
            Elements.Add(new Models.Element("Rh", 45, 102.90550));
            Elements.Add(new Models.Element("Pd", 46, 106.42000));
            Elements.Add(new Models.Element("Ag", 47, 107.86820));
            Elements.Add(new Models.Element("Cd", 48, 112.41400));
            Elements.Add(new Models.Element("In", 49, 114.81800));
            Elements.Add(new Models.Element("Sn", 50, 118.71000));
            Elements.Add(new Models.Element("Sb", 51, 121.76000));
            Elements.Add(new Models.Element("Te", 52, 127.60000));
            Elements.Add(new Models.Element("I", 53, 126.90447));
            Elements.Add(new Models.Element("Xe", 54, 131.29300));
            Elements.Add(new Models.Element("Cs", 55, 132.90545));
            Elements.Add(new Models.Element("Ba", 56, 137.32700));
            Elements.Add(new Models.Element("La", 57, 138.90547));
            Elements.Add(new Models.Element("Ce", 58, 140.11600));
            Elements.Add(new Models.Element("Pr", 59, 140.90765));
            Elements.Add(new Models.Element("Nd", 60, 144.24200));
            Elements.Add(new Models.Element("Pm", 61, 145.00000));
            Elements.Add(new Models.Element("Sm", 62, 150.36000));
            Elements.Add(new Models.Element("Eu", 63, 151.96400));
            Elements.Add(new Models.Element("Gd", 64, 157.25000));
            Elements.Add(new Models.Element("Tb", 65, 158.92535));
            Elements.Add(new Models.Element("Dy", 66, 162.50000));
            Elements.Add(new Models.Element("Ho", 67, 164.93033));
            Elements.Add(new Models.Element("Er", 68, 167.25900));
            Elements.Add(new Models.Element("Tm", 69, 168.93422));
            Elements.Add(new Models.Element("Yb", 70, 173.04500));
            Elements.Add(new Models.Element("Lu", 71, 174.96680));
            Elements.Add(new Models.Element("Hf", 72, 178.49000));
            Elements.Add(new Models.Element("Ta", 73, 180.94788));
            Elements.Add(new Models.Element("W", 74, 183.84000));
            Elements.Add(new Models.Element("Re", 75, 186.20700));
            Elements.Add(new Models.Element("Os", 76, 190.23000));
            Elements.Add(new Models.Element("Ir", 77, 192.21700));
            Elements.Add(new Models.Element("Pt", 78, 195.08400));
            Elements.Add(new Models.Element("Au", 79, 196.96657));
            Elements.Add(new Models.Element("Hg", 80, 200.59200));
            Elements.Add(new Models.Element("Tl", 81, 204.38200));
            Elements.Add(new Models.Element("Pb", 82, 207.20000));
            Elements.Add(new Models.Element("Bi", 83, 208.98040));
            Elements.Add(new Models.Element("Po", 84, 209.00000));
            Elements.Add(new Models.Element("At", 85, 210.00000));
            Elements.Add(new Models.Element("Rn", 86, 222.00000));
            Elements.Add(new Models.Element("Fr", 87, 223.00000));
            Elements.Add(new Models.Element("Ra", 88, 226.00000));
            Elements.Add(new Models.Element("Ac", 89, 227.00000));
            Elements.Add(new Models.Element("Th", 90, 232.03770));
            Elements.Add(new Models.Element("Pa", 91, 231.03588));
            Elements.Add(new Models.Element("U", 92, 238.02891));
            Elements.Add(new Models.Element("Np", 93, 237.00000));
            Elements.Add(new Models.Element("Pu", 94, 244.00000));
            Elements.Add(new Models.Element("Am", 95, 243.00000));
            Elements.Add(new Models.Element("Cm", 96, 247.00000));
            Elements.Add(new Models.Element("Bk", 97, 247.00000));
            Elements.Add(new Models.Element("Cf", 98, 251.00000));
            Elements.Add(new Models.Element("Es", 99, 252.00000));
            Elements.Add(new Models.Element("Fm", 100, 257.00000));
            Elements.Add(new Models.Element("Md", 101, 258.00000));
            Elements.Add(new Models.Element("No", 102, 259.00000));
            Elements.Add(new Models.Element("Lr", 103, 266.00000));
            Elements.Add(new Models.Element("Rf", 104, 267.00000));
            Elements.Add(new Models.Element("Db", 105, 270.00000));
            Elements.Add(new Models.Element("Sg", 106, 271.00000));
            Elements.Add(new Models.Element("Bh", 107, 270.00000));
            Elements.Add(new Models.Element("Hs", 108, 277.00000));
            Elements.Add(new Models.Element("Mt", 109, 276.00000));
            Elements.Add(new Models.Element("Ds", 110, 281.00000));
            Elements.Add(new Models.Element("Rg", 111, 280.00000));
            Elements.Add(new Models.Element("Cn", 112, 285.00000));
            Elements.Add(new Models.Element("Nh", 113, 284.00000));
            Elements.Add(new Models.Element("Fl", 114, 289.00000));
            Elements.Add(new Models.Element("Mc", 115, 288.00000));
            Elements.Add(new Models.Element("Lv", 116, 293.00000));
            Elements.Add(new Models.Element("Ts", 117, 294.00000));
            Elements.Add(new Models.Element("Og", 118, 294.00000));
        }
        
    }
}
