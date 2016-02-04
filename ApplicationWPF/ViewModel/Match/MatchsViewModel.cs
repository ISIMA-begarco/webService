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
        private MatchViewModel m_selectedItem;

        private RelayCommand m_addCommand;
        private RelayCommand m_removeCommand;
        private RelayCommand m_closeCommand;
        
        public ObservableCollection<MatchViewModel> Matchs
        {
            get { return m_matchs; }
            private set
            {
                m_matchs = value;
                OnPropertyChanged("Matchs");
            }
        }

        public MatchViewModel SelectedMatch
        {
            get { return m_selectedItem; }
            set
            {
                m_selectedItem = value;
                OnPropertyChanged("SelectedMatch");
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


        public System.Windows.Input.ICommand AddCommand
        {
            get
            {
                if (m_addCommand == null)
                {
                    m_addCommand = new RelayCommand(
                        () => this.Add(),
                        () => this.CanAdd()
                        );
                }
                return m_addCommand;
            }
        }

        private bool CanAdd()
        {
            return true;
        }

        private void Add()
        {
            EntitiesLayer.Match m = new EntitiesLayer.Match(0, new EntitiesLayer.Jedi(0, null, false, "New"),
                                                            new EntitiesLayer.Jedi(0, null, false, "New"),
                                                            new EntitiesLayer.EPhaseTournoi(),
                                                            new EntitiesLayer.Stade(0, 0, "New", null));
            this.SelectedMatch = new MatchViewModel(m);
            m_matchs.Add(this.SelectedMatch);
        }

        public System.Windows.Input.ICommand RemoveCommand
        {
            get
            {
                if (m_removeCommand == null)
                {
                    m_removeCommand = new RelayCommand(
                        () => this.Remove(),
                        () => this.CanRemove()
                        );
                }
                return m_removeCommand;
            }
        }

        private bool CanRemove()
        {
            return (this.SelectedMatch != null);
        }

        private void Remove()
        {
            if (this.SelectedMatch != null) m_matchs.Remove(this.SelectedMatch);
        }
    }
}
