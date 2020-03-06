using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface IPatientRepo
    {
        TblPatient AddPatient(TblPatient patient);
        bool DeletePatient(int id);
        bool UpdatePatient(TblPatient patient, int logId);
        List<TblPatient> SelectAllPatients();
        TblPatient SelectPatientById(int id);
        TblPatient SelectPatientByName(string name);
        List<TblPatient> SelectPatientByIsMan(bool isMan);
        List<TblPatient> SelectPatientByCountryId(int countryId);
        List<TblPatient> SelectPatientByCityId(int cityId);
        List<TblPatient> SelectPatientByPassNoOrIdentification(int passNoOrIdentification);
        TblPatient SelectPatientByEmail(string email);
        TblPatient SelectPatientByTellNo(string tellNo);
        List<TblPatient> SelectPatientByUserPassId(int userPassId);
        TblPatient SelectPatientByParentalName(string parentalName);
        TblPatient SelectPatientByHelpName(string helpName);

    }
}