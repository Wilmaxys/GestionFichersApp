using GestionFichersApp.Interfaces;
using GestionFichersApp.UserControls;
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

namespace GestionFichersApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BoutonQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButonModuleType_Click(object sender, RoutedEventArgs e)
        {
            if (this.GridContent.Children.Count != 0)
            {
                if(this.GridContent.Children.OfType<ICrud>().First() is TypeUserControl)
                {
                    return;
                }
            }
            this.GridContent.Children.Clear();
            this.GridContent.Children.Add(new TypeUserControl());
        }

        private void ButtonModulepersonne_Click(object sender, RoutedEventArgs e)
        {
            if (this.GridContent.Children.Count != 0)
            {
                if (this.GridContent.Children.OfType<ICrud>().First() is PersonneUserControl)
                {
                    return;
                }
            }
            this.GridContent.Children.Clear();
            this.GridContent.Children.Add(new PersonneUserControl());
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            // On vérifie qu'il y a bien un module dans la zone
            if (this.GridContent.Children.Count != 0)
            {
                // On vérifier qu'il est de type ICrud
                if (this.GridContent.Children.OfType<ICrud>().Any())
                {
                    // On appelle la fonction associée sur ce module, On prend le premier car nous n'en avons qu'un seul à la fois.
                    this.GridContent.Children.OfType<ICrud>().First().Create();
                }
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (this.GridContent.Children.Count != 0)
            {
                // On vérifier qu'il est de type ICrud
                if (this.GridContent.Children.OfType<ICrud>().Any())
                {
                    // On appelle la fonction associée sur ce module, On prend le premier car nous n'en avons qu'un seul à la fois.
                    this.GridContent.Children.OfType<ICrud>().First().Update();
                }
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.GridContent.Children.Count != 0)
            {
                // On vérifier qu'il est de type ICrud
                if (this.GridContent.Children.OfType<ICrud>().Any())
                {
                    // On appelle la fonction associée sur ce module, On prend le premier car nous n'en avons qu'un seul à la fois.
                    this.GridContent.Children.OfType<ICrud>().First().Delete();
                }
            }
        }


    }
}
