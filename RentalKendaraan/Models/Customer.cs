using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RentalKendaraan.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Peminjamen = new HashSet<Peminjaman>();
        }

        [Required(ErrorMessage = "Id Customer tidak boleh kosong")]
        public int IdCustomer { get; set; }

        [Required(ErrorMessage = "Nama Customer tidak boleh kosong")]
        public string NamaCustomer { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "NIK Hanya Boleh Diisi dengan angka")]
        public string Nik { get; set; }

        [Required(ErrorMessage = "Alamat Wajib Di isi")]
        public string Alamat { get; set; }

        [MinLength(11, ErrorMessage = "No Hp tidak boleh kurang dari 10")]
        [MaxLength(13, ErrorMessage = "No hp tidak boleh lebih dari 13 angka")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "No hp hanya boleh di isi dengan angka")]
        [Required(ErrorMessage = "No hp wajib di isi")]
        public string NoHp { get; set; }

        public int? IdGender { get; set; }

        public virtual Gender IdGenderNavigation { get; set; }
        public virtual ICollection<Peminjaman> Peminjamen { get; set; }
    }
}
