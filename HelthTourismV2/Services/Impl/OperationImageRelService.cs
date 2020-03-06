using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class OperationImageRelService : IOperationImageRelService
    {
        public TblOperationImageRel AddOperationImageRel(TblOperationImageRel operationImageRel)
        {
            return new OperationImageRelRepo().AddOperationImageRel(operationImageRel);
        }
        public bool DeleteOperationImageRel(int id)
        {
            return new OperationImageRelRepo().DeleteOperationImageRel(id);
        }
        public bool UpdateOperationImageRel(TblOperationImageRel operationImageRel, int logId)
        {
            return new OperationImageRelRepo().UpdateOperationImageRel(operationImageRel, logId);
        }
        public List<TblOperationImageRel> SelectAllOperationImageRels()
        {
            return new OperationImageRelRepo().SelectAllOperationImageRels();
        }
        public TblOperationImageRel SelectOperationImageRelById(int id)
        {
            return (TblOperationImageRel)new OperationImageRelRepo().SelectOperationImageRelById(id);
        }
        public List<TblOperationImageRel> SelectOperationImageRelByOperationId(int operationId)
        {
            return new OperationImageRelRepo().SelectOperationImageRelByOperationId(operationId);
        }
        public List<TblOperationImageRel> SelectOperationImageRelByImageId(int imageId)
        {
            return new OperationImageRelRepo().SelectOperationImageRelByImageId(imageId);
        }

    }
}