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

        public async Task<List<Subject>> CreateSubject(Subject subject)
        {
            var result = await _client.PostAsJsonAsync<Subject>($"api/subjects", subject);
            Subjects = await result.Content.ReadFromJsonAsync<List<Subject>>();
            OnChange.Invoke();
            return Subjects;
        }
    }
}
