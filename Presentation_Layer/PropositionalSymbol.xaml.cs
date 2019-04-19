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

namespace Presentation_Layer
{
    /// <summary>
    /// Interaction logic for PropositionalSymbol.xaml
    /// </summary>
    public partial class PropositionalSymbol : UserControl
    {
        public bool Deleted { get; private set; } = false;
        public bool Editable { get; private set; } = true;
        public Func<PropositionalSymbol, bool> OnChange { get; set; }

        public PropositionalSymbol(Func<PropositionalSymbol, bool> OnChange)
        {
            this.OnChange = OnChange;
            InitializeComponent();
            RefreshState();
        }

        private void RefreshState()
        {
            OnChange(this);
            SymbolTextBox.IsEnabled = MeaningTextBox.IsEnabled = Editable;
            RemoveButton.IsEnabled = !Editable;
        }

        private void AddEditButton_Click(object sender, RoutedEventArgs e)
        {
            Editable = !Editable;
            RefreshState();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Deleted = true;
            RefreshState();
        }
    }
}
