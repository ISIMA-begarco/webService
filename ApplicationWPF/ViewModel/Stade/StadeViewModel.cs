using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioWPF.ViewModel;

namespace ApplicationWPF.ViewModel.Stade
{
    class StadeViewModel : ViewModelBase
    {
        private EntitiesLayer.Stade m_stade;

        public StadeViewModel(EntitiesLayer.Stade stade)
        {
            m_stade = stade;
        }

        public string Planete
        {
            get { return m_stade.Planete; }
            set
            {
                m_stade.Planete = value;
                OnPropertyChanged("Planete");
            }
        }

        public int NbPlaces
        {
            get { return m_stade.NbPlaces; }
            set
            {
                m_stade.NbPlaces = value;
                OnPropertyChanged("NbPlaces");
            }
        }

        public List<EntitiesLayer.Caracteristique> Caracteristiques
        {
            get { return m_stade.Caracteristiques; }
            set
            {
                m_stade.Caracteristiques = value;
                OnPropertyChanged("Caracteristiques");
            }
        }
    }
}
