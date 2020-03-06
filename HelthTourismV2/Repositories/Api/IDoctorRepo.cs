using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface IDoctorRepo
    {
        TblDoctor AddDoctor(TblDoctor doctor);
        bool DeleteDoctor(int id);
        bool UpdateDoctor(TblDoctor doctor, int logId);
        List<TblDoctor> SelectAllDoctors();
        TblDoctor SelectDoctorById(int id);
        TblDoctor SelectDoctorByName(string name);
        List<TblDoctor> SelectDoctorBySectionId(int sectionId);
        List<TblDoctor> SelectDoctorByNowActive(bool nowActive);

    }
}