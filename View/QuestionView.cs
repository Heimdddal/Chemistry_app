using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using System.Windows.Shapes;

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
                Foreground = Brushes.White,
                Content = trueAnswerText,
            };
            RadioButtonFalse1 = new RadioButton()
            {
                Margin = new Thickness(5, 0, 0, 0),
                Foreground = Brushes.White,
                Content = falseAnswer1Text
            };
            RadioButtonFalse2 = new RadioButton()
            {
                Margin = new Thickness(5, 0, 0, 0),
                Foreground = Brushes.White,
                Content = falseAnswer2Text
            };
            RadioButtonFalse3 = new RadioButton()
            {
                Margin = new Thickness(5, 0, 0, 0),
                Foreground = Brushes.White,
                Content = falseAnswer3Text,
            };

            var radioButtonList = new List<RadioButton> { RadioButtonTrue, RadioButtonFalse1, RadioButtonFalse2, RadioButtonFalse3 };
            Random random = new Random(DateTime.Now.Millisecond);
            radioButtonList = radioButtonList.OrderBy(x => random.Next()).ToList();

            RadioButtonsGroup = new GroupBox()
            {
                Margin = new Thickness(5, 5, 5, 30),
                Header = questionText,
                Foreground = Brushes.White,
                FontSize = 20
            };
         

            RadioButtonsGroup.Content = new StackPanel();

            foreach (var radioButton in radioButtonList)
            {
                ((StackPanel)RadioButtonsGroup.Content).Children.Add(radioButton);
            }
            questionStackPanel = new StackPanel();
            questionStackPanel.Children.Add(RadioButtonsGroup);
        }
    }
}
