using System;
using System.Configuration;
using System.Linq;
using System.Windows;
using ATM.DataModel;
using ATM.Dependencies;
using ATM.Interfaces;
using Autofac;

namespace ATM
{
    /// <summary>
    /// Логика взаимодействия для ATM_Window.xaml
    /// </summary>
    public partial class ATM_Window : Window
    {
        private IATMRepository cardAtmRepository;
        private int _cardId;

        public ATM_Window(int cardId)
        {
            InitializeComponent();

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ATMContext"];

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<ATMServiceModule>();
            var container = containerBuilder.Build();
            cardAtmRepository = container.Resolve<IATMRepository>(new NamedParameter("context", new ATMContext(settings.ConnectionString)));
            _cardId = cardId;
            Balans_lbl.Visibility = Visibility.Hidden;

        }

        private void Balance_card_btn_Click(object sender, RoutedEventArgs e)
        {
            //Balans_lbl.Visibility = Visibility.Visible;
            TextBox.Text = cardAtmRepository.GetBalanse(_cardId);
        }

        private void Cash_card_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ATMContext"];
                using (ATMContext context = new ATMContext(settings.ConnectionString))
                {
                    int money = Convert.ToInt32(TextBox.Text);
                    CardCash cardCash = new CardCash();
                    string tB = TextBox.Text;
                    if (tB == "10" || tB == "50" || tB == "100" || tB == "200" || tB == "500" || tB == "1000")
                    {
                        var x = context.CardCash.Single(x => x.CardID == _cardId);
                        if (x.Cash > money)
                        {
                            x.Cash -= money;
                            context.SaveChanges();
                            MessageBox.Show("Выдача денег");
                            TextBox.Text = "";
                        }
                        else
                        {
                            MessageBox.Show($"На карт не достаточно средств!\n Баланс на карте: {cardAtmRepository.GetBalanse(_cardId)}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Банкомат может выддат только 10,50,100,200,500,1000");
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
