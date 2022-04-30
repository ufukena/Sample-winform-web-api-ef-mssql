using ContactList.Domain.Model;
using ContactList.Infrastructure.Win.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace ContactList.Infrastructure.Win.Repository
{
    public class ContactRepository : IContactRepository
    {

        public async Task<IEnumerable<Contact>> Get()
        {
            IEnumerable<Contact>? contactlist = null;

            using (var _httpClient = HttpClientHelper.GetClient())
            {
                HttpResponseMessage _httpResponse = await _httpClient.GetAsync($"/api/Contact/Get");               

                if (_httpResponse.IsSuccessStatusCode)
                {
                    var json = await _httpResponse.Content.ReadAsStringAsync();
                    contactlist = JsonConvert.DeserializeObject<IEnumerable<Contact>>(json);                    
                }
                else
                {
                    throw new Exception((int)_httpResponse.StatusCode + "-" + _httpResponse.StatusCode.ToString());
                }

                return contactlist;

            }

        }


        public async Task<Contact> Get(int id)
        {
            Contact contact;

            using (var _httpClient = HttpClientHelper.GetClient())
            {
                HttpResponseMessage _httpResponse = await _httpClient.GetAsync($"/api/Contact/Get/" + id);

                if (_httpResponse.IsSuccessStatusCode)
                {
                    var json = await _httpResponse.Content.ReadAsStringAsync();
                    contact = JsonConvert.DeserializeObject<Contact>(json);
                }
                else
                {
                    throw new Exception((int)_httpResponse.StatusCode + "-" + _httpResponse.StatusCode.ToString());
                }

                return contact;

            }
        }


        public async Task Insert(Contact contact)
        {

            using (var _httpClient = HttpClientHelper.GetClient())
            {
                HttpResponseMessage _httpResponse = await _httpClient.PostAsync($"/api/Contact/Insert", JsonContentHelper.CreateJsonContent(contact));

                if (!_httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception((int)_httpResponse.StatusCode + "-" + _httpResponse.StatusCode.ToString());
                }

            }

        }


        public async Task Update(Contact contact)
        {

            using (var _httpClient = HttpClientHelper.GetClient())
            {
                HttpResponseMessage _httpResponse = await _httpClient.PutAsync($"/api/Contact/Update", JsonContentHelper.CreateJsonContent(contact));

                if (!_httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception((int)_httpResponse.StatusCode + "-" + _httpResponse.StatusCode.ToString());
                }

            }

        }


        public async Task Delete(int id)
        {
            using (var _httpClient = HttpClientHelper.GetClient())
            {
                HttpResponseMessage _httpResponse = await _httpClient.DeleteAsync($"/api/Contact/Delete/" + id);

                if (!_httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception((int)_httpResponse.StatusCode + "-" + _httpResponse.StatusCode.ToString());
                }

            }

        }



    }
}
