using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface ISectionRepo
    {
        TblSection AddSection(TblSection section);
        bool DeleteSection(int id);
        bool UpdateSection(TblSection section, int logId);
        List<TblSection> SelectAllSections();
        TblSection SelectSectionById(int id);
        TblSection SelectSectionBySectionName(string sectionName);

    }
}