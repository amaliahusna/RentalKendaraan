using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RentalKendaraan.Models
{
    public partial class Pengembalian
    {
        [Required(ErrorMessage = "Id Pengembalian tidak boleh kosong")]
        public int IdPengembalian { get; set; }

        [Required(ErrorMessage = "Tanggal Pengembalian tidak boleh kosong")]
        public DateTime? TglPengembalian { get; set; }

        [Required(ErrorMessage = "Id Peminjaman tidak boleh kosong")]
        public int? IdPeminjaman { get; set; }

        [Required(ErrorMessage = "Id Kondisi tidak boleh kosong")]
        public int? IdKondisi { get; set; }

        [Required(ErrorMessage = "Denda tidak boleh kosong")]
        public int? Denda { get; set; }

        public virtual KondisiKendaraan IdKondisiNavigation { get; set; }
        public virtual Peminjaman IdPeminjamanNavigation { get; set; }
        public object TglPembelian { get; internal set; }
    }
}
