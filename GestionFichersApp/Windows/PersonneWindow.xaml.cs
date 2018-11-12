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
    /// Logique d'interaction pour PersonneWindow.xaml
    /// </summary>
    public partial class PersonneWindow : Window
    {
        public PersonneWindow(Databases.Personne PersonneModif = null)
        {
            InitializeComponent();
            DataContext = PersonneModif == null ? new Databases.Personne() : PersonneModif;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            bool isErrors = false;

            if (string.IsNullOrWhiteSpace(TextBoxMotDePasse.Text))
            {
                isErrors = true;
                this.TextBoxMotDePasse.Background = Brushes.Red;
                this.TextBlockMotDePasse.Foreground = Brushes.Red;
            }
            else
            {
                this.TextBoxMotDePasse.Background = Brushes.Green;
                this.TextBlockMotDePasse.Foreground = Brushes.Green;
            }

            if (string.IsNullOrWhiteSpace(TextBoxNom.Text))
            {
                isErrors = true;
                this.TextBoxNom.Background = Brushes.Red;
                this.TextBlockNom.Foreground = Brushes.Red;
            }
            else
            {
                this.TextBoxNom.Background = Brushes.Green;
                this.TextBlockNom.Foreground = Brushes.Green;
            }

            if (string.IsNullOrWhiteSpace(TextBoxPrenom.Text))
            {
                isErrors = true;
                this.TextBoxPrenom.Background = Brushes.Red;
                this.TextBlockPrenom.Foreground = Brushes.Red;
            }
            else
            {
                this.TextBoxPrenom.Background = Brushes.Green;
                this.TextBlockPrenom.Foreground = Brushes.Green;
            }

            if (string.IsNullOrWhiteSpace(TextBoxUserLogin.Text))
            {
                isErrors = true;
                this.TextBoxUserLogin.Background = Brushes.Red;
                this.TextBlockUserLogin.Foreground = Brushes.Red;
            }
            else
            {
                this.TextBoxUserLogin.Background = Brushes.Green;
                this.TextBlockUserLogin.Foreground = Brushes.Green;
            }

            if (!DPDate.SelectedDate.HasValue)
            {
                isErrors = true;
                this.DPDate.Background = Brushes.Red;
                this.TextBlockDate.Foreground = Brushes.Red;
            }
            else
            {
                this.DPDate.Background = Brushes.Green;
                this.TextBlockDate.Foreground = Brushes.Green;
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
