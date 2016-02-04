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
using Microsoft.Win32;

namespace ApplicationWPF.UserControls
{
    /// <summary>
    /// Interaction logic for CtrlTournoi.xaml
    /// </summary>
    public partial class CtrlTournoi : UserControl
    {
        public CtrlTournoi()
        {
            InitializeComponent();

            // Recuperation des caracteristiques
            BusinessLayer.JediTournamentManager jtm = new BusinessLayer.JediTournamentManager();
            List<string> matchs = (from x in jtm.getMatches() select x.Stade.Planete).ToList();

            Match1.ItemsSource = matchs;
            Match2.ItemsSource = matchs;
            Match3.ItemsSource = matchs;
            Match4.ItemsSource = matchs;
            Match5.ItemsSource = matchs;
            Match6.ItemsSource = matchs;
            Match7.ItemsSource = matchs;
            Match8.ItemsSource = matchs;
        }
    }
}
