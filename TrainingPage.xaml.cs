﻿using Chemistry_app.Models;
using System;
using System.Collections.Generic;
using static Chemistry_app.Models.Questions;
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
using System.Windows.Media.Effects;

namespace Chemistry_app
{
    /// <summary>
    /// Логика взаимодействия для TrainingPage.xaml
    /// </summary>
    public partial class TrainingPage : Page
    {
        QuestionSelector questionSelector { get; set; }

        private List<Questions> questions = new List<Questions>();

        //Вспомогательный класс Результат ответа на вопрос
        class Result { 
            public string text { get; set; }
            public bool answer { get; set; }
            public Result(string text,bool answer) { 
                this.text = text;
                this.answer = answer;
            }
        }
        private List<Result> results = new List<Result>();

        private int currentQuestionIndex = 0;
        private int currentRadioButtonIndex;
        private int countTrue = 0;
        private StackPanel mainPanel = new StackPanel();
        private Grid mainGrid = new Grid();
        private ProgressBar progressBar = new ProgressBar() ;
        private StackPanel resultPanel = new StackPanel();
        private Grid resultGrid = new Grid();
        public TrainingPage()
        {
            InitializeComponent();

            #region Вопросы
            questions.Add(new Questions(
            "Что изучает химия?",
            new List<string> { "Состав, свойства и превращения вещества", "Астрономию", "Математику", "Биологию" },
            0 // индекс правильного ответа (в данном случае, "Состав, свойства и превращения вещества")
            ));
            questions.Add(new Questions(
            "В каких областях науки и технологии играет важную роль химия?",
            new List<string> { "Медицина", "Пищевая промышленность", "Материаловедение", "Все перечисленное" },
            3 // индекс правильного ответа (в данном случае, "Все перечисленное")
            ));
            questions.Add(new Questions(
            "Что такое элементы в химии?",
            new List<string> { "Материалы с высокой пластичностью", "Вещества, состоящие из атомов одного и того же вида", "Химические соединения", "Вещества с кристаллической структурой" },
            1 // индекс правильного ответа (в данном случае, "Вещества, состоящие из атомов одного и того же вида")
            ));
            questions.Add(new Questions(
            "Какие элементы обозначаются символом Fe и C соответственно?",
            new List<string> {"Фтор и Кальций" , "Кислород и Водород","Железо и Углерод" , "Свинец и Серебро" },
            2 // индекс правильного ответа (в данном случае, "Железо и Углерод")
            ));
            questions.Add(new Questions(
            "Какие типы веществ существуют?",
            new List<string> { "Соли, металлы, кислоты и оксиды", "Газы, жидкости и твердые вещества", "Органические и неорганические вещества", "Алканы, алкены и алкины" },
            0 // индекс правильного ответа (в данном случае, "Соли, металлы, кислоты и оксиды")
            ));
            questions.Add(new Questions(
            "Что образуют соли?",
            new List<string> { "Реакция кислот и оснований", "Реакция металлов и неметаллов", "Реакция оксидов и воды", "Реакция спиртов и карбонильных соединений" },
            0 // индекс правильного ответа (в данном случае, "Реакция кислот и оснований")
            ));
            questions.Add(new Questions(
            "Примеры кислот включают:",
            new List<string> { "Мышьяк и цианид", "Сахароза и глюкоза", "Натрий и калий","Уксусная кислота и серная кислота"  },
            3 // индекс правильного ответа (в данном случае, "Уксусная кислота и серная кислота")
            ));
            questions.Add(new Questions(
            "Что содержат оксиды?",
            new List<string> { "Углерод и водород","Кислород и другие элементы", "Азот и фосфор", "Сера и хлор" },
            1 // индекс правильного ответа (в данном случае, "Кислород и другие элементы")
            ));
            questions.Add(new Questions(
            "Какие типы оксидов существуют?",
            new List<string> { "Кислотные, основные и амфотерные", "Органические и неорганические", "Радиоактивные и стабильные", "Нейтральные и ионные" },
            0 // индекс правильного ответа (в данном случае, "Кислотные, основные и амфотерные")
            ));
            // Продолжайте добавлять вопросы по такому же шаблону
            questions.Add(new Questions(
            "Какие примеры солей вы знаете?",
            new List<string> {"Алюминий (Al) и золото (Au)" , "Уксусная кислота (CH3COOH) и серная кислота (H2SO4)","Хлорид натрия (NaCl) и сернокислый медь (CuSO4)" , "Оксид железа (FeO) и оксид кальция (CaO)" },
            2 // индекс правильного ответа (в данном случае, "Хлорид натрия (NaCl) и сернокислый медь (CuSO4)")
            ));
            questions.Add(new Questions(
            "Какие свойства обладают металлы?",
            new List<string> { "Прозрачность, легкость и красота","Блеск, проводимость электрического тока и тепла" , "Газообразное состояние при комнатной температуре", "Воспламеняемость и хрупкость" },
            1 // индекс правильного ответа (в данном случае, "Блеск, проводимость электрического тока и тепла")
            ));
            questions.Add(new Questions(
            "Что такое химическое уравнение?",
            new List<string> { "Это описание химической реакции с помощью символов и формул", "Это равенство химических величин в системе", "Это способ измерения массы вещества", "Это свойство атомов образовывать связи" },
            0 // индекс правильного ответа (в данном случае, "Это описание химической реакции с помощью символов и формул")
            ));
            questions.Add(new Questions(
            "Какое значение имеет балансировка химических уравнений?",
            new List<string> { "Она позволяет определить количество веществ, потребных для реакции, и количество продуктов", "Она определяет энергию, выделяющуюся или поглощаемую при реакции", "Она описывает скорость химической реакции", "Она характеризует состояние вещества" },
            0 // индекс правильного ответа (в данном случае, "Она позволяет определить количество веществ, потребных для реакции, и количество продуктов")
            ));
            questions.Add(new Questions(
            "Какие основные типы химических реакций вы знаете?",
            new List<string> { "Полимеризация, конденсация, эстерификация и гидролиз", "Окисление, восстановление, ионизация и гидратация", "Аддиция, электрофильное замещение, элиминация и протолиз", "Соединение, разложение, замещение и обмен" },
            3 // индекс правильного ответа (в данном случае, "Соединение, разложение, замещение и обмен")
            ));
            questions.Add(new Questions(
            "Что представляет собой балансировка химических уравнений?",
            new List<string> { "Процесс приведения уравнения к виду, где число атомов \nкаждого элемента на обеих сторонах будет совпадать", "Процесс преобразования молекул и ионов в другие соединения", "Процесс определения энергии, выделяющейся или поглощаемой при реакции", "Процесс изменения состояния вещества" },
            0 // индекс правильного ответа (в данном случае, "Процесс приведения уравнения к виду, где число атомов каждого элемента на обеих сторонах будет совпадать")
            ));
            questions.Add(new Questions(
            "Что необходимо уравнять при балансировке химических уравнений?",
            new List<string> { "Количество веществ в исходной смеси","Количество атомов каждого элемента на обеих сторонах реакции" , "Скорость химической реакции", "Температуру и давление" },
            1 // индекс правильного ответа (в данном случае, "Количество атомов каждого элемента на обеих сторонах реакции")
            ));
            questions.Add(new Questions(
            "Что представляет собой соединение в химии?",
            new List<string> {  "Процесс окисления и восстановления", "Физическое смещение вещества","Химическое вещество, состоящее\n из атомов двух или более элементов", "Вещество, образованное растворением в воде" },
            2 // индекс правильного ответа (в данном случае, "Химическое вещество, состоящее из атомов двух или более элементов")
            ));
            questions.Add(new Questions(
            "Что описывают химические уравнения для реакций соединения?",
            new List<string> { "Процесс превращения реагентов в продукты", "Соотношение между концентрациями веществ", "Изменение температуры при реакции", "Скорость протекания реакции" },
            0 // индекс правильного ответа (в данном случае, "Процесс превращения реагентов в продукты")
            ));
            questions.Add(new Questions(
            "Что означает сбалансированное химическое уравнение?",
            new List<string> { "Количество атомов каждого элемента одинаково на обеих сторонах уравнения", "Процесс преобразования одного соединения в другое", "Описывает обратимую реакцию", "Уравнение, в котором все коэффициенты равны 1" },
            0 // индекс правильного ответа (в данном случае, "Количество атомов каждого элемента одинаково на обеих сторонах уравнения")
            ));
            questions.Add(new Questions(
            "Какое химическое уравнение описывает синтез воды из водорода и кислорода?",
            new List<string> {"CH4 + 2O2 → CO2 + 2H2O", "H2O + CO2 → H2CO3", "2NaCl + H2SO4 → 2HCl + Na2SO4", "2H2 + O2 → 2H2O"  },
            3 // индекс правильного ответа (в данном случае, "2H2 + O2 → 2H2O")
            ));
            questions.Add(new Questions(
            "Какая реакция соединения описывает разложение угольной кислоты?",
            new List<string> { "2H2O → 2H2 + O2","H2CO3 → CO2 + H2O" , "NaCl + AgNO3 → NaNO3 + AgCl", "C6H12O6 + 6O2 → 6CO2 + 6H2O" },
            1 // индекс правильного ответа (в данном случае, "H2CO3 → CO2 + H2O")
            ));
            questions.Add(new Questions(
            "Что представляет собой разложение в химических реакциях?",
            new List<string> {"Превращение газообразного вещества в твердое" , "Процесс слияния двух или более веществ","Процесс, в ходе которого одно вещество\n распадается на два или более продукта" , "Процесс образования нового вещества" },
            2 // индекс правильного ответа (в данном случае, "Процесс, в ходе которого одно вещество распадается на два или более продукта")
            ));
            questions.Add(new Questions(
            "Какие факторы могут вызвать разложение вещества?",
            new List<string> { "Тепло, свет или электрический ток", "Давление и температура", "Взаимодействие с другими веществами", "Изменение фазового состояния" },
            0 // индекс правильного ответа (в данном случае, "Тепло, свет или электрический ток")
            ));
            questions.Add(new Questions(
            "Какой продукт образуется при разложении гидроксида аммония (NH4OH)?",
            new List<string> { "NH3 и H2O", "H2O и CO2", "NH3 и O2", "CO2 и O2" },
            0 // индекс правильного ответа (в данном случае, "NH3 и H2O")
            ));
            questions.Add(new Questions(
            "Какой продукт образуется при разложении пероксида водорода (H2O2) под воздействием марганцовокислого калия (MnO2)?",
            new List<string> { "CO2 и H2O","H2O и O2" , "NaOH и H2SO4", "CaCO3 и HCl" },
            1 // индекс правильного ответа (в данном случае, "H2O и O2")
            ));
            questions.Add(new Questions(
            "Какой компонент образуется при разложении гидроксида меди (II) (Cu(OH)2)?",
            new List<string> {"Cu(OH)", "Cu(OH)3", "CuO" , "CuCl2" },
            2 // индекс правильного ответа (в данном случае, "CuO")
            ));
            questions.Add(new Questions(
            "Что представляет собой реакция замещения в химии?",
            new List<string> { "Процесс, при котором один элемент или группа элементов замещается другими элементами или группами элементов в химическом соединении", "Процесс, при котором элементы соединяются в новое химическое вещество", "Процесс, при котором происходит распад химического соединения", "Процесс, при котором происходит образование осадка" },
            0 // индекс правильного ответа (в данном случае, "Процесс, при котором один элемент или группа элементов замещается другими элементами или группами элементов в химическом соединении")
            ));
            questions.Add(new Questions(
            "Какой элемент замещается при реакции меди с серной кислотой (Cu+H2SO4→CuSO4+H2)?",
            new List<string> { "Никакой элемент не замещается", "Медь", "Сера", "Водород" },
            1 // индекс правильного ответа (в данном случае, "Медь")
            ));
            questions.Add(new Questions(
            "Какой продукт образуется при реакции хлора с фторидом калия (Cl2+2KF→F2Cl2+2KCl)?",
            new List<string> { "F2Cl2 и 2KCl", "Cl2 и 2KF", "F2Cl2 и KF", "ClF и 2KCl" },
            0 // индекс правильного ответа (в данном случае, "F2Cl2 и 2KCl")
            ));
            questions.Add(new Questions(
            "Какие ионы образуются при реакции нитрат-иона с аммоний-ионом (NH4NO3+Ag→AgNO3+NH4NO2)?",
            new List<string> { "AgNO3 и NH4NO2", "NH4NO3 и Ag", "Ag и NO3", "NH4 и NO2" },
            0 // индекс правильного ответа (в данном случае, "AgNO3 и NH4NO2")
            ));
            questions.Add(new Questions(
            "Что необходимо знать для решения реакций замещения?",
            new List<string> { "Активность элементов", "Массу вещества", "Цвет продуктов", "Температуру реакции" },
            0 // индекс правильного ответа (в данном случае, "Активность элементов")
            ));
            questions.Add(new Questions(
            "Что представляет собой химическая реакция обмена?",
            new List<string> { "Процесс, при котором ионы одного соединения вытесняют \nионы другого соединения, образуя два новых соединения", "Процесс, при котором происходит объединение ионов из двух соединений", "Процесс, при котором происходит разложение химического соединения на элементы", "Процесс, при котором происходит образование осадка" },
            0 // индекс правильного ответа (в данном случае, "Процесс, при котором ионы одного соединения вытесняют ионы другого соединения, образуя два новых соединения")
            ));
            questions.Add(new Questions(
            "Какие соединения образуются при реакции AB+CD→AD+CB?",
            new List<string> { "AD и CB", "AB и CD", "AC и BD", "AD и BC" },
            0 // индекс правильного ответа (в данном случае, "AD и CB")
            ));
            questions.Add(new Questions(
            "Какие ионы вытесняются в реакции AgNO3 + NaCl → AgCl + NaNO3?",
            new List<string> { "Ag+ вытесняет Na+ и Cl- вытесняет NO3-", "Ag+ вытесняет Cl- и Na+ вытесняет NO3-", "Na+ вытесняет Ag+ и Cl- вытесняет NO3-", "Cl- вытесняет Ag+ и Na+ вытесняет NO3-" },
            0 // индекс правильного ответа (в данном случае, "Ag+ вытесняет Na+ и Cl- вытесняет NO3-")
            ));
            questions.Add(new Questions(
            "Какие соединения образуются в реакции K2CO3+Ba(NO3)2→2KNO3+BaCO3?",
            new List<string> { "KNO3 и BaCO3", "K2CO3 и Ba(NO3)2", "KNO2 и BaCO2", "KNO3 и Ba(NO2)2" },
            0 // индекс правильного ответа (в данном случае, "KNO3 и BaCO3")
            ));
            questions.Add(new Questions(
            "Что необходимо запомнить для решения задач по химическим реакциям обмена?",
            new List<string> { "Таблицу соответствий ионов, которая показывает, какие ионы способны вытеснять друг друга", "Температуру реакции", "Массу вещества", "Расположение элементов в периодической таблице" },
            0 // индекс правильного ответа (в данном случае, "Таблицу соответствий ионов, которая показывает, какие ионы способны вытеснять друг друга")
            ));
            #endregion
            
            mainGrid.Children.Add(mainPanel);
            resultGrid.Children.Add(resultPanel);
            questionSelector = new QuestionSelector(questions);
        }

        private void StartTrainig_Click(object sender, RoutedEventArgs e)//Выбрано кол-во вопросов, нажата кнопка начать
        {
            
            int countQuestions;
            countQuestions = int.Parse(textBoxAge.Text);
            
            
            questions = questionSelector.SelectRandomQuestions(countQuestions);//выборка нужного кол-ва вопросов с перемешкой вариантов ответа
            TrainingGrid.Visibility = Visibility.Collapsed;
            this.Content = mainGrid;
            mainGrid.Visibility = Visibility.Visible;
            progressBar.Width = 1000;
            progressBar.Height = 30;
            progressBar.Minimum = 1;
            progressBar.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#66E39C"));
            progressBar.Margin = new Thickness(50,610,0,0);
            progressBar.Maximum = countQuestions;
            mainGrid.Children.Add(progressBar);
            DisplayCurrentQuestion();
        }
        
        private void DisplayCurrentQuestion()//Вывести  текущий вопрос
        {
            int i = 0;
            
            Questions currentQuestion = questions[currentQuestionIndex];//текущий вопрос

            
            mainPanel.Children.Clear();

            
            TextBlock questionTextBlock = new TextBlock
            {
                Text = currentQuestionIndex + 1 +". " +currentQuestion.Text,
                Foreground = Brushes.White,
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0,150,0,20),
                FontWeight = FontWeights.Bold,
                FontSize = 25
            };
            mainPanel.Children.Add(questionTextBlock);
            List<RadioButton> optionRadioButtons = new List<RadioButton>();
            foreach (string option in currentQuestion.Options)//Создание 4 кнопок-переключателей
            {
                RadioButton optionRadioButton = new RadioButton
                {
                    Content = option,
                    Background = Brushes.White,
                    Foreground = Brushes.White,
                    FontSize = 20,
                    Margin = new Thickness(0,30,0,0)
                };
                optionRadioButton.Tag = i;
                i++;
                optionRadioButton.Checked += OptionRadioButton_Checked;
                optionRadioButtons.Add(optionRadioButton);
            }

            foreach (RadioButton optionRadioButton in optionRadioButtons)//Добавление 4 кнопок-переключателей на stackPanel
            {
                mainPanel.Children.Add(optionRadioButton);
            }

            Button nextQuestionButton = new Button
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Content = "Следующий вопрос",
                Width = 200,
                Foreground = Brushes.White,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#66E39C")),
                FontSize = 15,
                Height = 50,
                Margin = new Thickness(0,120,0,0),
                Effect = new DropShadowEffect {
                    ShadowDepth = 2,
                    BlurRadius = 4,
                    Color = Color.FromArgb(0x40,0x00,0x00,0x00),
                    Opacity = 0.5
                },
                Padding = new Thickness(12,6,12,6)
            };
            mainPanel.Children.Add(nextQuestionButton);
            TextBlock currentQuestionNumber = new TextBlock
            {
                Text = progressBar.Value.ToString(),
                Foreground = Brushes.White,
                Margin = new Thickness(10),
                FontWeight = FontWeights.Bold,
                FontSize = 20
            };
            mainPanel.Children.Add(currentQuestionNumber);
            nextQuestionButton.Click += NextQuestionButton_Click;
            mainPanel.Visibility = Visibility.Visible;
        }
        void OptionRadioButton_Checked(object sender, RoutedEventArgs e)//Ответ на порос, индекс
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.IsChecked == true)
            {
                currentRadioButtonIndex = (int)radioButton.Tag;
            }
        }
        private void NextQuestionButton_Click(object sender, RoutedEventArgs e)//Следующий вопрос
        {
           
            Questions currentQuestion = questions[currentQuestionIndex];

            if (currentRadioButtonIndex == currentQuestion.CorrectAnswerIndex)
            {
                countTrue++;
                results.Add(new Result(currentQuestion.Text, true));
            }
            else { results.Add(new Result(currentQuestion.Text, false));
            }
            progressBar.Value += 1;
            currentQuestionIndex++;
            if (currentQuestionIndex >= questions.Count)
            {
                mainGrid.Visibility = Visibility.Collapsed;
                DisplayCurrentResult();
            }
            else DisplayCurrentQuestion();
        }
        private void DisplayCurrentResult()//Вывести результат
        {
            resultPanel.Children.Clear();
            string answer;
            int numberAnswer = 1;
            foreach(Result result in results){ //Вывод результата
                TextBlock resultTextBlock = new TextBlock
                {
                    Text = numberAnswer +". "+ result.text,
                    Foreground = Brushes.White,
                    Margin = new Thickness(10),
                    FontWeight = FontWeights.Bold,
                    FontSize = 20
                };
                resultPanel.Children.Add(resultTextBlock);

                if (result.answer)
                    answer = "Ответ: верный";
                else answer = "Ответ: неверный";

                TextBlock resultAnswerTextBlock = new TextBlock
                {
                    Text = answer,
                    Foreground = Brushes.White,
                    Margin = new Thickness(10),
                    FontWeight = FontWeights.Bold,
                    FontSize = 20
                };
                resultPanel.Children.Add(resultAnswerTextBlock);
                numberAnswer++;
            }

            string supCountTrue = "Правильно: " + countTrue.ToString();
            TextBlock resultCountTrueTextBlock = new TextBlock
            {
                Text = supCountTrue,
                Foreground = Brushes.White,
                Margin = new Thickness(10),
                FontWeight = FontWeights.Bold,
                FontSize = 20
            };
            resultPanel.Children.Add(resultCountTrueTextBlock);

            resultPanel.Visibility = Visibility.Visible;
            this.Content = resultGrid;
        }
    }
}
