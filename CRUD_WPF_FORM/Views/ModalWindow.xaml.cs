using CRUD_WPF_FORM.Models;
using CRUD_WPF_FORM.Services;
using System;
using System.Configuration;
using System.Windows;
using static CRUD_WPF_FORM.ViewModels.MainWindowModel;

namespace CRUD_WPF_FORM.Views
{
    /// <summary>
    /// Lógica interna para ModalWindow.xaml
    /// </summary>
    public partial class ModalWindow : Window
    {
        private ApiService _apiService;

        private ContactModel _contact { get; set; }

        private Operation _operation { get; set; }

        public ModalWindow(Operation operation)
        {
            InitializeComponent();

            _operation = operation;

            _contact = new ContactModel();

            _apiService = new ApiService(ConfigurationManager.AppSettings["ApiBaseAddress"]);

            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        public ModalWindow(Operation operation, ContactModel contactModel)
        {
            InitializeComponent();

            _contact = contactModel;

            _operation = operation;

            _apiService = new ApiService(ConfigurationManager.AppSettings["ApiBaseAddress"]);

            nameTextBox.Text = _contact.Name;
            lastNameTextBox.Text = _contact.LastName;
            phoneTextBox.Text = _contact.Phone;

            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }


        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (_operation == Operation.Insert)
                {
                    ContactModel contactModel = new()
                    {
                        Id = Guid.NewGuid(),
                        Name = nameTextBox.Text,
                        LastName = lastNameTextBox.Text,
                        Phone = phoneTextBox.Text
                    };

                    await _apiService.InsertContactAsync(contactModel);
                }
                else if (_operation == Operation.Update)
                {
                    ContactModel contactModel = new()
                    {
                        Id = _contact.Id,
                        Name = nameTextBox.Text,
                        LastName = lastNameTextBox.Text,
                        Phone = phoneTextBox.Text
                    };

                    await _apiService.UpdateContactAsync(contactModel);
                }
                else
                {
                    MessageBox.Show(Application.Current.MainWindow, "Erro ou salvar inserção ou atualização", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    DialogResult = false;
                }

                DialogResult = true;
            }
            catch
            {
                MessageBox.Show(Application.Current.MainWindow, "Erro ou salvar inserção ou atualização", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                DialogResult = false;
            }
        }
    }
}
