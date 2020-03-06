namespace HelthTourismV2.Models.Regular
{
    public class TblOperationImageRel
    {
        public int id { get; set; }
        public int OperationId { get; set; }
        public int ImageId { get; set; }

        public TblOperationImageRel(int id)
        {
            this.id = id;
        }

		public TblOperationImageRel(int id, int operationId, int imageId)
        {
            this.id = id;
            OperationId = operationId;
            ImageId = imageId;
        }
        public TblOperationImageRel(int operationId, int imageId)
        {
            OperationId = operationId;
            ImageId = imageId;
        }

        public TblOperationImageRel()
        {
            
        }
    }
}