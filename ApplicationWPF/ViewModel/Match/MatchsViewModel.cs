using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioWPF.ViewModel;

namespace ApplicationWPF.ViewModel.Match
{
    class MatchsViewModel : ViewModelBase
    {
        private ObservableCollection<MatchViewModel> m_matchs;
        
        public ObservableCollection<MatchViewModel> Jedis
        {
            get { return m_matchs; }
            private set
            {
                m_matchs = value;
                OnPropertyChanged("Jedis");
            }
        }

        private MatchViewModel m_selectedItem;

        public MatchViewModel SelectedItem
        {
            get { return m_selectedItem; }
            set
            {
                m_selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public MatchsViewModel(IList<EntitiesLayer.Match> matchsModel)
        {
            m_matchs = new ObservableCollection<MatchViewModel>();
            foreach (EntitiesLayer.Match m in matchsModel)
            {
                m_matchs.Add(new MatchViewModel(m));
            }
        }
    }
}
