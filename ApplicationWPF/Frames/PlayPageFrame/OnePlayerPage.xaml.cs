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

namespace ApplicationWPF.Frames.PlayPageFrame
{
    /// <summary>
    /// Logique d'interaction pour OnePlayerPage.xaml
    /// </summary>
    public partial class OnePlayerPage : Page
    {
        public OnePlayerPage()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, EventArgs args)
        {
            BusinessLayer.JediTournamentManager jtm = new BusinessLayer.JediTournamentManager();

            // Initialisation des Jedis
            IList<EntitiesLayer.Jedi> jedis = jtm.getJedis();
            ViewModel.Jedi.JedisModelView jvm = new ViewModel.Jedi.JedisModelView(jedis);
            J1Jedi.DataContext = jvm;
        }
    }
}
