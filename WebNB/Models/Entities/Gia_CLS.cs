using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebNB.Models.Entities
{
    public class Gia_CLS
    {
        [Key]
        public int STT { get; set; }

        [MaxLength(50)]
        public string Ma { get; set; } = "";

        [MaxLength(254)]
        public string Ten { get; set; } = "";

        [MaxLength(25)]
        public string DVT { get; set; } = "";

        [Precision(9, 0)]
        public decimal Gia_TH { get; set; }

        [Precision(9, 0)]
        public decimal Gia_BH { get; set; }

        [MaxLength(100)]
        public string LoaiVP { get; set; } = "";

        [MaxLength(100)]
        public string NhomVP { get; set; } = "";

        [MaxLength(100)]
        public string NhomVP_BHYT { get; set; } = "";

        [MaxLength(20)]
        public string QD366 { get; set; } = "";

        [MaxLength(254)]
        public string Ten43 { get; set; } = "";

        [MaxLength(254)]
        public string GhiChuKt { get; set; } = "";

    }
}
