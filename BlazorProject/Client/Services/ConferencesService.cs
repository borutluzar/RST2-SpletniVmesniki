using BlazorProject.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorProject.Client.Services
{
    class ConferencesService : EntitiesService<Conference, Guid>
    {
        public ConferencesService(HttpClient client) : base(client) 
        {
            this.ApiPath = "api/conferences";
        }
    }
}
