using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class SectionOperationRelService : ISectionOperationRelService
    {
        public TblSectionOperationRel AddSectionOperationRel(TblSectionOperationRel sectionOperationRel)
        {
            return new SectionOperationRelRepo().AddSectionOperationRel(sectionOperationRel);
        }
        public bool DeleteSectionOperationRel(int id)
        {
            return new SectionOperationRelRepo().DeleteSectionOperationRel(id);
        }
        public bool UpdateSectionOperationRel(TblSectionOperationRel sectionOperationRel, int logId)
        {
            return new SectionOperationRelRepo().UpdateSectionOperationRel(sectionOperationRel, logId);
        }
        public List<TblSectionOperationRel> SelectAllSectionOperationRels()
        {
            return new SectionOperationRelRepo().SelectAllSectionOperationRels();
        }
        public TblSectionOperationRel SelectSectionOperationRelById(int id)
        {
            return (TblSectionOperationRel)new SectionOperationRelRepo().SelectSectionOperationRelById(id);
        }
        public List<TblSectionOperationRel> SelectSectionOperationRelBySectionId(int sectionId)
        {
            return new SectionOperationRelRepo().SelectSectionOperationRelBySectionId(sectionId);
        }
        public List<TblSectionOperationRel> SelectSectionOperationRelByOperationId(int operationId)
        {
            return new SectionOperationRelRepo().SelectSectionOperationRelByOperationId(operationId);
        }

    }
}