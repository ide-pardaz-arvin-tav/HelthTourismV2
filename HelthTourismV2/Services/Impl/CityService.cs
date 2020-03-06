using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class CityService : ICityService
    {
        public TblCity AddCity(TblCity city)
        {
            return new CityRepo().AddCity(city);
        }

        public bool DeleteCity(int id)
        {
            return new CityRepo().DeleteCity(id);
        }

        public bool UpdateCity(TblCity city, int logId)
        {
            return new CityRepo().UpdateCity(city, logId);
        }

        public List<TblCity> SelectAllCitys()
        {
            return new CityRepo().SelectAllCitys();
        }

        public TblCity SelectCityById(int id)
        {
            return (TblCity)new CityRepo().SelectCityById(id);
        }

        public TblCity SelectCityByName(string name)
        {
            return new CityRepo().SelectCityByName(name);
        }

        public List<TblCity> SelectCityByCountryId(int countryId)
        {
            return new CityRepo().SelectCityByCountryId(countryId);
        }
    }
}