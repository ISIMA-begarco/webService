using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BiblioWPF.ViewModel;

namespace ApplicationWPF.ViewModel.Jedi
{
    class JediViewModel : ViewModelBase
    {
        private EntitiesLayer.Jedi m_jedi;

        public EntitiesLayer.Jedi Jedi
        {
            get { return m_jedi; }
            set { m_jedi = value; }
        }

        public JediViewModel(EntitiesLayer.Jedi jedi)
        {
            m_jedi = jedi;
        }

        public string Nom
        {
            get { return m_jedi.Nom; }
            set
            {
                m_jedi.Nom = value;
                OnPropertyChanged("Nom");
            }
        }

        public bool IsSith
        {
            get { return m_jedi.IsSith; }
            set
            {
                m_jedi.IsSith = value;
                OnPropertyChanged("IsSith");
            }
        }

        public List<EntitiesLayer.Caracteristique> Caracteristiques
        {
            get { return m_jedi.Caracteristiques; }
            set
            {
                m_jedi.Caracteristiques = value;
                OnPropertyChanged("Caracteristiques");
            }
        }
    }
}
