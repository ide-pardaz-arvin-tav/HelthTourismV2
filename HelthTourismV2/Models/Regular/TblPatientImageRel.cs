namespace HelthTourismV2.Models.Regular
{
    public class TblPatientImageRel
    {
        public int id { get; set; }
        public int PatientId { get; set; }
        public int ImageId { get; set; }

        public TblPatientImageRel(int id)
        {
            this.id = id;
        }

		public TblPatientImageRel(int id, int patientId, int imageId)
        {
            this.id = id;
            PatientId = patientId;
            ImageId = imageId;
        }
        public TblPatientImageRel(int patientId, int imageId)
        {
            PatientId = patientId;
            ImageId = imageId;
        }

        public TblPatientImageRel()
        {
            
        }
    }
}