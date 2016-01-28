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
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty PlayChoiceTitleProperty;
        /// <summary>
        /// Identified the ImSource dependency property
        /// </summary>
        public static readonly DependencyProperty ImSourceProperty;
        /// <summary>
        /// Identified the ImSource dependency property
        /// </summary>
        public static readonly DependencyProperty PlayChoiceDescriptionProperty;

        /// <summary>
        /// Gets or sets the ImSource which is displayed next to the field
        /// </summary>
        public BitmapImage PlayChoiceImSource
        {
            get { return (BitmapImage)GetValue(ImSourceProperty); }
            set { SetValue(ImSourceProperty, value); }
        }
        

        /// <summary>
        /// Gets or sets the Label which is displayed next to the field
        /// </summary>
        public String PlayChoiceTitle
        {
            get { return (String)GetValue(PlayChoiceTitleProperty); }
            set { SetValue(PlayChoiceTitleProperty, value); }
        }

        public String PlayChoiceDescription
        {
            get { return (String)GetValue(PlayChoiceDescriptionProperty); }
            set { SetValue(PlayChoiceDescriptionProperty, value); }
        }

       

        static PlayChoice()
        {
            PlayChoiceTitleProperty = DependencyProperty.Register("PlayChoiceTitle", 
                        typeof(string), typeof(PlayChoice), 
                        new PropertyMetadata("Titre de test"));

            PlayChoiceDescriptionProperty = DependencyProperty.Register("PlayChoiceDescription",
                        typeof(string), typeof(PlayChoice),
                        new PropertyMetadata("Description de test"));
            ImSourceProperty = DependencyProperty.Register("PlayChoiceImSource", 
                        typeof(BitmapImage),typeof(PlayChoice),
                        new PropertyMetadata());

        }


        public PlayChoice()
        {
            InitializeComponent();
        }
    }
}
