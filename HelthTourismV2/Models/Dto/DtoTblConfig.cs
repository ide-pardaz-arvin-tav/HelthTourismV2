using System.Net;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Models.Dto
{
    public class DtoTblConfig
    {
        public int id { get; set; }
        public string JwtKey { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public DtoTblConfig(TblConfig config, HttpStatusCode statusEffect)
        {
            id = config.id;
            JwtKey = config.JwtKey;

            StatusEffect = statusEffect;
        }

        public DtoTblConfig()
        {
        }
    }
}