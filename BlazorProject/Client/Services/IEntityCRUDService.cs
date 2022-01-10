using BlazorProject.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorProject.Client.Services
{
    interface IEntityCRUDService<T,Id_Type>
    {
        Task<List<T>> GetEntities();

        Task<T> GetEntity(Id_Type id);

        Task<HttpResponseMessage> DeleteEntity(Id_Type id);

        Task CreateEntity(T entity);

        Task UpdateEntity(T entity, Id_Type id);

        List<T> Entities { get; set; }

        event Action OnChange;
    }
}
