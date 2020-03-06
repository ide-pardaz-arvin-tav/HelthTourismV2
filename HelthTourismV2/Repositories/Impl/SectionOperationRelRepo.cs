using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class SectionOperationRelRepo : ISectionOperationRelRepo
    {
        public TblSectionOperationRel AddSectionOperationRel(TblSectionOperationRel sectionOperationRel)
        {
            return (TblSectionOperationRel) new MainProvider().Add(sectionOperationRel);
        }
        public bool DeleteSectionOperationRel(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblSectionOperationRel, id);
        }
        public bool UpdateSectionOperationRel(TblSectionOperationRel sectionOperationRel, int logId)
        {
            return new MainProvider().Update(sectionOperationRel, logId);
        }
        public List<TblSectionOperationRel> SelectAllSectionOperationRels()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblSectionOperationRel).Cast<TblSectionOperationRel>().ToList();
        }
        public TblSectionOperationRel SelectSectionOperationRelById(int id)
        {
            return (TblSectionOperationRel)new MainProvider().SelectById(MainProvider.Tables.TblSectionOperationRel, id);
        }
        public List<TblSectionOperationRel> SelectSectionOperationRelBySectionId(int sectionId)
        {
            return new MainProvider().SelectSectionOperationRel(sectionId, MainProvider.SectionOperationRel.SectionId);
        }
        public List<TblSectionOperationRel> SelectSectionOperationRelByOperationId(int operationId)
        {
            return new MainProvider().SelectSectionOperationRel(operationId, MainProvider.SectionOperationRel.OperationId);
        }

    }
}