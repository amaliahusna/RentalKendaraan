﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RentalKendaraan.Models
{
    public partial class KondisiKendaraan
    {
        public KondisiKendaraan()
        {
            Pengembalians = new HashSet<Pengembalian>();
        }

        [Required(ErrorMessage = "Id Kondisi tidak boleh kosong")]
        public int IdKondisi { get; set; }

        [Required(ErrorMessage = "Kondisi Kendaraan tidak boleh kosong")]
        public string NamaKondisi { get; set; }

        public virtual ICollection<Pengembalian> Pengembalians { get; set; }
        public object Pengembalian { get; internal set; }
    }
}
