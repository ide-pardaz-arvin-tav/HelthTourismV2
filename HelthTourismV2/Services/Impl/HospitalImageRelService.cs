using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class HospitalImageRelService : IHospitalImageRelService
    {
        public TblHospitalImageRel AddHospitalImageRel(TblHospitalImageRel hospitalImageRel)
        {
            return new HospitalImageRelRepo().AddHospitalImageRel(hospitalImageRel);
        }
        public bool DeleteHospitalImageRel(int id)
        {
            return new HospitalImageRelRepo().DeleteHospitalImageRel(id);
        }
        public bool UpdateHospitalImageRel(TblHospitalImageRel hospitalImageRel, int logId)
        {
            return new HospitalImageRelRepo().UpdateHospitalImageRel(hospitalImageRel, logId);
        }
        public List<TblHospitalImageRel> SelectAllHospitalImageRels()
        {
            return new HospitalImageRelRepo().SelectAllHospitalImageRels();
        }
        public TblHospitalImageRel SelectHospitalImageRelById(int id)
        {
            return (TblHospitalImageRel)new HospitalImageRelRepo().SelectHospitalImageRelById(id);
        }
        public List<TblHospitalImageRel> SelectHospitalImageRelByHospitalId(int hospitalId)
        {
            return new HospitalImageRelRepo().SelectHospitalImageRelByHospitalId(hospitalId);
        }
        public List<TblHospitalImageRel> SelectHospitalImageRelByImageId(int imageId)
        {
            return new HospitalImageRelRepo().SelectHospitalImageRelByImageId(imageId);
        }

    }
}