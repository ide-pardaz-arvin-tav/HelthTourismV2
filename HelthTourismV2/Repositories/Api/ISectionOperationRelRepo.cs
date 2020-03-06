using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface ISectionOperationRelRepo
    {
        TblSectionOperationRel AddSectionOperationRel(TblSectionOperationRel sectionOperationRel);
        bool DeleteSectionOperationRel(int id);
        bool UpdateSectionOperationRel(TblSectionOperationRel sectionOperationRel, int logId);
        List<TblSectionOperationRel> SelectAllSectionOperationRels();
        TblSectionOperationRel SelectSectionOperationRelById(int id);
        List<TblSectionOperationRel> SelectSectionOperationRelBySectionId(int sectionId);
        List<TblSectionOperationRel> SelectSectionOperationRelByOperationId(int operationId);

    }
}