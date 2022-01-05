using BlazorProject.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Client.Services
{
    interface ISubjectsService
    {
        Task<List<Subject>> GetSubjects();

        Task<Subject> GetSubject(int id);

        Task<List<Subject>> CreateSubject(Subject subject);

        List<Subject> Subjects { get; set; }

        event Action OnChange;
    }
}
