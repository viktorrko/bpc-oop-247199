using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CV12_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calculator calculator = new Calculator();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = Operation.SelectedItem as ComboBoxItem;
            string operationData = selectedItem.Content.ToString();

            calculator.Calculate(decimal.Parse(Operand1.Text), decimal.Parse(Operand2.Text), operationData);
            
            display.Content = calculator.Display;
        }
    }
}