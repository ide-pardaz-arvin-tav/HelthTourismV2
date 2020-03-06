using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class HospitalSectionRelService : IHospitalSectionRelService
    {
        public TblHospitalSectionRel AddHospitalSectionRel(TblHospitalSectionRel hospitalSectionRel)
        {
            return new HospitalSectionRelRepo().AddHospitalSectionRel(hospitalSectionRel);
        }
        public bool DeleteHospitalSectionRel(int id)
        {
            return new HospitalSectionRelRepo().DeleteHospitalSectionRel(id);
        }
        public bool UpdateHospitalSectionRel(TblHospitalSectionRel hospitalSectionRel, int logId)
        {
            return new HospitalSectionRelRepo().UpdateHospitalSectionRel(hospitalSectionRel, logId);
        }
        public List<TblHospitalSectionRel> SelectAllHospitalSectionRels()
        {
            return new HospitalSectionRelRepo().SelectAllHospitalSectionRels();
        }
        public TblHospitalSectionRel SelectHospitalSectionRelById(int id)
        {
            return (TblHospitalSectionRel)new HospitalSectionRelRepo().SelectHospitalSectionRelById(id);
        }
        public List<TblHospitalSectionRel> SelectHospitalSectionRelByHospitalId(int hospitalId)
        {
            return new HospitalSectionRelRepo().SelectHospitalSectionRelByHospitalId(hospitalId);
        }
        public List<TblHospitalSectionRel> SelectHospitalSectionRelBySectionId(int sectionId)
        {
            return new HospitalSectionRelRepo().SelectHospitalSectionRelBySectionId(sectionId);
        }
        public List<TblHospitalSectionRel> SelectHospitalSectionRelByDoctorId(int doctorId)
        {
            return new HospitalSectionRelRepo().SelectHospitalSectionRelByDoctorId(doctorId);
        }

    }
}