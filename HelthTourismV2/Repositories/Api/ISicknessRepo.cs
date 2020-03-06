using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface ISicknessRepo
    {
        TblSickness AddSickness(TblSickness sickness);
        bool DeleteSickness(int id);
        bool UpdateSickness(TblSickness sickness, int logId);
        List<TblSickness> SelectAllSicknesss();
        TblSickness SelectSicknessById(int id);
        TblSickness SelectSicknessByName(string name);
        List<TblSickness> SelectSicknessBySectionId(int sectionId);

    }
}