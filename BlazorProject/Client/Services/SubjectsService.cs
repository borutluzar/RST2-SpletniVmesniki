using BlazorProject.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorProject.Client.Services
{
    class SubjectsService : ISubjectsService
    {
        private readonly HttpClient _client;
        public List<Subject> Subjects { get; set; }

        public SubjectsService(HttpClient client)
        {
            this._client = client; 
        }

        public event Action OnChange;

        public async Task<List<Subject>> GetSubjects()
        {
            Subjects = await _client.GetFromJsonAsync<List<Subject>>("api/subjects"); 
            return Subjects;
        }

        public async Task<Subject> GetSubject(int id)
        {
            return await _client.GetFromJsonAsync<Subject>($"api/subjects/{id}");
        }

        public async Task CreateSubject(Subject subject)
        {
            await _client.PostAsJsonAsync<Subject>($"api/subjects", subject);
        }

        public async Task UpdateSubject(Subject subject, int id)
        {
            await _client.PutAsJsonAsync<Subject>($"api/subjects/{id}", subject);
        }

        public async Task<HttpResponseMessage> DeleteSubject(int id)
        {
            var result = await _client.DeleteAsync($"api/subjects/{id}");
            Subjects = await GetSubjects();
            OnChange.Invoke();
            return result;
        }
    }
}
