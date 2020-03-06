using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class PatientImageRelRepo : IPatientImageRelRepo
    {
        public TblPatientImageRel AddPatientImageRel(TblPatientImageRel patientImageRel)
        {
            return (TblPatientImageRel) new MainProvider().Add(patientImageRel);
        }
        public bool DeletePatientImageRel(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblPatientImageRel, id);
        }
        public bool UpdatePatientImageRel(TblPatientImageRel patientImageRel, int logId)
        {
            return new MainProvider().Update(patientImageRel, logId);
        }
        public List<TblPatientImageRel> SelectAllPatientImageRels()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblPatientImageRel).Cast<TblPatientImageRel>().ToList();
        }
        public TblPatientImageRel SelectPatientImageRelById(int id)
        {
            return (TblPatientImageRel)new MainProvider().SelectById(MainProvider.Tables.TblPatientImageRel, id);
        }
        public List<TblPatientImageRel> SelectPatientImageRelByPatientId(int patientId)
        {
            return new MainProvider().SelectPatientImageRel(patientId, MainProvider.PatientImageRel.PatientId);
        }
        public List<TblPatientImageRel> SelectPatientImageRelByImageId(int imageId)
        {
            return new MainProvider().SelectPatientImageRel(imageId, MainProvider.PatientImageRel.ImageId);
        }

    }
}