using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class PatientSicknessRelRepo : IPatientSicknessRelRepo
    {
        public TblPatientSicknessRel AddPatientSicknessRel(TblPatientSicknessRel patientSicknessRel)
        {
            return (TblPatientSicknessRel) new MainProvider().Add(patientSicknessRel);
        }
        public bool DeletePatientSicknessRel(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblPatientSicknessRel, id);
        }
        public bool UpdatePatientSicknessRel(TblPatientSicknessRel patientSicknessRel, int logId)
        {
            return new MainProvider().Update(patientSicknessRel, logId);
        }
        public List<TblPatientSicknessRel> SelectAllPatientSicknessRels()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblPatientSicknessRel).Cast<TblPatientSicknessRel>().ToList();
        }
        public TblPatientSicknessRel SelectPatientSicknessRelById(int id)
        {
            return (TblPatientSicknessRel)new MainProvider().SelectById(MainProvider.Tables.TblPatientSicknessRel, id);
        }
        public List<TblPatientSicknessRel> SelectPatientSicknessRelByPatientId(int patientId)
        {
            return new MainProvider().SelectPatientSicknessRel(patientId, MainProvider.PatientSicknessRel.PatientId);
        }
        public List<TblPatientSicknessRel> SelectPatientSicknessRelBySicknessId(int sicknessId)
        {
            return new MainProvider().SelectPatientSicknessRel(sicknessId, MainProvider.PatientSicknessRel.SicknessId);
        }
        public List<TblPatientSicknessRel> SelectPatientSicknessRelByDoctorId(int doctorId)
        {
            return new MainProvider().SelectPatientSicknessRel(doctorId, MainProvider.PatientSicknessRel.DoctorId);
        }
        public List<TblPatientSicknessRel> SelectPatientSicknessRelByHospitalId(int hospitalId)
        {
            return new MainProvider().SelectPatientSicknessRel(hospitalId, MainProvider.PatientSicknessRel.HospitalId);
        }
        public List<TblPatientSicknessRel> SelectPatientSicknessRelByBeforeCureDesc(int beforeCureDesc)
        {
            return new MainProvider().SelectPatientSicknessRel(beforeCureDesc, MainProvider.PatientSicknessRel.BeforeCureDesc);
        }
        public List<TblPatientSicknessRel> SelectPatientSicknessRelByAfterCureDesc(int afterCureDesc)
        {
            return new MainProvider().SelectPatientSicknessRel(afterCureDesc, MainProvider.PatientSicknessRel.AfterCureDesc);
        }

    }
}