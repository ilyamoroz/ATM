using System;
using System.Collections.Generic;
using System.Configuration;
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
using ATM.DataModel;

namespace ATM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //CreateCard();
        }

        public void CreateCard()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ATMContext"];
            using (ATMContext context = new ATMContext(settings.ConnectionString))
            {
                Card card = new Card();
                card.Number = "1234528415234582";
                context.Cards.Add(card);
                context.SaveChanges();
                PINCode pin = new PINCode();
                pin.CardID = 1;
                pin.Code = 1234;
                context.PINCodes.Add(pin);
                context.SaveChanges();

            }
        }
        private void InsertCardButton_Click(object sender, RoutedEventArgs e)
        {
            PINCodeWindow pinCodeWindow = new PINCodeWindow("1234528415234582");
            pinCodeWindow.ShowDialog();
        }
    }
}
