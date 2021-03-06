﻿using GestionFichersApp.Interfaces;
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
    /// Logique d'interaction pour TypeUserControl.xaml
    /// </summary>
    public partial class TypeUserControl : UserControl, ICrud
    {
        #region Constructors
        public TypeUserControl()
        {
            InitializeComponent();
            LoadOrReloadData();
        }
        #endregion

        #region Functions
        public void LoadOrReloadData()
        {
            this.DataGridContenu.ItemsSource = Databases.GestionFichersDatabase.Current.Type.ToList();
            this.DataGridContenu.Items.Refresh();
        }
        #endregion

        #region Implemented func
        public void Create()
        {
            TypeWindow window = new TypeWindow();
            window.ShowDialog();
            if (window.DialogResult.HasValue && window.DialogResult.Value == true)
            {
                Databases.Type objectToAdd = window.DataContext as Databases.Type;

                Databases.GestionFichersDatabase.Current.Type.Add(objectToAdd);
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
            if (DataGridContenu.SelectedItems != null && DataGridContenu.SelectedItems.Count == 1)
            {
                Databases.Type TypeASupprimer = DataGridContenu.SelectedItem as Databases.Type;

                if(MessageBox.Show("Etes vous sur de vouloir supprimer ?", "Supp", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Databases.GestionFichersDatabase.Current.Type.Remove(TypeASupprimer);
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
            if (DataGridContenu.SelectedItems != null && DataGridContenu.SelectedItems.Count == 1)
            {
                Databases.Type TypeAEditer = DataGridContenu.SelectedItem as Databases.Type;
                TypeWindow fenetre = new TypeWindow(TypeAEditer);
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

    }
}
