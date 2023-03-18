using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using CRUD_WPF_FORM.Models;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace CRUD_WPF_FORM.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;
        private readonly string _baseAddress;

        public ApiService(string baseAddress)
        {
            _client = new HttpClient();
            _baseAddress = baseAddress;
            _client.BaseAddress = new Uri(_baseAddress);
        }

        public async Task<List<ContactModel>> GetAllContactsAsync()
        {
            List<ContactModel> result = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync("api/contacts");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ResponseModel<List<ContactModel>>>(content).Result;
                }
            }
            catch 
            {
                Console.WriteLine($"Ocorreu um erro ao obter a lista de contatos");
            }

            return result;
        }

        public async Task<bool> InsertContactAsync(ContactModel contact)
        {
            try
            {
                string json = JsonConvert.SerializeObject(contact);
                HttpResponseMessage response = await _client.PostAsync("api/new-contact", new StringContent(json, Encoding.UTF8, "application/json"));

                return response.IsSuccessStatusCode;
            }
            catch 
            {
                Console.WriteLine($"Ocorreu um erro ao inserir o contato {contact.Name} {contact.LastName}");
                return false;
            }
        }

        public async Task<bool> UpdateContactAsync(ContactModel contact)
        {
            try
            {
                string json = JsonConvert.SerializeObject(contact);
                HttpResponseMessage response = await _client.PutAsync($"api/update-contact", new StringContent(json, Encoding.UTF8, "application/json"));

                return response.IsSuccessStatusCode;
            }
            catch 
            {
                Console.WriteLine($"Ocorreu um erro ao atualizar o contato {contact.Id}");
                return false;
            }
        }

        public async Task<bool> DeleteContactAsync(Guid id)
        {
            try
            {
                HttpResponseMessage response = await _client.DeleteAsync($"api/delete-contact/{id}");

                return response.IsSuccessStatusCode;
            }
            catch 
            {
                Console.WriteLine($"Ocorreu um erro ao excluir o contato com ID {id}");
                return false;
            }
        }
    }
}
