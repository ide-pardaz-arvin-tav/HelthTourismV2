using System.Net;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Models.Dto
{
    public class DtoTblNews
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string MainData { get; set; }
        public string MainDataRtf { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public DtoTblNews(TblNews news, HttpStatusCode statusEffect)
        {
            id = news.id;
            Title = news.Title;
            MainData = news.MainData;
            MainDataRtf = news.MainDataRtf;

            StatusEffect = statusEffect;
        }

        public DtoTblNews()
        {
        }
    }
}