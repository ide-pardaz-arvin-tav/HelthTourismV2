using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class ConfigRepo : IConfigRepo
    {
        public TblConfig AddConfig(TblConfig config)
        {
            return (TblConfig) new MainProvider().Add(config);
        }
        public bool DeleteConfig(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblConfig, id);
        }
        public bool UpdateConfig(TblConfig config, int logId)
        {
            return new MainProvider().Update(config, logId);
        }
        public List<TblConfig> SelectAllConfigs()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblConfig).Cast<TblConfig>().ToList();
        }
        public TblConfig SelectConfigById(int id)
        {
            return (TblConfig)new MainProvider().SelectById(MainProvider.Tables.TblConfig, id);
        }

    }
}