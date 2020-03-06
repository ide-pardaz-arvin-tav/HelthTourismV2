using System.Net;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Models.Dto
{
    public class DtoTblCountry
    {
        public int id { get; set; }
        public string Name { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public DtoTblCountry(TblCountry country, HttpStatusCode statusEffect)
        {
            id = country.id;
            Name = country.Name;

            StatusEffect = statusEffect;
        }

        public DtoTblCountry()
        {
        }
    }
}