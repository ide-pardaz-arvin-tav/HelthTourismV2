using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class HospitalImageRelRepo : IHospitalImageRelRepo
    {
        public TblHospitalImageRel AddHospitalImageRel(TblHospitalImageRel hospitalImageRel)
        {
            return (TblHospitalImageRel) new MainProvider().Add(hospitalImageRel);
        }
        public bool DeleteHospitalImageRel(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblHospitalImageRel, id);
        }
        public bool UpdateHospitalImageRel(TblHospitalImageRel hospitalImageRel, int logId)
        {
            return new MainProvider().Update(hospitalImageRel, logId);
        }
        public List<TblHospitalImageRel> SelectAllHospitalImageRels()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblHospitalImageRel).Cast<TblHospitalImageRel>().ToList();
        }
        public TblHospitalImageRel SelectHospitalImageRelById(int id)
        {
            return (TblHospitalImageRel)new MainProvider().SelectById(MainProvider.Tables.TblHospitalImageRel, id);
        }
        public List<TblHospitalImageRel> SelectHospitalImageRelByHospitalId(int hospitalId)
        {
            return new MainProvider().SelectHospitalImageRel(hospitalId, MainProvider.HospitalImageRel.HospitalId);
        }
        public List<TblHospitalImageRel> SelectHospitalImageRelByImageId(int imageId)
        {
            return new MainProvider().SelectHospitalImageRel(imageId, MainProvider.HospitalImageRel.ImageId);
        }

    }
}