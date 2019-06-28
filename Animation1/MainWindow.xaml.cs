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
using System.Speech.Recognition;
using System.Speech.Synthesis;
using Animation1.card3_content;

using System.Windows.Media.Animation;

namespace Animation1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Thickness bigMargin;
        public double bigHeight;
        public double bigWidth;
        public int state = 0;
        public SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            state = 1;
            Choices commands = new Choices();
            commands.Add(new string[] { "contact", "fundraising", "direct mail", "add contact", "add donation" });
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(commands);
            Grammar g = new Grammar(gb);

            //recEngine.LoadGrammarAsync(new DictationGrammar());
            recEngine.LoadGrammarAsync(g);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += doing_command;

            recEngine.RecognizeAsync(RecognizeMode.Multiple);

            grid3.Children.Clear();
            grid3.Children.Add(new smallcard3(this));
        }
        public void doing_command(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine(e.Result.Text);
            switch (e.Result.Text)
            {
                case "contact":
                    Console.WriteLine("1");
                    Btn1_Click(null, null);
                    break;
                case "fundraising":
                    Console.WriteLine("2");
                    Btn2_Click(null, null);
                    break;
                case "direct mail":
                    Console.WriteLine("3");
                    Btn3_Click(null, null);
                    break;
                case "add contact":
                    Console.WriteLine("4");
                    Btn4_Click(null, null);
                    break;
                case "add donation":
                    Console.WriteLine("5");
                    Btn5_Click(null, null);
                    break;
            }
        }
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            Action(1);
        }
        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            Action(2);
        }
        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            Action(3);
        }
        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            Action(4);
        }
        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            Action(5);
        }

        public void Action(int command)
        {
            Console.WriteLine("Command " + command);
            if(command != state)
            {
                switch (state)
                {
                    case 1:
                        bigMargin = card1.Margin;
                        bigHeight = card1.Height;
                        bigWidth = card1.Width;
                        if(command == 2)
                        {
                            Thickness smallMargin = card2.Margin;
                            double smallHeight = card2.Height;
                            double smallWidth = card2.Width;
                            // SWAP
                           
                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card1");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card1");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card1");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card2");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card2");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card2");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            state = 2;
                        }
                        if(command == 3)
                        {
                            Thickness smallMargin = card3.Margin;
                            double smallHeight = card3.Height;
                            double smallWidth = card3.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card1");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card1");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card1");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card3");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card3");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card3");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            grid3.Children.Clear();
                            grid3.Children.Add(new bigcard3(this));
                            state = 3;
                        }
                        if(command == 4)
                        {
                            Thickness smallMargin = card4.Margin;
                            double smallHeight = card4.Height;
                            double smallWidth = card4.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card1");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card1");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card1");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card4");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card4");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card4");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            state = 4;
                        }
                        if(command == 5)
                        {
                            Thickness smallMargin = card5.Margin;
                            double smallHeight = card5.Height;
                            double smallWidth = card5.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card1");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card1");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card1");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card5");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card5");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card5");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            state = 5;
                        }
                        Console.WriteLine("State " + state);
                        break;
                    case 2:
                        bigMargin = card2.Margin;
                        bigHeight = card2.Height;
                        bigWidth = card2.Width;
                        if (command == 1)
                        {
                            Thickness smallMargin = card1.Margin;
                            double smallHeight = card1.Height;
                            double smallWidth = card1.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card2");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card2");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card2");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card1");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card1");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card1");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            state = 1;
                        }
                        if (command == 3)
                        {
                            Thickness smallMargin = card3.Margin;
                            double smallHeight = card3.Height;
                            double smallWidth = card3.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card2");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card2");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card2");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card3");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card3");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card3");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            grid3.Children.Clear();
                            grid3.Children.Add(new bigcard3(this));

                            state = 3;
                        }
                        if (command == 4)
                        {
                            Thickness smallMargin = card4.Margin;
                            double smallHeight = card4.Height;
                            double smallWidth = card4.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card2");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card2");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card2");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card4");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card4");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card4");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            state = 4;
                        }
                        if (command == 5)
                        {
                            Thickness smallMargin = card5.Margin;
                            double smallHeight = card5.Height;
                            double smallWidth = card5.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card2");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card2");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card2");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card5");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card5");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card5");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            state = 5
;
                        }
                        Console.WriteLine("State " + state);
                        break;
                    case 3:
                        bigMargin = card3.Margin;
                        bigHeight = card3.Height;
                        bigWidth = card3.Width;
                        if (command == 1)
                        {
                            Thickness smallMargin = card1.Margin;
                            double smallHeight = card1.Height;
                            double smallWidth = card1.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card3");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card3");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card3");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card1");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card1");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card1");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            state = 1;
                        }
                        if (command == 2)
                        {
                            Thickness smallMargin = card2.Margin;
                            double smallHeight = card2.Height;
                            double smallWidth = card2.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card3");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card3");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card3");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card2");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card2");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card2");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            state = 2;
                        }
                        if (command == 4)
                        {
                            Thickness smallMargin = card4.Margin;
                            double smallHeight = card4.Height;
                            double smallWidth = card4.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card3");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card3");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card3");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card4");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card4");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card4");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            state = 4;
                        }
                        if (command == 5)
                        {
                            Thickness smallMargin = card5.Margin;
                            double smallHeight = card5.Height;
                            double smallWidth = card5.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card3");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card3");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card3");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card5");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card5");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card5");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            state = 5
;
                        }
                        grid3.Children.Clear();
                        grid3.Children.Add(new smallcard3(this));
                        break;
                    case 4:
                        bigMargin = card4.Margin;
                        bigHeight = card4.Height;
                        bigWidth = card4.Width;
                        if (command == 1)
                        {
                            Thickness smallMargin = card1.Margin;
                            double smallHeight = card1.Height;
                            double smallWidth = card1.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card4");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card4");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card4");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card1");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card1");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card1");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            state = 1;
                        }
                        if (command == 2)
                        {
                            Thickness smallMargin = card2.Margin;
                            double smallHeight = card2.Height;
                            double smallWidth = card2.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card4");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card4");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card4");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card2");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card2");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card2");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            state = 2;
                        }
                        if (command == 3)
                        {
                            Thickness smallMargin = card3.Margin;
                            double smallHeight = card3.Height;
                            double smallWidth = card3.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card4");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card4");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card4");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card3");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card3");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card3");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            grid3.Children.Clear();
                            grid3.Children.Add(new bigcard3(this));

                            state = 3;
                        }
                        if (command == 5)
                        {
                            Thickness smallMargin = card5.Margin;
                            double smallHeight = card5.Height;
                            double smallWidth = card5.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card4");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card4");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card4");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card5");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card5");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card5");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            state = 5
;
                        }
                        Console.WriteLine("State " + state);
                        break;
                    case 5:
                        bigMargin = card5.Margin;
                        bigHeight = card5.Height;
                        bigWidth = card5.Width;
                        if (command == 1)
                        {
                            Thickness smallMargin = card1.Margin;
                            double smallHeight = card1.Height;
                            double smallWidth = card1.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card5");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card5");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card5");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card1");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card1");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card1");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            state = 1;
                        }
                        if (command == 2)
                        {
                            Thickness smallMargin = card2.Margin;
                            double smallHeight = card2.Height;
                            double smallWidth = card2.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card5");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card5");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card5");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card2");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card2");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card2");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            state = 2;
                        }
                        if (command == 3)
                        {
                            Thickness smallMargin = card3.Margin;
                            double smallHeight = card3.Height;
                            double smallWidth = card3.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card5");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card5");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card5");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card3");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card3");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card3");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            grid3.Children.Clear();
                            grid3.Children.Add(new bigcard3(this));

                            state = 3;
                        }
                        if (command == 4)
                        {
                            Thickness smallMargin = card4.Margin;
                            double smallHeight = card4.Height;
                            double smallWidth = card4.Width;
                            // SWAP

                            // Set Big To Small
                            ThicknessAnimation BTSMargin = new ThicknessAnimation();
                            BTSMargin.From = bigMargin;
                            BTSMargin.To = smallMargin;
                            BTSMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSHeight = new DoubleAnimation();
                            BTSHeight.From = bigHeight;
                            BTSHeight.To = smallHeight;
                            BTSHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation BTSWidth = new DoubleAnimation();
                            BTSWidth.From = bigWidth;
                            BTSWidth.To = smallWidth;
                            BTSWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Set Small To Big
                            ThicknessAnimation STBMargin = new ThicknessAnimation();
                            STBMargin.From = smallMargin;
                            STBMargin.To = bigMargin;
                            STBMargin.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBHeight = new DoubleAnimation();
                            STBHeight.From = smallHeight;
                            STBHeight.To = bigHeight;
                            STBHeight.Duration = TimeSpan.FromMilliseconds(300);

                            DoubleAnimation STBWidth = new DoubleAnimation();
                            STBWidth.From = smallWidth;
                            STBWidth.To = bigWidth;
                            STBWidth.Duration = TimeSpan.FromMilliseconds(300);

                            // Action Big to Small
                            Storyboard.SetTargetName(BTSMargin, "card5");
                            Storyboard.SetTargetProperty(BTSMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(BTSHeight, "card5");
                            Storyboard.SetTargetProperty(BTSHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(BTSWidth, "card5");
                            Storyboard.SetTargetProperty(BTSWidth, new PropertyPath(WidthProperty));

                            // Action Small to Big
                            Storyboard.SetTargetName(STBMargin, "card4");
                            Storyboard.SetTargetProperty(STBMargin, new PropertyPath(MarginProperty));
                            Storyboard.SetTargetName(STBHeight, "card4");
                            Storyboard.SetTargetProperty(STBHeight, new PropertyPath(HeightProperty));
                            Storyboard.SetTargetName(STBWidth, "card4");
                            Storyboard.SetTargetProperty(STBWidth, new PropertyPath(WidthProperty));

                            Storyboard sb = new Storyboard();

                            sb.Children.Add(BTSMargin);
                            sb.Children.Add(BTSHeight);
                            sb.Children.Add(BTSWidth);
                            sb.Children.Add(STBMargin);
                            sb.Children.Add(STBHeight);
                            sb.Children.Add(STBWidth);
                            sb.Begin(this);

                            state = 4
;
                        }
                        Console.WriteLine("State " + state);
                        break;
                }
            }
        }
    }
}
