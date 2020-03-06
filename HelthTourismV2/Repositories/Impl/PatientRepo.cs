using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class PatientRepo : IPatientRepo
    {
        public TblPatient AddPatient(TblPatient patient)
        {
            return (TblPatient) new MainProvider().Add(patient);
        }
        public bool DeletePatient(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblPatient, id);
        }
        public bool UpdatePatient(TblPatient patient, int logId)
        {
            return new MainProvider().Update(patient, logId);
        }
        public List<TblPatient> SelectAllPatients()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblPatient).Cast<TblPatient>().ToList();
        }
        public TblPatient SelectPatientById(int id)
        {
            return (TblPatient)new MainProvider().SelectById(MainProvider.Tables.TblPatient, id);
        }
        public TblPatient SelectPatientByName(string name)
        {
            return new MainProvider().SelectPatientByName(name);
        }
        public List<TblPatient> SelectPatientByIsMan(bool isMan)
        {
            return new MainProvider().SelectPatientByIsMan(isMan);
        }
        public List<TblPatient> SelectPatientByCountryId(int countryId)
        {
            return new MainProvider().SelectPatientByCountryId(countryId);
        }
        public List<TblPatient> SelectPatientByCityId(int cityId)
        {
            return new MainProvider().SelectPatientByCityId(cityId);
        }
        public List<TblPatient> SelectPatientByPassNoOrIdentification(int passNoOrIdentification)
        {
            return new MainProvider().SelectPatientByPassNoOrIdentification(passNoOrIdentification);
        }
        public TblPatient SelectPatientByEmail(string email)
        {
            return new MainProvider().SelectPatientByEmail(email);
        }
        public TblPatient SelectPatientByTellNo(string tellNo)
        {
            return new MainProvider().SelectPatientByTellNo(tellNo);
        }
        public List<TblPatient> SelectPatientByUserPassId(int userPassId)
        {
            return new MainProvider().SelectPatientByUserPassId(userPassId);
        }
        public TblPatient SelectPatientByParentalName(string parentalName)
        {
            return new MainProvider().SelectPatientByParentalName(parentalName);
        }
        public TblPatient SelectPatientByHelpName(string helpName)
        {
            return new MainProvider().SelectPatientByHelpName(helpName);
        }

    }
}