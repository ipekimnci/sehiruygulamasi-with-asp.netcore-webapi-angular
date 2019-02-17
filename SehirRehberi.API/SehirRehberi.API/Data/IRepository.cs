using SehirRehberi.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Data
{
    public interface IRepository
    {
        void Insert<T>(T entity) where T:class;

        bool SaveAll();

        List<City> GetCities();

        List<Photo> GetPhotosByCity(int cityId);

        City GetCityById(int cityId);

        Photo GetPhoto(int id);

        void Delete<T>(T entity) where T : class;
    }
}
