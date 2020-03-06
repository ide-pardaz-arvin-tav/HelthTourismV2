using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class DoctorRepo : IDoctorRepo
    {
        public TblDoctor AddDoctor(TblDoctor doctor)
        {
            return (TblDoctor) new MainProvider().Add(doctor);
        }
        public bool DeleteDoctor(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblDoctor, id);
        }
        public bool UpdateDoctor(TblDoctor doctor, int logId)
        {
            return new MainProvider().Update(doctor, logId);
        }
        public List<TblDoctor> SelectAllDoctors()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblDoctor).Cast<TblDoctor>().ToList();
        }
        public TblDoctor SelectDoctorById(int id)
        {
            return (TblDoctor)new MainProvider().SelectById(MainProvider.Tables.TblDoctor, id);
        }
        public TblDoctor SelectDoctorByName(string name)
        {
            return new MainProvider().SelectDoctorByName(name);
        }
        public List<TblDoctor> SelectDoctorBySectionId(int sectionId)
        {
            return new MainProvider().SelectDoctorBySectionId(sectionId);
        }
        public List<TblDoctor> SelectDoctorByNowActive(bool nowActive)
        {
            return new MainProvider().SelectDoctorByNowActive(nowActive);
        }

    }
}