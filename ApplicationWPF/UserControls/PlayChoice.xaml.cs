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

namespace ApplicationWPF.UserControls
{
   

    /// <summary>
    /// Logique d'interaction pour PlayChoice.xaml
    /// </summary>
    public partial class PlayChoice : UserControl
    {

        /// <summary>
        /// Gets or sets the ImSource which is displayed next to the field
        /// </summary>
        public String PlayChoiceImSource
        {
            get { return (String)GetValue(ImSourceProperty); }
            set { SetValue(ImSourceProperty, value); }
        }
        /// <summary>
        /// Identified the ImSource dependency property
        /// </summary>
        public static readonly DependencyProperty ImSourceProperty =
                DependencyProperty.Register("PlayChoiceImSource", typeof(string),
                typeof(ButtonSoft), new PropertyMetadata(""));

        /// <summary>
        /// Gets or sets the Label which is displayed next to the field
        /// </summary>
        public String PlayChoiceTitle
        {
            get { return (String)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("PlayChoiceTitle", typeof(string),
              typeof(ButtonSoft), new PropertyMetadata("Titre de test"));


        public PlayChoice()
        {
            InitializeComponent();
        }
    }
}
