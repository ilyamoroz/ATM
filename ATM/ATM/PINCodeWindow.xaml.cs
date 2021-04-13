using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.InteropServices;
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
        private IPINCodeRepository codeRepository;
        private ICardRepository cardRepository;
        private string _cardNumber;
        private static  int attempts = 3;
        public PINCodeWindow(string cardNumber)
        {
            InitializeComponent();
            _cardNumber = cardNumber;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ATMContext"];
            
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<CodeModule>();
            var container = containerBuilder.Build();
            codeRepository = container.Resolve<IPINCodeRepository>(new NamedParameter("context", new ATMContext(settings.ConnectionString)));
           
            
            var containerBuilder1 = new ContainerBuilder();
            containerBuilder1.RegisterModule<CardModule>();
            var container1 = containerBuilder1.Build();
            cardRepository = container1.Resolve<ICardRepository>(new NamedParameter("context", new ATMContext(settings.ConnectionString)));
        }
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            int pin = Convert.ToInt32(PINCodeField.Text);
            if (attempts > 0)
            {
                if (pin == codeRepository.GetCode(cardRepository.GetCardIDByNumber(_cardNumber)))
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
