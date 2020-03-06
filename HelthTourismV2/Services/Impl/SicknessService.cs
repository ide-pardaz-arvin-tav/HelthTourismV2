using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class SicknessService : ISicknessService
    {
        public TblSickness AddSickness(TblSickness sickness)
        {
            return new SicknessRepo().AddSickness(sickness);
        }
        public bool DeleteSickness(int id)
        {
            return new SicknessRepo().DeleteSickness(id);
        }
        public bool UpdateSickness(TblSickness sickness, int logId)
        {
            return new SicknessRepo().UpdateSickness(sickness, logId);
        }
        public List<TblSickness> SelectAllSicknesss()
        {
            return new SicknessRepo().SelectAllSicknesss();
        }
        public TblSickness SelectSicknessById(int id)
        {
            return (TblSickness)new SicknessRepo().SelectSicknessById(id);
        }
        public TblSickness SelectSicknessByName(string name)
        {
            return new SicknessRepo().SelectSicknessByName(name);
        }
        public List<TblSickness> SelectSicknessBySectionId(int sectionId)
        {
            return new SicknessRepo().SelectSicknessBySectionId(sectionId);
        }

    }
}