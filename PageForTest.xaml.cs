﻿using Chemistry_app.Models;
using Chemistry_app.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для PageForTest.xaml
    /// </summary>
    public partial class PageForTest : Page
    {
        public PageForTest(User user)
        {
            InitializeComponent();

            List<Question> questions = new List<Question>()
            {
                 new Question("Что происходит при реакции между гидроксидом калия и серной кислотой?", "K2SO4 + 2H2O", "KO2 + 2H2O", "KOH + H2SO4", "K2SO3 + H2O"),
                new Question("Какие продукты образуются при реакции между хлоридом кальция и карбонатом натрия?", "CaCO3 + 2NaCl", "CaCl2 + Na2CO3", "Ca(OH)2 + NaOH", "Ca(NO3)2 + NaCl"),
                new Question("Какое соединение образуется при реакции между оксидом алюминия и кислотой хлорис-\nтоводородной?", "2AlCl3 + 3H2O", "AlCl3 + 3H2O", "Al2O3 + 6HCl", "Al(OH)3 + 3HCl"),
                 new Question("Что происходит при реакции между гидроксидом железа(III) и серной кислотой?", "Fe2(SO4)3 + 3H2O", "Fe(OH)3 + 3H2SO4", "FeSO4 + 2HCl", "FeCl3 + 3H2O"),
                 new Question("Какие продукты образуются при реакции между углекислым газом и известковым моло-\nком?", "CaCO3 + H2O", "CaCO3 + CO2", "Ca(OH)2 + CO2", "Ca(OH)2 + H2O"),
                new Question("Какое соединение образуется при реакции между хлоридом железа(II) и кислородом?", "2Fe2O3 + 8HCl", "4FeCl2 + O2", "FeCl2 + H2O2", "Fe(OH)2 + Cl2"),
                new Question("Что происходит при реакции между гидроксидом аммония и кислотой соляной?", "NH4Cl + H2O", "NH4OH + HCl", "NH4ClO3 + HCl", "NH3 + H2SO4"),
                 new Question("Какие продукты образуются при реакции между хлоридом цинка и серной кислотой?", "ZnSO4 + 2HCl", "ZnCl2 + H2SO4", "ZnS + 2HCl", "ZnO + 2HCl"),
                 new Question("Какое соединение образуется при реакции между карбонатом натрия и кислотой хло-\nристоводородной?", "2NaCl + CO2 + H2O", "NaHCO3 + NaCl", "NaClO3 + CO2 + H2O", "NaCl + CaCO3"),
                 new Question("Что происходит при реакции между гидроксидом бария и кислотой азотной?", "Ba(NO3)2 + 2H2O", "Ba(OH)2 + 2HNO3", "BaCl2 + H2SO4", "BaSO4 + 2HCl"),
            };

           

            var testApplication = new TestApplication(questions, ref MainGrid, "Химические уравнения", user.Name, user.Email);
        }
    }
}
