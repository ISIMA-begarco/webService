using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioWPF.ViewModel;

namespace ApplicationWPF.ViewModel.Jedi
{
    class JedisModelView : ViewModelBase
    {
        private ObservableCollection<JediViewModel> m_jedis;
        
        public ObservableCollection<JediViewModel> Jedis
        {
            get { return m_jedis; }
            private set
            {
                m_jedis = value;
                OnPropertyChanged("Jedis");
            }
        }

        private JediViewModel m_selectedItem;

        public JediViewModel SelectedItem
        {
            get { return m_selectedItem; }
            set
            {
                m_selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public JedisModelView(IList<EntitiesLayer.Jedi> jedisModel)
        {
            m_jedis = new ObservableCollection<JediViewModel>();
            foreach (EntitiesLayer.Jedi j in jedisModel)
            {
                m_jedis.Add(new JediViewModel (j));
            }
        }
    }
}
