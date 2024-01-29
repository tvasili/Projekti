using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyUniversity.Data.Models;
using MyUniversity.Data.ViewModels;
using Swashbuckle.Swagger;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Xml.Linq;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace MyUniversity.Data.Services
{
    public class UniversitiesService
    {
        private AppDbContext _context;
        public UniversitiesService(AppDbContext context)
        {
            _context = context;
        }
        public void AddUniversity(UniversityVM uni)
        {
            var university = new University()
            {
                Rate = uni.Rate,
                Name = uni.Name,
                Description = uni.Description,
                Location = uni.Location,
                Address = uni.Address,
                DateCreated = uni.DateCreated
            };
            _context.Universities.Add(university);
            _context.SaveChanges();
        }
        public List<University> GetAllUniversities()
        {
            var allUniversities = _context.Universities.ToList();
            return allUniversities;
        }
        public University GetUniversityByid(int universityId)
        {
            var university = _context.Universities.FirstOrDefault(n => n.Id == universityId);
            return university;
        }
        public University UpdateUniversityById(int universityId, UniversityVM univm)
        {
            var university = _context.Universities.FirstOrDefault(n => n.Id == universityId);
            if (university != null)
            {
                university.Rate = university.Rate;
                university.Name = university.Name;
                university.Description = university.Description;
                university.Location = university.Location;
                university.Address = university.Address;
                university.DateCreated = university.DateCreated;
                _context.SaveChanges();
            }
            return university;
           
        }
        public void DeleteUniversityById(int universityId)
        {
            var university = _context.Universities.FirstOrDefault(n => n.Id == universityId);
            if (university != null)
            {
                _context.Universities.Remove(university);
                _context.SaveChanges();
            }
        }
    }
}
