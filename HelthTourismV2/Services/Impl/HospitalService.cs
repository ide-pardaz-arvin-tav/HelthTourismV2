using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class HospitalService : IHospitalService
    {
        public TblHospital AddHospital(TblHospital hospital)
        {
            return new HospitalRepo().AddHospital(hospital);
        }
        public bool DeleteHospital(int id)
        {
            return new HospitalRepo().DeleteHospital(id);
        }
        public bool UpdateHospital(TblHospital hospital, int logId)
        {
            return new HospitalRepo().UpdateHospital(hospital, logId);
        }
        public List<TblHospital> SelectAllHospitals()
        {
            return new HospitalRepo().SelectAllHospitals();
        }
        public TblHospital SelectHospitalById(int id)
        {
            return (TblHospital)new HospitalRepo().SelectHospitalById(id);
        }
        public TblHospital SelectHospitalByName(string name)
        {
            return new HospitalRepo().SelectHospitalByName(name);
        }
        public List<TblHospital> SelectHospitalByUserPassId(int userPassId)
        {
            return new HospitalRepo().SelectHospitalByUserPassId(userPassId);
        }
        public List<TblImage> SelectImagesByHospitalId(int hospitalId)
        {
            List<TblHospitalImageRel> stp1 = new HospitalImageRelRepo().SelectHospitalImageRelByHospitalId(hospitalId);
            List<TblImage> stp2 = new List<TblImage>();
            foreach (TblHospitalImageRel rel in stp1)
                stp2.Add(new ImageRepo().SelectImageById(rel.ImageId));
            return stp2;
        }
        public List<TblSection> SelectSectionsByHospitalId(int hospitalId)
        {
            List<TblHospitalSectionRel> stp1 = new HospitalSectionRelRepo().SelectHospitalSectionRelByHospitalId(hospitalId);
            List<TblSection> stp2 = new List<TblSection>();
            foreach (TblHospitalSectionRel rel in stp1)
                stp2.Add(new SectionRepo().SelectSectionById(rel.SectionId));
            return stp2;
        }
    }
}