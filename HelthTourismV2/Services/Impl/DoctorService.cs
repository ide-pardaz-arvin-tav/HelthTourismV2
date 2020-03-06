using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class DoctorService : IDoctorService
    {
        public TblDoctor AddDoctor(TblDoctor doctor)
        {
            return new DoctorRepo().AddDoctor(doctor);
        }
        public bool DeleteDoctor(int id)
        {
            return new DoctorRepo().DeleteDoctor(id);
        }
        public bool UpdateDoctor(TblDoctor doctor, int logId)
        {
            return new DoctorRepo().UpdateDoctor(doctor, logId);
        }
        public List<TblDoctor> SelectAllDoctors()
        {
            return new DoctorRepo().SelectAllDoctors();
        }
        public TblDoctor SelectDoctorById(int id)
        {
            return (TblDoctor)new DoctorRepo().SelectDoctorById(id);
        }
        public TblDoctor SelectDoctorByName(string name)
        {
            return new DoctorRepo().SelectDoctorByName(name);
        }
        public List<TblDoctor> SelectDoctorBySectionId(int sectionId)
        {
            return new DoctorRepo().SelectDoctorBySectionId(sectionId);
        }
        public List<TblDoctor> SelectDoctorByNowActive(bool nowActive)
        {
            return new DoctorRepo().SelectDoctorByNowActive(nowActive);
        }

    }
}