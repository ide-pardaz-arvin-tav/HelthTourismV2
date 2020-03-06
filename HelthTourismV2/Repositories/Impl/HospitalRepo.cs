using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class HospitalRepo : IHospitalRepo
    {
        public TblHospital AddHospital(TblHospital hospital)
        {
            return (TblHospital) new MainProvider().Add(hospital);
        }
        public bool DeleteHospital(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblHospital, id);
        }
        public bool UpdateHospital(TblHospital hospital, int logId)
        {
            return new MainProvider().Update(hospital, logId);
        }
        public List<TblHospital> SelectAllHospitals()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblHospital).Cast<TblHospital>().ToList();
        }
        public TblHospital SelectHospitalById(int id)
        {
            return (TblHospital)new MainProvider().SelectById(MainProvider.Tables.TblHospital, id);
        }
        public TblHospital SelectHospitalByName(string name)
        {
            return new MainProvider().SelectHospitalByName(name);
        }
        public List<TblHospital> SelectHospitalByUserPassId(int userPassId)
        {
            return new MainProvider().SelectHospitalByUserPassId(userPassId);
        }

    }
}