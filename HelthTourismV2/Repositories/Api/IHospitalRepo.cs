using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface IHospitalRepo
    {
        TblHospital AddHospital(TblHospital hospital);
        bool DeleteHospital(int id);
        bool UpdateHospital(TblHospital hospital, int logId);
        List<TblHospital> SelectAllHospitals();
        TblHospital SelectHospitalById(int id);
        TblHospital SelectHospitalByName(string name);
        List<TblHospital> SelectHospitalByUserPassId(int userPassId);

    }
}