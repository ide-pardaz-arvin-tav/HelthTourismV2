using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface IPatientSicknessRelRepo
    {
        TblPatientSicknessRel AddPatientSicknessRel(TblPatientSicknessRel patientSicknessRel);
        bool DeletePatientSicknessRel(int id);
        bool UpdatePatientSicknessRel(TblPatientSicknessRel patientSicknessRel, int logId);
        List<TblPatientSicknessRel> SelectAllPatientSicknessRels();
        TblPatientSicknessRel SelectPatientSicknessRelById(int id);
        List<TblPatientSicknessRel> SelectPatientSicknessRelByPatientId(int patientId);
        List<TblPatientSicknessRel> SelectPatientSicknessRelBySicknessId(int sicknessId);
        List<TblPatientSicknessRel> SelectPatientSicknessRelByDoctorId(int doctorId);
        List<TblPatientSicknessRel> SelectPatientSicknessRelByHospitalId(int hospitalId);
        List<TblPatientSicknessRel> SelectPatientSicknessRelByBeforeCureDesc(int beforeCureDesc);
        List<TblPatientSicknessRel> SelectPatientSicknessRelByAfterCureDesc(int afterCureDesc);

    }
}