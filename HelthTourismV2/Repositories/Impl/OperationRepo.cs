using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class OperationRepo : IOperationRepo
    {
        public TblOperation AddOperation(TblOperation operation)
        {
            return (TblOperation) new MainProvider().Add(operation);
        }
        public bool DeleteOperation(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblOperation, id);
        }
        public bool UpdateOperation(TblOperation operation, int logId)
        {
            return new MainProvider().Update(operation, logId);
        }
        public List<TblOperation> SelectAllOperations()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblOperation).Cast<TblOperation>().ToList();
        }
        public TblOperation SelectOperationById(int id)
        {
            return (TblOperation)new MainProvider().SelectById(MainProvider.Tables.TblOperation, id);
        }
        public TblOperation SelectOperationByOperationName(string operationName)
        {
            return new MainProvider().SelectOperationByOperationName(operationName);
        }

    }
}