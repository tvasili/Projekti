using MyUniversity.Data;
using MyUniversity.Data.Models;
using MyUniversity.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyUniversity.Data.Services
{
    public class UniversitiesService1 : IUniversitiesService
    {
        private AppDbContext _dbContext;
        public UniversitiesService1(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<University>> GetAllUniversitiesAsync()
        {
            var allUniversities = await _dbContext.Universities.ToListAsync();
            return allUniversities;
        }

        public async Task<University> GetUniversityByIdAsync(int id)
        {
            var universityFromDb = await _dbContext.Universities.FirstOrDefaultAsync(x => x.Id == id);
            return universityFromDb;
        }

        public async Task AddUniversityAsync(UniversityVM university)
        {
            var newUniversity = new University()
            {
                Rate = university.Rate,
                Name = university.Name,
                Description = university.Description,
                Location = university.Location,
                Address = university.Address,
                DateCreated = university.DateCreated
            };

            await _dbContext.Universities.AddAsync(newUniversity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<University> UpdateUniversityAsync(int id, UniversityVM university)
        {
            var universityFromDb = await _dbContext.Universities.FirstOrDefaultAsync(x => x.Id == id);

            if (universityFromDb != null)
            {
                universityFromDb.Rate = university.Rate;
                universityFromDb.Name = university.Name;
                universityFromDb.Description = university.Description;
                universityFromDb.Location = university.Location;
                universityFromDb.Address = university.Address;
                universityFromDb.DateCreated = university.DateCreated;

                await _dbContext.SaveChangesAsync();
            }

            return universityFromDb;
        }

        public async Task DeleteUniversityByIdAsync(int id)
        {
            var universityFromDb = await _dbContext.Universities.FirstOrDefaultAsync(x => x.Id == id);

            if (universityFromDb != null)
            {
                _dbContext.Universities.Remove(universityFromDb);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

