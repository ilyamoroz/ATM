using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ATM.DataModel;
using ATM.Dependencies;
using ATM.Interfaces;
using Autofac;
using Autofac.Core;

namespace ATM
{
    /// <summary>
    /// Логика взаимодействия для PINCodeWindow.xaml
    /// </summary>
    public partial class PINCodeWindow : Window
    {
        private IATMRepository cardAtmRepository;
        private string _cardNumber;
        private static  int attempts = 3;
        public PINCodeWindow(string cardNumber)
        {
            InitializeComponent();
            _cardNumber = cardNumber;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ATMContext"];
            
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<ATMServiceModule>();
            var container = containerBuilder.Build();
            cardAtmRepository = container.Resolve<IATMRepository>(new NamedParameter("context", new ATMContext(settings.ConnectionString)));
        }
        
        public string GetCodeHash(string inputText)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(inputText));
            return Convert.ToBase64String(hash);
        }
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            string pin = PINCodeField.Text;
            if (attempts > 0)
            {
                if (GetCodeHash(pin) == cardAtmRepository.GetCode(cardAtmRepository.GetCardIDByNumber(_cardNumber)))
                {
                    MessageBox.Show("work");
                }
                else
                {
                    attempts--;
                    PINCodeField.Text = String.Empty;
                }
            }
            else
            {
                MessageBox.Show("Sorry, we must snatch your card");
                //function for snatch a card
            }

        }
    }
}
