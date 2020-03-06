using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class CountryRepo : ICountryRepo
    {
        public TblCountry AddCountry(TblCountry country)
        {
            return (TblCountry) new MainProvider().Add(country);
        }
        public bool DeleteCountry(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblCountry, id);
        }
        public bool UpdateCountry(TblCountry country, int logId)
        {
            return new MainProvider().Update(country, logId);
        }
        public List<TblCountry> SelectAllCountrys()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblCountry).Cast<TblCountry>().ToList();
        }
        public TblCountry SelectCountryById(int id)
        {
            return (TblCountry)new MainProvider().SelectById(MainProvider.Tables.TblCountry, id);
        }
        public TblCountry SelectCountryByName(string name)
        {
            return new MainProvider().SelectCountryByName(name);
        }

    }
}