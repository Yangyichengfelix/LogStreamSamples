using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Mac2sAPI.Data
{
    [Table("Mold")]
    public class Mold
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Nr_Moule { get; set; }
        [MaxLength(50)]
        public string NameIMM { get; set; } //added 27/01/2022

        public int Nb_piece { get; set; } //added 16/03/2022
        public virtual IList<Product> Products { get; set; }

        public float? Ref_S1{ get; set; }
        public float? Ref_S2{ get; set; }
        public float? Ref_S3{ get; set; }
        public float? Ref_S4{ get; set; }
        public float? Ref_S5{ get; set; }

    }
}
