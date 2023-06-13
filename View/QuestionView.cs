using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Chemistry_app
{
    internal class Question
    {
        public GroupBox RadioButtonsGroup;
        public StackPanel questionStackPanel;

        public RadioButton RadioButtonTrue { get; set; }
        public RadioButton RadioButtonFalse1 { get; set; }
        public RadioButton RadioButtonFalse2 { get; set; }
        public RadioButton RadioButtonFalse3 { get; set; }

        public Question(string questionText, string trueAnswerText, string falseAnswer1Text, string falseAnswer2Text, string falseAnswer3Text)
        {
            RadioButtonTrue = new RadioButton()
            {
                Margin = new Thickness(5, 0, 0, 0),
                Content = trueAnswerText
            };
            RadioButtonFalse1 = new RadioButton()
            {
                Margin = new Thickness(5, 0, 0, 0),
                Content = falseAnswer1Text
            };
            RadioButtonFalse2 = new RadioButton()
            {
                Margin = new Thickness(5, 0, 0, 0),
                Content = falseAnswer2Text
            };
            RadioButtonFalse3 = new RadioButton()
            {
                Margin = new Thickness(5, 0, 0, 0),
                Content = falseAnswer3Text
            };

            var radioButtonList = new List<RadioButton> { RadioButtonTrue, RadioButtonFalse1, RadioButtonFalse2, RadioButtonFalse3 };
            Random random = new Random();
            radioButtonList = radioButtonList.OrderBy(x => random.Next()).ToList();

            RadioButtonsGroup = new GroupBox()
            {
                Margin = new Thickness(5),
                Content = new ListBox(),
                Header = questionText
            };

            foreach (var radioButton in radioButtonList)
            {
                ((ListBox)RadioButtonsGroup.Content).Items.Add(radioButton);
            }

            questionStackPanel = new StackPanel();
            questionStackPanel.Children.Add(this.RadioButtonsGroup);
        }
    }
}

