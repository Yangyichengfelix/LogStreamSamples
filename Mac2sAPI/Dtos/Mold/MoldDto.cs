using Mac2sAPI.Dtos.Product;

namespace Mac2sAPI.Dtos.Mold
{
    public class MoldDto : BaseDto
    {
        //added 28/02/2022

        public string Nr_Moule { get; set; }

        public string NameIMM { get; set; } //added 27/01/2022

        public int Nb_piece { get; set; } //added 16/03/2022
        public virtual IList<ProductDto> Products { get; set; }

        public float? Ref_S1 { get; set; }
        public float? Ref_S2 { get; set; }
        public float? Ref_S3 { get; set; }
        public float? Ref_S4 { get; set; }
        public float? Ref_S5 { get; set; }
    }
}
