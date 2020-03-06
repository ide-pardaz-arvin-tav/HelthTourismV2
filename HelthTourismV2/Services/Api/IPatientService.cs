using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;

namespace HelthTourismV2.Services.Api
{
    public interface IPatientService : IPatientRepo
    {
        List<TblSickness>SelectSicknesssByPatientId(int patientId);
        List<TblImage>SelectImagesByPatientId(int patientId);
    }
}