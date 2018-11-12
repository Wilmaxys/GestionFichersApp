using GestionFichersApp.Interfaces;
using GestionFichersApp.Windows;
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

namespace GestionFichersApp.UserControls
{
    /// <summary>
    /// Logique d'interaction pour PersonneUserControl.xaml
    /// </summary>
    public partial class PersonneUserControl : UserControl, ICrud
    {
        public PersonneUserControl()
        {
            InitializeComponent();
            LoadOrReloadData();
        }

        #region Functions
        public void LoadOrReloadData()
        {
            this.DataGridContenuPersonne.ItemsSource = Databases.GestionFichersDatabase.Current.Personne.ToList();
            this.DataGridContenuPersonne.Items.Refresh();
        }
        #endregion

        #region Implemented func
        public void Create()
        {
            PersonneWindow window = new PersonneWindow();
            window.ShowDialog();
            if (window.DialogResult.HasValue && window.DialogResult.Value == true)
            {
                Databases.Personne objectToAdd = window.DataContext as Databases.Personne;

                Databases.GestionFichersDatabase.Current.Personne.Add(objectToAdd);
                try
                {
                    Databases.GestionFichersDatabase.Current.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Erreur lors de la sauvegarde");
                }

                LoadOrReloadData();
            }
            else
            {
                Databases.GestionFichersDatabase.ReinitializeDatabase();
            }
        }

        public void Delete()
        {
            if (DataGridContenuPersonne.SelectedItems != null && DataGridContenuPersonne.SelectedItems.Count == 1)
            {
                Databases.Personne TypeASupprimer = DataGridContenuPersonne.SelectedItem as Databases.Personne;

                if (MessageBox.Show("Etes vous sur de vouloir supprimer ?", "Supp", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Databases.GestionFichersDatabase.Current.Personne.Remove(TypeASupprimer);
                    try
                    {
                        Databases.GestionFichersDatabase.Current.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("La supp a raté");
                        Databases.GestionFichersDatabase.ReinitializeDatabase();
                    }
                    LoadOrReloadData();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un et un seul élément.");
            }
        }

        public void Update()
        {
            if (DataGridContenuPersonne.SelectedItems != null && DataGridContenuPersonne.SelectedItems.Count == 1)
            {
                Databases.Personne TypeAEditer = DataGridContenuPersonne.SelectedItem as Databases.Personne;
                PersonneWindow fenetre = new PersonneWindow(TypeAEditer);
                fenetre.ShowDialog();
                if (fenetre.DialogResult.HasValue && fenetre.DialogResult.Value == true)
                {
                    try
                    {
                        Databases.GestionFichersDatabase.Current.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Err dans la modif");
                        Databases.GestionFichersDatabase.ReinitializeDatabase();
                        throw;
                    }
                }
                else
                {
                    Databases.GestionFichersDatabase.ReinitializeDatabase();
                }
                LoadOrReloadData();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un et un seul élément.");
            }
        }
        #endregion

        private void DataGridContenuPersonne_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Update();
        }

        private void DataGridContenuPersonne_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                if (DataGridContenuPersonne.SelectedItems != null && DataGridContenuPersonne.SelectedItems.Count == 1)
                {
                    Databases.Personne TypeASupprimer = DataGridContenuPersonne.SelectedItem as Databases.Personne;

                    if (MessageBox.Show("Etes vous sur de vouloir supprimer ?", "Supp", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        Databases.GestionFichersDatabase.Current.Personne.Remove(TypeASupprimer);
                        try
                        {
                            Databases.GestionFichersDatabase.Current.SaveChanges();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("La supp a raté");
                            Databases.GestionFichersDatabase.ReinitializeDatabase();
                        }
                        LoadOrReloadData();
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner un et un seul élément.");
                }
            }

        }
    }
}
