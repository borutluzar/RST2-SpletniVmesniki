using BlazorProject.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorProject.Client.Services
{
    abstract class EntitiesService<T, Id_Type> : IEntityCRUDService<T, Id_Type>
    {
        private readonly HttpClient _client;
        protected virtual string ApiPath { get; set; }
        public virtual List<T> Entities { get; set; }

        public EntitiesService(HttpClient client)
        {
            this._client = client;
        }

        public virtual event Action OnChange;

        public virtual async Task<List<T>> GetEntities()
        {
            Entities = await _client.GetFromJsonAsync<List<T>>(ApiPath); 
            return Entities;
        }

        public virtual async Task<T> GetEntity(Id_Type id)
        {
            return await _client.GetFromJsonAsync<T>($"{ApiPath}/{id}");
        }

        public virtual async Task CreateEntity(T entity)
        {
            await _client.PostAsJsonAsync(ApiPath, entity);
        }

        public virtual async Task UpdateEntity(T entity, Id_Type id)
        {
            await _client.PutAsJsonAsync($"{ApiPath}/{id}", entity);
        }

        public virtual async Task<HttpResponseMessage> DeleteEntity(Id_Type id)
        {
            var result = await _client.DeleteAsync($"{ApiPath}/{id}");
            Entities = await GetEntities();
            OnChange.Invoke();
            return result;
        }
    }
}
