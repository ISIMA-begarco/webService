using BusinessLayer;
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

namespace JediTournamentWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class ConnexionWindow : Window
    {
        public ConnexionWindow()
        {
            InitializeComponent();
        }

        public void Connexion_Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (JediTournamentManager.CheckConnexionUser(Login_TextBox.Text, Password_TextBox.Password))
            {
                this.Close();
            }
        }

    }
}
