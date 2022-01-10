using BlazorProject.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorProject.Client.Services
{
    interface ISubjectsService
    {
        Task<List<Subject>> GetSubjects();

        Task<Subject> GetSubject(int id);

        Task<HttpResponseMessage> DeleteSubject(int id);

        Task CreateSubject(Subject subject);

        Task UpdateSubject(Subject subject, int id);

        List<Subject> Subjects { get; set; }

        event Action OnChange;
    }
}
