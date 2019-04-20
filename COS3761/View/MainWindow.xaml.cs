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

namespace COS3761.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SymbolListBox.Items.Add(ProvisionPropositionalSymbol());
        }

        private PropositionalSymbol ProvisionPropositionalSymbol()
        {
            return new PropositionalSymbol(UpdateSymbolListBox);
        }

        private bool UpdateSymbolListBox(PropositionalSymbol symbol)
        {
            if (symbol == null)
            {
                throw new ArgumentNullException(nameof(symbol));
            }
            else if (symbol.Deleted)
            {
                SymbolListBox.Items.Remove(symbol);
            }
            else if (!symbol.Editable && SymbolListBox.Items.IndexOf(symbol) == SymbolListBox.Items.Count - 1)
            {
                SymbolListBox.Items.Add(ProvisionPropositionalSymbol());
            }
            return true;
        }
    }
}
