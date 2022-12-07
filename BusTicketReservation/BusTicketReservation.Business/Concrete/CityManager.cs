using BusTicketReservation.Business.Abstract;
using BusTicketReservation.Data.Abstract;
using BusTicketReservation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservation.Business.Concrete
{
    public class CityManager : ICityService
    {
        private  ICityRepository _cityRepository;

        public CityManager(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task CreateAsync(City city)
        {
           await _cityRepository.CreateAsync(city);
        }

        public void Delete(City city)
        {
            _cityRepository.Delete(city);
        }

        public async Task<List<City>> GellAllCitiesAsync(int id)
        {
            return await _cityRepository.GellAllCitiesAsync(id);
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await _cityRepository.GetAllAsync();
        }

        public async Task<City> GetByIdAsync(int id)
        {
            return await _cityRepository.GetByIdAsync(id);
        }

        public void Update(City city)
        {
             _cityRepository.Update(city);
        }
    }
}
