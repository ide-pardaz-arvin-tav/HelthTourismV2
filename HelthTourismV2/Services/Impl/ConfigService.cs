using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class ConfigService : IConfigService
    {
        public TblConfig AddConfig(TblConfig config)
        {
            return new ConfigRepo().AddConfig(config);
        }
        public bool DeleteConfig(int id)
        {
            return new ConfigRepo().DeleteConfig(id);
        }
        public bool UpdateConfig(TblConfig config, int logId)
        {
            return new ConfigRepo().UpdateConfig(config, logId);
        }
        public List<TblConfig> SelectAllConfigs()
        {
            return new ConfigRepo().SelectAllConfigs();
        }
        public TblConfig SelectConfigById(int id)
        {
            return (TblConfig)new ConfigRepo().SelectConfigById(id);
        }

    }
}