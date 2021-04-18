using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
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
                pin.Code = GetCodeHash("1234");
                context.PINCodes.Add(pin);
                context.SaveChanges();

            }
        }
        public string GetCodeHash(string inputText)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(inputText));
            return Convert.ToBase64String(hash);
        }
        private void InsertCardButton_Click(object sender, RoutedEventArgs e)
        {
            if (CardNumberField.Text != "")
            {
                PINCodeWindow pinCodeWindow = new PINCodeWindow(CardNumberField.Text);
                pinCodeWindow.ShowDialog();
            }
            
        }
    }
}
