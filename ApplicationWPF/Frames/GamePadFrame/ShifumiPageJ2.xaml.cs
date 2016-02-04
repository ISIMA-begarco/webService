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

namespace ApplicationWPF.Frames.GamePadFrame
{
    /// <summary>
    /// Logique d'interaction pour ShifumiPageJ2.xaml
    /// </summary>
    public partial class ShifumiPageJ2 : Page
    {
        public ShifumiPageJ2()
        {
            InitializeComponent();
        }

        private void ButtonPierre_Event(object sender, EventArgs e)
        {
            BusinessLayer.PartieManager.getCurrentGame().Choice_j1 = EntitiesLayer.EShifumi.Pierre;
            BusinessLayer.PartieManager.resolve();
        }

        private void ButtonPapier_Event(object sender, EventArgs e)
        {
            BusinessLayer.PartieManager.getCurrentGame().Choice_j1 = EntitiesLayer.EShifumi.Papier;
            BusinessLayer.PartieManager.resolve();
        }

        private void ButtonCiseau_Event(object sender, EventArgs e)
        {
            BusinessLayer.PartieManager.getCurrentGame().Choice_j1 = EntitiesLayer.EShifumi.Ciseau;
            BusinessLayer.PartieManager.resolve();
        }

    }
}
