using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface IOperationRepo
    {
        TblOperation AddOperation(TblOperation operation);
        bool DeleteOperation(int id);
        bool UpdateOperation(TblOperation operation, int logId);
        List<TblOperation> SelectAllOperations();
        TblOperation SelectOperationById(int id);
        TblOperation SelectOperationByOperationName(string operationName);

    }
}