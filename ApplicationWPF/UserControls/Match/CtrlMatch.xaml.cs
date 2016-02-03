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

namespace ApplicationWPF.UserControls
{
    /// <summary>
    /// Interaction logic for CtrlMatch.xaml
    /// </summary>
    public partial class CtrlMatch : UserControl
    {
        public CtrlMatch()
        {
            InitializeComponent();

            BusinessLayer.JediTournamentManager jtm = new BusinessLayer.JediTournamentManager();

            // Recuperation des jedis
            List<EntitiesLayer.Jedi> jedis = jtm.getJedis();
            ViewModel.Jedi.JedisModelView jvm1 = new ViewModel.Jedi.JedisModelView(jedis);
            jedi1.DataContext = jvm1;

            ViewModel.Jedi.JedisModelView jvm2 = new ViewModel.Jedi.JedisModelView(jedis);
            jedi2.DataContext = jvm2;

            // Recuperation des stades
            List<EntitiesLayer.Stade> stades = jtm.getStades();
            ViewModel.Stade.StadesViewModel svm = new ViewModel.Stade.StadesViewModel(stades);
            stade.DataContext = svm;
        }
    }
}
