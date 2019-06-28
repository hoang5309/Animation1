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

namespace Animation1.card3_content
{
    /// <summary>
    /// Interaction logic for smallcard3.xaml
    /// </summary>
    public partial class smallcard3 : UserControl
    {
        public smallcard3(MainWindow MW)
        {
            InitializeComponent();
            mw = MW;
        }
        public MainWindow mw = new MainWindow();

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            mw.Action(3);
        }
    }
}
