using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface IHospitalImageRelRepo
    {
        TblHospitalImageRel AddHospitalImageRel(TblHospitalImageRel hospitalImageRel);
        bool DeleteHospitalImageRel(int id);
        bool UpdateHospitalImageRel(TblHospitalImageRel hospitalImageRel, int logId);
        List<TblHospitalImageRel> SelectAllHospitalImageRels();
        TblHospitalImageRel SelectHospitalImageRelById(int id);
        List<TblHospitalImageRel> SelectHospitalImageRelByHospitalId(int hospitalId);
        List<TblHospitalImageRel> SelectHospitalImageRelByImageId(int imageId);

    }
}