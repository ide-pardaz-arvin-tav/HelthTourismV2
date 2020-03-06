using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class HospitalSectionRelRepo : IHospitalSectionRelRepo
    {
        public TblHospitalSectionRel AddHospitalSectionRel(TblHospitalSectionRel hospitalSectionRel)
        {
            return (TblHospitalSectionRel) new MainProvider().Add(hospitalSectionRel);
        }
        public bool DeleteHospitalSectionRel(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblHospitalSectionRel, id);
        }
        public bool UpdateHospitalSectionRel(TblHospitalSectionRel hospitalSectionRel, int logId)
        {
            return new MainProvider().Update(hospitalSectionRel, logId);
        }
        public List<TblHospitalSectionRel> SelectAllHospitalSectionRels()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblHospitalSectionRel).Cast<TblHospitalSectionRel>().ToList();
        }
        public TblHospitalSectionRel SelectHospitalSectionRelById(int id)
        {
            return (TblHospitalSectionRel)new MainProvider().SelectById(MainProvider.Tables.TblHospitalSectionRel, id);
        }
        public List<TblHospitalSectionRel> SelectHospitalSectionRelByHospitalId(int hospitalId)
        {
            return new MainProvider().SelectHospitalSectionRel(hospitalId, MainProvider.HospitalSectionRel.HospitalId);
        }
        public List<TblHospitalSectionRel> SelectHospitalSectionRelBySectionId(int sectionId)
        {
            return new MainProvider().SelectHospitalSectionRel(sectionId, MainProvider.HospitalSectionRel.SectionId);
        }
        public List<TblHospitalSectionRel> SelectHospitalSectionRelByDoctorId(int doctorId)
        {
            return new MainProvider().SelectHospitalSectionRel(doctorId, MainProvider.HospitalSectionRel.DoctorId);
        }

    }
}