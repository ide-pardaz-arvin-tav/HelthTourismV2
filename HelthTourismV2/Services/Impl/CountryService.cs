using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class CountryService : ICountryService
    {
        public TblCountry AddCountry(TblCountry country)
        {
            return new CountryRepo().AddCountry(country);
        }
        public bool DeleteCountry(int id)
        {
            return new CountryRepo().DeleteCountry(id);
        }
        public bool UpdateCountry(TblCountry country, int logId)
        {
            return new CountryRepo().UpdateCountry(country, logId);
        }
        public List<TblCountry> SelectAllCountrys()
        {
            return new CountryRepo().SelectAllCountrys();
        }
        public TblCountry SelectCountryById(int id)
        {
            return (TblCountry)new CountryRepo().SelectCountryById(id);
        }
        public TblCountry SelectCountryByName(string name)
        {
            return new CountryRepo().SelectCountryByName(name);
        }

    }
}