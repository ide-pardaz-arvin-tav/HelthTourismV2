using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface IConfigRepo
    {
        TblConfig AddConfig(TblConfig config);
        bool DeleteConfig(int id);
        bool UpdateConfig(TblConfig config, int logId);
        List<TblConfig> SelectAllConfigs();
        TblConfig SelectConfigById(int id);

    }
}