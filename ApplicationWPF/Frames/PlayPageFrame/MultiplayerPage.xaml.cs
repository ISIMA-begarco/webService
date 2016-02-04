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
    /// Logique d'interaction pour MultiplayerPage.xaml
    /// </summary>
    public partial class MultiplayerPage : Page
    {
        public MultiplayerPage()
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

            IList<EntitiesLayer.Jedi> jedis2 = jtm.getJedis();
            ViewModel.Jedi.JedisModelView jvm2 = new ViewModel.Jedi.JedisModelView(jedis);
            J2Jedi.DataContext = jvm2;

        }

        private void J1Jedi_MouseLeave(object sender, MouseEventArgs e)
        {
            if ((this.J1Jedi.ComboJedi.SelectedItem as ViewModel.Jedi.JediViewModel) != null)
                BusinessLayer.PartieManager.getCurrentGame().Jedi_j1 = (this.J1Jedi.ComboJedi.SelectedItem as ViewModel.Jedi.JediViewModel).Jedi;
        }

        private void J2Jedi_MouseLeave(object sender, MouseEventArgs e)
        {
            if ((this.J2Jedi.ComboJedi.SelectedItem as ViewModel.Jedi.JediViewModel) != null)
                BusinessLayer.PartieManager.getCurrentGame().Jedi_j2 = (this.J2Jedi.ComboJedi.SelectedItem as ViewModel.Jedi.JediViewModel).Jedi;
        }
    }
}
