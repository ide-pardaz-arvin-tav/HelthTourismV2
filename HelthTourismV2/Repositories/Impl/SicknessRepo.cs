using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class SicknessRepo : ISicknessRepo
    {
        public TblSickness AddSickness(TblSickness sickness)
        {
            return (TblSickness) new MainProvider().Add(sickness);
        }
        public bool DeleteSickness(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblSickness, id);
        }
        public bool UpdateSickness(TblSickness sickness, int logId)
        {
            return new MainProvider().Update(sickness, logId);
        }
        public List<TblSickness> SelectAllSicknesss()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblSickness).Cast<TblSickness>().ToList();
        }
        public TblSickness SelectSicknessById(int id)
        {
            return (TblSickness)new MainProvider().SelectById(MainProvider.Tables.TblSickness, id);
        }
        public TblSickness SelectSicknessByName(string name)
        {
            return new MainProvider().SelectSicknessByName(name);
        }
        public List<TblSickness> SelectSicknessBySectionId(int sectionId)
        {
            return new MainProvider().SelectSicknessBySectionId(sectionId);
        }

    }
}