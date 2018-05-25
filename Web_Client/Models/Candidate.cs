using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web_Client.Models
{
    public class Candidate
    {
        [DisplayName("Nomor: ")]
        public int Nomor_urut { get; set; }

        [DisplayName("Nama: ")]
        public string Nama { get; set; }

        [DisplayName("Jurusan: ")]
        public string Jurusan { get; set; }

        [DisplayName("Prodi: ")]
        public string Prodi { get; set; }

        [DisplayName("Visi: ")]
        public string Visi { get; set; }

        [DisplayName("Misi: ")]
        public string Misi { get; set; }

        public string Foto { get; set; }

    }
}