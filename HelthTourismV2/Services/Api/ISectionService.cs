using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;

namespace HelthTourismV2.Services.Api
{
    public interface ISectionService : ISectionRepo
    {
        List<TblOperation>SelectOperationsBySectionId(int sectionId);

    }
}