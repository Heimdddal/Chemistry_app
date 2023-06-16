using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chemistry_app
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
        
        static BrushConverter converter = new BrushConverter();
        Brush outline = (Brush)converter.ConvertFromString("#66E39C");
        Brush noColor = (Brush)converter.ConvertFromString("#00000000");

        void removeAnionsColors()
        {
            I.BorderBrush = noColor;
            Br.BorderBrush = noColor;
            Cl.BorderBrush = noColor;
            NO3.BorderBrush = noColor;
            SO3.BorderBrush = noColor;
            SO4.BorderBrush = noColor;
            F.BorderBrush = noColor;
            NO2.BorderBrush = noColor;
            HCOO.BorderBrush = noColor;
            CH2COO.BorderBrush = noColor;
            PO4.BorderBrush = noColor;
            CO3.BorderBrush = noColor;
            S.BorderBrush = noColor;
            SiO3.BorderBrush = noColor;
            OH.BorderBrush = noColor;
        }
        void removeCationColors()
        {
            K.BorderBrush = noColor;
            Na.BorderBrush = noColor;
            Ba.BorderBrush = noColor;
            Ca.BorderBrush = noColor;
            NH4.BorderBrush = noColor;
            Ag.BorderBrush = noColor;
            Mg.BorderBrush = noColor;
            Pb.BorderBrush = noColor;
            Mn.BorderBrush = noColor;
            Fe2.BorderBrush = noColor;
            Zn.BorderBrush = noColor;
            Cu.BorderBrush = noColor;
            Hg.BorderBrush = noColor;
            Al.BorderBrush = noColor;
            Cr.BorderBrush = noColor;
            Fe3.BorderBrush = noColor;
            H.BorderBrush = noColor;
        }
        private void AnionTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (AnionTextbox.Text.ToString().ToUpper())
            {
                case "I":
                    removeAnionsColors();
                    I.BorderBrush = outline;
                    break;
                case "BR":
                    removeAnionsColors();
                    Br.BorderBrush = outline;
                    break;
                case "CL":
                    removeAnionsColors();
                    Cl.BorderBrush = outline;
                    break;
                case "NO3":
                    removeAnionsColors();
                    NO3.BorderBrush = outline;
                    break;
                case "SO3":
                    removeAnionsColors();
                    SO3.BorderBrush = outline;
                    break;
                case "SO4":
                    removeAnionsColors();
                    SO4.BorderBrush = outline;
                    break;
                case "F":
                    removeAnionsColors();
                    F.BorderBrush = outline;
                    break;
                case "NO2":
                    removeAnionsColors();
                    NO2.BorderBrush = outline;
                    break;
                case "HCOO":
                    removeAnionsColors();
                    HCOO.BorderBrush = outline;
                    break;
                case "CH2COO":
                    removeAnionsColors();
                    CH2COO.BorderBrush = outline;
                    break;
                case "PO4":
                    removeAnionsColors();
                    PO4.BorderBrush = outline;
                    break;
                case "CO3":
                    removeAnionsColors();
                    CO3.BorderBrush = outline;
                    break;
                case "S":
                    removeAnionsColors();
                    S.BorderBrush = outline;
                    break;
                case "SIO3":
                    removeAnionsColors();
                    SiO3.BorderBrush = outline;
                    break;
                case "OH":
                    removeAnionsColors();
                    OH.BorderBrush = outline;
                    break;
                default:
                    removeAnionsColors();
                    break;
            }
        }

        private void CationTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (CationTextbox.Text.ToString().ToUpper())
            {
                case "K":
                    removeCationColors();
                    K.BorderBrush = outline;
                    break;
                case "NA":
                    removeCationColors();
                    Na.BorderBrush = outline;
                    break;
                case "BA":
                    removeCationColors();
                    Ba.BorderBrush = outline;
                    break;
                case "CA":
                    removeCationColors();
                    Ca.BorderBrush = outline;
                    break;
                case "NH4":
                    removeCationColors();
                    NH4.BorderBrush = outline;
                    break;
                case "AG":
                    removeCationColors();
                    Ag.BorderBrush = outline;
                    break;
                case "MG":
                    removeCationColors();
                    Mg.BorderBrush = outline;
                    break;
                case "PB":
                    removeCationColors();
                    Pb.BorderBrush = outline;
                    break;
                case "MN":
                    removeCationColors();
                    Mn.BorderBrush = outline;
                    break;
                case "FE2":
                    removeCationColors();
                    Fe2.BorderBrush = outline;
                    break;
                case "ZN":
                    removeCationColors();
                    Zn.BorderBrush = outline;
                    break;
                case "CU":
                    removeCationColors();
                    Cu.BorderBrush = outline;
                    break;
                case "HG":
                    removeCationColors();
                    Hg.BorderBrush = outline;
                    break;
                case "AL":
                    removeCationColors();
                    Al.BorderBrush = outline;
                    break;
                case "CR":
                    removeCationColors();
                    Cr.BorderBrush = outline;
                    break;
                case "FE3":
                    removeCationColors();
                    Fe3.BorderBrush = outline;
                    break;
                case "H":
                    removeCationColors();
                    H.BorderBrush = outline;
                    break;
                default:
                    removeCationColors();
                    break;
            }
        }
    }
}
