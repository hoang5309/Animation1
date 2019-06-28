using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

namespace Animation1.car3_content
{
    /// <summary>
    /// Interaction logic for bigcard3.xaml
    /// </summary>
    public partial class bigcard3 : UserControl
    {
        public bigcard3(MainWindow MW)
        {
            InitializeComponent();
            mw = MW;
        }
        public MainWindow mw = new MainWindow();

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            mw.Action(3);
        }

        private void Getemail_Click(object sender, RoutedEventArgs e)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
        }
    }
}
