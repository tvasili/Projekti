using MyUniversity.Data.Models;
using MyUniversity.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyUniversity.Data.Services
{
    public interface IUniversitiesService
    {
        Task<List<University>> GetAllUniversitiesAsync();
        Task<University> GetUniversityByIdAsync(int id);
        Task AddUniversityAsync(UniversityVM university);
        Task<University> UpdateUniversityAsync(int id, UniversityVM university);
        Task DeleteUniversityByIdAsync(int id);
    }
}

