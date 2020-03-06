namespace HelthTourismV2.Models.Regular
{
    public class TblSectionOperationRel
    {
        public int id { get; set; }
        public int SectionId { get; set; }
        public int OperationId { get; set; }

        public TblSectionOperationRel(int id)
        {
            this.id = id;
        }

		public TblSectionOperationRel(int id, int sectionId, int operationId)
        {
            this.id = id;
            SectionId = sectionId;
            OperationId = operationId;
        }
        public TblSectionOperationRel(int sectionId, int operationId)
        {
            SectionId = sectionId;
            OperationId = operationId;
        }

        public TblSectionOperationRel()
        {
            
        }
    }
}