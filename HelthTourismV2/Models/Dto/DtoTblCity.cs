using System.Net;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Models.Dto
{
    public class DtoTblCity
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public DtoTblCity(TblCity city, HttpStatusCode statusEffect)
        {
            id = city.id;
            Name = city.Name;
            CountryId = city.CountryId;

            StatusEffect = statusEffect;
        }

        public DtoTblCity()
        {
        }
    }
}