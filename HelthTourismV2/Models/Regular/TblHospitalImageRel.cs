namespace HelthTourismV2.Models.Regular
{
    public class TblHospitalImageRel
    {
        public int id { get; set; }
        public int HospitalId { get; set; }
        public int ImageId { get; set; }

        public TblHospitalImageRel(int id)
        {
            this.id = id;
        }

		public TblHospitalImageRel(int id, int hospitalId, int imageId)
        {
            this.id = id;
            HospitalId = hospitalId;
            ImageId = imageId;
        }
        public TblHospitalImageRel(int hospitalId, int imageId)
        {
            HospitalId = hospitalId;
            ImageId = imageId;
        }

        public TblHospitalImageRel()
        {
            
        }
    }
}