using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class PatientImageRelService : IPatientImageRelService
    {
        public TblPatientImageRel AddPatientImageRel(TblPatientImageRel patientImageRel)
        {
            return new PatientImageRelRepo().AddPatientImageRel(patientImageRel);
        }
        public bool DeletePatientImageRel(int id)
        {
            return new PatientImageRelRepo().DeletePatientImageRel(id);
        }
        public bool UpdatePatientImageRel(TblPatientImageRel patientImageRel, int logId)
        {
            return new PatientImageRelRepo().UpdatePatientImageRel(patientImageRel, logId);
        }
        public List<TblPatientImageRel> SelectAllPatientImageRels()
        {
            return new PatientImageRelRepo().SelectAllPatientImageRels();
        }
        public TblPatientImageRel SelectPatientImageRelById(int id)
        {
            return (TblPatientImageRel)new PatientImageRelRepo().SelectPatientImageRelById(id);
        }
        public List<TblPatientImageRel> SelectPatientImageRelByPatientId(int patientId)
        {
            return new PatientImageRelRepo().SelectPatientImageRelByPatientId(patientId);
        }
        public List<TblPatientImageRel> SelectPatientImageRelByImageId(int imageId)
        {
            return new PatientImageRelRepo().SelectPatientImageRelByImageId(imageId);
        }

    }
}