namespace HelthTourismV2.Models.Regular
{
    public class TblOperation
    {
        public int id { get; set; }
        public string OperationName { get; set; }
        public long OperationPrice { get; set; }

        public TblOperation(int id)
        {
            this.id = id;
        }

		public TblOperation(int id, string operationName, long operationPrice)
        {
            this.id = id;
            OperationName = operationName;
            OperationPrice = operationPrice;
        }
        public TblOperation(string operationName, long operationPrice)
        {
            OperationName = operationName;
            OperationPrice = operationPrice;
        }

        public TblOperation()
        {
            
        }
    }
}