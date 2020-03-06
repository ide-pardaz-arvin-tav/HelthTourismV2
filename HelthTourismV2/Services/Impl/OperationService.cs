using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class OperationService : IOperationService
    {
        public TblOperation AddOperation(TblOperation operation)
        {
            return new OperationRepo().AddOperation(operation);
        }
        public bool DeleteOperation(int id)
        {
            return new OperationRepo().DeleteOperation(id);
        }
        public bool UpdateOperation(TblOperation operation, int logId)
        {
            return new OperationRepo().UpdateOperation(operation, logId);
        }
        public List<TblOperation> SelectAllOperations()
        {
            return new OperationRepo().SelectAllOperations();
        }
        public TblOperation SelectOperationById(int id)
        {
            return (TblOperation)new OperationRepo().SelectOperationById(id);
        }
        public TblOperation SelectOperationByOperationName(string operationName)
        {
            return new OperationRepo().SelectOperationByOperationName(operationName);
        }
        public List<TblImage> SelectImagesByOperationId(int operationId)
        {
            List<TblOperationImageRel> stp1 = new OperationImageRelRepo().SelectOperationImageRelByOperationId(operationId);
            List<TblImage> stp2 = new List<TblImage>();
            foreach (TblOperationImageRel rel in stp1)
                stp2.Add(new ImageRepo().SelectImageById(rel.ImageId));
            return stp2;
        }
    }
}