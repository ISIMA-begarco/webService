using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioWPF.ViewModel;

namespace ApplicationWPF.ViewModel.Stade
{
    class StadesViewModel : ViewModelBase
    {
        private ObservableCollection<StadeViewModel> m_stades;
        
        public ObservableCollection<StadeViewModel> Stades
        {
            get { return m_stades; }
            private set
            {
                m_stades = value;
                OnPropertyChanged("Jedis");
            }
        }

        private StadeViewModel m_selectedItem;

        public StadeViewModel SelectedItem
        {
            get { return m_selectedItem; }
            set
            {
                m_selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public StadesViewModel(IList<EntitiesLayer.Stade> stadeModel)
        {
            m_stades = new ObservableCollection<StadeViewModel>();
            foreach (EntitiesLayer.Stade s in stadeModel)
            {
                m_stades.Add(new StadeViewModel(s));
            }
        }
    }
}
