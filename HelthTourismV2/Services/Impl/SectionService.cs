using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class SectionService : ISectionService
    {
        public TblSection AddSection(TblSection section)
        {
            return new SectionRepo().AddSection(section);
        }
        public bool DeleteSection(int id)
        {
            return new SectionRepo().DeleteSection(id);
        }
        public bool UpdateSection(TblSection section, int logId)
        {
            return new SectionRepo().UpdateSection(section, logId);
        }
        public List<TblSection> SelectAllSections()
        {
            return new SectionRepo().SelectAllSections();
        }
        public TblSection SelectSectionById(int id)
        {
            return (TblSection)new SectionRepo().SelectSectionById(id);
        }
        public TblSection SelectSectionBySectionName(string sectionName)
        {
            return new SectionRepo().SelectSectionBySectionName(sectionName);
        }
        public List<TblOperation>SelectOperationsBySectionId(int sectionId)
        {
            List<TblSectionOperationRel> stp1 = new SectionOperationRelRepo().SelectSectionOperationRelBySectionId(sectionId);
            List<TblOperation> stp2 = new List<TblOperation>();
            foreach (TblSectionOperationRel rel in stp1)
                stp2.Add(new OperationRepo().SelectOperationById(rel.OperationId));
            return stp2;
        }

    }
}