namespace De02.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [Key]
        public int proid { get; set; }

        [Required(ErrorMessage ="Tên sản phẩm không được để trống")]
        [StringLength(45)]
        [DisplayName("Tên sản phẩm")]
        public string proname { get; set; }

        [DisplayName("Giá")]
        public decimal price { get; set; }

        [DisplayName("Stock")]
        public decimal stock { get; set; }

        [StringLength(100)]
        [DisplayName("Hình ảnh")]
        public string image { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Mô tả")]
        public string description { get; set; }

        [DisplayName("Loại sản phẩm")]
        public int catid { get; set; }

        public virtual category category { get; set; }
    }
}
