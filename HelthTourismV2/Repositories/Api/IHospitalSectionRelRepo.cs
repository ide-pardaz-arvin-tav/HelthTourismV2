using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface IHospitalSectionRelRepo
    {
        TblHospitalSectionRel AddHospitalSectionRel(TblHospitalSectionRel hospitalSectionRel);
        bool DeleteHospitalSectionRel(int id);
        bool UpdateHospitalSectionRel(TblHospitalSectionRel hospitalSectionRel, int logId);
        List<TblHospitalSectionRel> SelectAllHospitalSectionRels();
        TblHospitalSectionRel SelectHospitalSectionRelById(int id);
        List<TblHospitalSectionRel> SelectHospitalSectionRelByHospitalId(int hospitalId);
        List<TblHospitalSectionRel> SelectHospitalSectionRelBySectionId(int sectionId);
        List<TblHospitalSectionRel> SelectHospitalSectionRelByDoctorId(int doctorId);

    }
}