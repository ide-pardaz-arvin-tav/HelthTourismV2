using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface ICountryRepo
    {
        TblCountry AddCountry(TblCountry country);
        bool DeleteCountry(int id);
        bool UpdateCountry(TblCountry country, int logId);
        List<TblCountry> SelectAllCountrys();
        TblCountry SelectCountryById(int id);
        TblCountry SelectCountryByName(string name);

    }
}