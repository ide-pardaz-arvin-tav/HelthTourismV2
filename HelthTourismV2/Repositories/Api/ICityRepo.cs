using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface ICityRepo
    { 
        TblCity AddCity(TblCity city);
        bool DeleteCity(int id);
        bool UpdateCity(TblCity city, int logId);
        List<TblCity> SelectAllCitys();
        TblCity SelectCityById(int id);
        TblCity SelectCityByName(string name);
        List<TblCity> SelectCityByCountryId(int countryId);

    }
}