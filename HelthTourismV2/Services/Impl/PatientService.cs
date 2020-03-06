using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class PatientService : IPatientService
    {
        public TblPatient AddPatient(TblPatient patient)
        {
            return new PatientRepo().AddPatient(patient);
        }
        public bool DeletePatient(int id)
        {
            return new PatientRepo().DeletePatient(id);
        }
        public bool UpdatePatient(TblPatient patient, int logId)
        {
            return new PatientRepo().UpdatePatient(patient, logId);
        }
        public List<TblPatient> SelectAllPatients()
        {
            return new PatientRepo().SelectAllPatients();
        }
        public TblPatient SelectPatientById(int id)
        {
            return (TblPatient)new PatientRepo().SelectPatientById(id);
        }
        public TblPatient SelectPatientByName(string name)
        {
            return new PatientRepo().SelectPatientByName(name);
        }
        public List<TblPatient> SelectPatientByIsMan(bool isMan)
        {
            return new PatientRepo().SelectPatientByIsMan(isMan);
        }
        public List<TblPatient> SelectPatientByCountryId(int countryId)
        {
            return new PatientRepo().SelectPatientByCountryId(countryId);
        }
        public List<TblPatient> SelectPatientByCityId(int cityId)
        {
            return new PatientRepo().SelectPatientByCityId(cityId);
        }
        public List<TblPatient> SelectPatientByPassNoOrIdentification(int passNoOrIdentification)
        {
            return new PatientRepo().SelectPatientByPassNoOrIdentification(passNoOrIdentification);
        }
        public TblPatient SelectPatientByEmail(string email)
        {
            return new PatientRepo().SelectPatientByEmail(email);
        }
        public TblPatient SelectPatientByTellNo(string tellNo)
        {
            return new PatientRepo().SelectPatientByTellNo(tellNo);
        }
        public List<TblPatient> SelectPatientByUserPassId(int userPassId)
        {
            return new PatientRepo().SelectPatientByUserPassId(userPassId);
        }
        public TblPatient SelectPatientByParentalName(string parentalName)
        {
            return new PatientRepo().SelectPatientByParentalName(parentalName);
        }
        public TblPatient SelectPatientByHelpName(string helpName)
        {
            return new PatientRepo().SelectPatientByHelpName(helpName);
        }
        public List<TblSickness> SelectSicknesssByPatientId(int patientId)
        {
            List<TblPatientSicknessRel> stp1 = new PatientSicknessRelRepo().SelectPatientSicknessRelByPatientId(patientId);
            List<TblSickness> stp2 = new List<TblSickness>();
            foreach (TblPatientSicknessRel rel in stp1)
                stp2.Add(new SicknessRepo().SelectSicknessById(rel.SicknessId));
            return stp2;
        }
        public List<TblImage> SelectImagesByPatientId(int patientId)
        {
            List<TblPatientImageRel> stp1 = new PatientImageRelRepo().SelectPatientImageRelByPatientId(patientId);
            List<TblImage> stp2 = new List<TblImage>();
            foreach (TblPatientImageRel rel in stp1)
                stp2.Add(new ImageRepo().SelectImageById(rel.ImageId));
            return stp2;
        }

    }
}