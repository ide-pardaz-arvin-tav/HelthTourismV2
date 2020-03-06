using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class OperationImageRelRepo : IOperationImageRelRepo
    {
        public TblOperationImageRel AddOperationImageRel(TblOperationImageRel operationImageRel)
        {
            return (TblOperationImageRel) new MainProvider().Add(operationImageRel);
        }
        public bool DeleteOperationImageRel(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblOperationImageRel, id);
        }
        public bool UpdateOperationImageRel(TblOperationImageRel operationImageRel, int logId)
        {
            return new MainProvider().Update(operationImageRel, logId);
        }
        public List<TblOperationImageRel> SelectAllOperationImageRels()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblOperationImageRel).Cast<TblOperationImageRel>().ToList();
        }
        public TblOperationImageRel SelectOperationImageRelById(int id)
        {
            return (TblOperationImageRel)new MainProvider().SelectById(MainProvider.Tables.TblOperationImageRel, id);
        }
        public List<TblOperationImageRel> SelectOperationImageRelByOperationId(int operationId)
        {
            return new MainProvider().SelectOperationImageRel(operationId, MainProvider.OperationImageRel.OperationId);
        }
        public List<TblOperationImageRel> SelectOperationImageRelByImageId(int imageId)
        {
            return new MainProvider().SelectOperationImageRel(imageId, MainProvider.OperationImageRel.ImageId);
        }

    }
}