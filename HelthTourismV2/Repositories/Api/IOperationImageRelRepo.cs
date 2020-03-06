using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface IOperationImageRelRepo
    {
        TblOperationImageRel AddOperationImageRel(TblOperationImageRel operationImageRel);
        bool DeleteOperationImageRel(int id);
        bool UpdateOperationImageRel(TblOperationImageRel operationImageRel, int logId);
        List<TblOperationImageRel> SelectAllOperationImageRels();
        TblOperationImageRel SelectOperationImageRelById(int id);
        List<TblOperationImageRel> SelectOperationImageRelByOperationId(int operationId);
        List<TblOperationImageRel> SelectOperationImageRelByImageId(int imageId);

    }
}