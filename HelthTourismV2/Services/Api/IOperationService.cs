using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;

namespace HelthTourismV2.Services.Api
{
    public interface IOperationService : IOperationRepo
    {
        List<TblImage>SelectImagesByOperationId(int operationId);
    }
}