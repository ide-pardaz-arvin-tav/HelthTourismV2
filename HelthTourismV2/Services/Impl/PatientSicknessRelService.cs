using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class PatientSicknessRelService : IPatientSicknessRelService
    {
        public TblPatientSicknessRel AddPatientSicknessRel(TblPatientSicknessRel patientSicknessRel)
        {
            return new PatientSicknessRelRepo().AddPatientSicknessRel(patientSicknessRel);
        }
        public bool DeletePatientSicknessRel(int id)
        {
            return new PatientSicknessRelRepo().DeletePatientSicknessRel(id);
        }
        public bool UpdatePatientSicknessRel(TblPatientSicknessRel patientSicknessRel, int logId)
        {
            return new PatientSicknessRelRepo().UpdatePatientSicknessRel(patientSicknessRel, logId);
        }
        public List<TblPatientSicknessRel> SelectAllPatientSicknessRels()
        {
            return new PatientSicknessRelRepo().SelectAllPatientSicknessRels();
        }
        public TblPatientSicknessRel SelectPatientSicknessRelById(int id)
        {
            return (TblPatientSicknessRel)new PatientSicknessRelRepo().SelectPatientSicknessRelById(id);
        }
        public List<TblPatientSicknessRel> SelectPatientSicknessRelByPatientId(int patientId)
        {
            return new PatientSicknessRelRepo().SelectPatientSicknessRelByPatientId(patientId);
        }
        public List<TblPatientSicknessRel> SelectPatientSicknessRelBySicknessId(int sicknessId)
        {
            return new PatientSicknessRelRepo().SelectPatientSicknessRelBySicknessId(sicknessId);
        }
        public List<TblPatientSicknessRel> SelectPatientSicknessRelByDoctorId(int doctorId)
        {
            return new PatientSicknessRelRepo().SelectPatientSicknessRelByDoctorId(doctorId);
        }
        public List<TblPatientSicknessRel> SelectPatientSicknessRelByHospitalId(int hospitalId)
        {
            return new PatientSicknessRelRepo().SelectPatientSicknessRelByHospitalId(hospitalId);
        }
        public List<TblPatientSicknessRel> SelectPatientSicknessRelByBeforeCureDesc(int beforeCureDesc)
        {
            return new PatientSicknessRelRepo().SelectPatientSicknessRelByBeforeCureDesc(beforeCureDesc);
        }
        public List<TblPatientSicknessRel> SelectPatientSicknessRelByAfterCureDesc(int afterCureDesc)
        {
            return new PatientSicknessRelRepo().SelectPatientSicknessRelByAfterCureDesc(afterCureDesc);
        }

    }
}