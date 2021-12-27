using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RentalKendaraan.Models
{
    public partial class Peminjaman
    {
        public Peminjaman()
        {
            Pengembalians = new HashSet<Pengembalian>();
        }

        [Required(ErrorMessage = "Id Peminjaman tidak boleh kosong")]
        public int IdPeminjaman { get; set; }

        [Required(ErrorMessage = "Tanggal Peminjaman tidak boleh kosong")]
        public DateTime? TglPeminjaman { get; set; }

        [Required(ErrorMessage = "Id Kendaraan tidak boleh kosong")]
        public int? IdKendaraan { get; set; }

        [Required(ErrorMessage = "Id Customer tidak boleh kosong")]
        public int? IdCustomer { get; set; }

        [Required(ErrorMessage = "Id Jaminan tidak boleh kosong")]
        public int? IdJaminan { get; set; }

        [Required(ErrorMessage = "Biaya tidak boleh kosong")]
        public int? Biaya { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Jaminan IdJaminanNavigation { get; set; }
        public virtual Kendaraan IdKendaraanNavigation { get; set; }
        public virtual ICollection<Pengembalian> Pengembalians { get; set; }
        public object Pengembalian { get; internal set; }
    }
}
