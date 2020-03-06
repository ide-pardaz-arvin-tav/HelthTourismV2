using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface IPatientImageRelRepo
    {
        TblPatientImageRel AddPatientImageRel(TblPatientImageRel patientImageRel);
        bool DeletePatientImageRel(int id);
        bool UpdatePatientImageRel(TblPatientImageRel patientImageRel, int logId);
        List<TblPatientImageRel> SelectAllPatientImageRels();
        TblPatientImageRel SelectPatientImageRelById(int id);
        List<TblPatientImageRel> SelectPatientImageRelByPatientId(int patientId);
        List<TblPatientImageRel> SelectPatientImageRelByImageId(int imageId);

    }
}