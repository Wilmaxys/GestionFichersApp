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
using System.Windows.Shapes;

namespace GestionFichersApp.Windows
{
    /// <summary>
    /// Logique d'interaction pour TypeWindow.xaml
    /// </summary>
    public partial class TypeWindow : Window
    {
        public TypeWindow(Databases.Type typeAModifier = null)
        {
            InitializeComponent();
            DataContext = typeAModifier == null ? new Databases.Type() : typeAModifier;
        }


        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            bool isErrors = false;

            if (string.IsNullOrWhiteSpace(TextBoxLabel.Text))
            {
                isErrors = true;
                this.TextBoxLabel.Background = Brushes.Red;
                this.TextBlockLabel.Foreground = Brushes.Red;
            }
            else
            {
                this.TextBoxLabel.Background = Brushes.Green;
                this.TextBlockLabel.Foreground = Brushes.Green;
            }

            if (!isErrors)
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
