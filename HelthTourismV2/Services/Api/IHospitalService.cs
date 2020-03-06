using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;

namespace HelthTourismV2.Services.Api
{
    public interface IHospitalService : IHospitalRepo
    {
        List<TblImage>SelectImagesByHospitalId(int hospitalId);
        List<TblSection>SelectSectionsByHospitalId(int hospitalId);
    }
}