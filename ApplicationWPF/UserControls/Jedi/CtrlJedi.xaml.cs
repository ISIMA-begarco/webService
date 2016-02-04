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
    /// Interaction logic for CtrlJedi.xaml
    /// </summary>
    public partial class CtrlJedi : UserControl
    {
        public CtrlJedi()
        {
            InitializeComponent();

            // Recuperation des caracteristiques
            BusinessLayer.JediTournamentManager jtm = new BusinessLayer.JediTournamentManager();
            List<EntitiesLayer.Caracteristique> caracs = jtm.getCaracteristiques();

            caracBox.ItemsSource = (from x in caracs select x.Nom).ToList();
        }

        private void OnChangeImageClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                //jediImage.Source = new BitmapImage(new Uri(op.FileName));
                ViewModel.Jedi.JediViewModel jvm = DataContext as ViewModel.Jedi.JediViewModel;
                jvm.ImageUri = new Uri(op.FileName, UriKind.Relative);
            }
        }

        private void caracBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext != null)
            {
                BusinessLayer.JediTournamentManager jtm = new BusinessLayer.JediTournamentManager();
                string carac = caracBox.SelectedItem as string;

                EntitiesLayer.Caracteristique car = (from x in jtm.getCaracteristiques()
                                                     where x.Nom == carac
                                                     select x).FirstOrDefault();

                ViewModel.Jedi.JediViewModel jvm = DataContext as ViewModel.Jedi.JediViewModel;
                List<EntitiesLayer.Caracteristique> jediCarac = jvm.Caracteristiques;
                jediCarac.Add(car);
                jvm.Caracteristiques = jediCarac;
                displayCarac.Items.Refresh();
            }
        }

        private void displayCarac_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext != null)
            {
                BusinessLayer.JediTournamentManager jtm = new BusinessLayer.JediTournamentManager();
                EntitiesLayer.Caracteristique car = displayCarac.SelectedItem as EntitiesLayer.Caracteristique;

                ViewModel.Jedi.JediViewModel jvm = DataContext as ViewModel.Jedi.JediViewModel;
                List<EntitiesLayer.Caracteristique> jediCarac = jvm.Caracteristiques;
                jediCarac.Remove(car);
                jvm.Caracteristiques = jediCarac;
                displayCarac.Items.Refresh();
            }
        }
    }
}
