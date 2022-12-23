namespace De02.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("account")]
    public partial class account
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Username không được để trống")]
        [StringLength(50)]
        [DisplayName("Tên người dùng")]
        public string username { get; set; }

        [Required(ErrorMessage ="Họ tên không được để trống")]
        [StringLength(30)]
        [DisplayName("Họ tên")]
        public string fullname { get; set; }

        [Required(ErrorMessage="Số điện thoại không được để trống")]
        [StringLength(20)]
        [DisplayName("Số điện thoại")]
        public string phone { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(30)]
        [DisplayName("Mật khẩu")]
        public string password { get; set; }

        [StringLength(50)]
        public string email { get; set; }
    }
}
