using CRUD_WPF_FORM.Models;
using CRUD_WPF_FORM.Services;
using CRUD_WPF_FORM.Views;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using static CRUD_WPF_FORM.ViewModels.MainWindowModel;

namespace CRUD_WPF_FORM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApiService _apiService;

        public MainWindow()
        {
            InitializeComponent();

            _apiService = new ApiService(ConfigurationManager.AppSettings["ApiBaseAddress"]);

            LoadContacts();
        }

        private async void LoadContacts()
        {
            try
            {
                List<ContactModel> contacts = await _apiService.GetAllContactsAsync();

                contactDataGrid.ItemsSource = contacts;

                if (contacts.Count == 0)
                {
                    noDataTextBlock.Visibility = Visibility.Visible;
                }
                else
                {
                    noDataTextBlock.Visibility = Visibility.Collapsed;
                }
            }
            catch
            {
                MessageBox.Show(Application.Current.MainWindow, "Não foi possível buscar a lista de contatos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            var modal = new ModalWindow(operation: Operation.Insert)
            {
                Owner = this,
            };

            bool? result = modal.ShowDialog();

            if (result.HasValue && result.Value)
            {
                LoadContacts();

                MessageBox.Show(Application.Current.MainWindow, "Contato criado com sucesso", "Sucess", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Button deleteButton = sender as Button;

            ContactModel contact = deleteButton.DataContext as ContactModel;

            var modal = new ModalWindow(operation: Operation.Update, contact)
            {
                Owner = this,
            };

            bool? result = modal.ShowDialog();

            if (result.HasValue && result.Value)
            {
                LoadContacts();

                MessageBox.Show(Application.Current.MainWindow, "Contato atualizado com sucesso", "Sucess", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button deleteButton = sender as Button;

            ContactModel contact = deleteButton.DataContext as ContactModel;

            try
            {
                var result = await _apiService.DeleteContactAsync(contact.Id);

                if (result)
                {
                    MessageBox.Show(Application.Current.MainWindow, "Contato deletado com sucesso", "Sucess", MessageBoxButton.OK, MessageBoxImage.Information);

                    LoadContacts();
                }
                else
                {
                    MessageBox.Show(Application.Current.MainWindow, "Não foi possível deletar o contato", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show(Application.Current.MainWindow, "Não foi possível deletar o contato", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
