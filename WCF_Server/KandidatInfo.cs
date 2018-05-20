using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCF_Server
{
    [DataContract]
    public class KandidatInfo
    {
        int NIM, NomorUrut;
        string Nama, Jurusan, Prodi;
        string Visi, Misi;
        byte[] pic;

        [DataMember]
        public int ID
        {
            get { return NIM; }
            set { NIM = value; }
        }

        [DataMember]
        public int nomorUrut
        {
            get { return NomorUrut; }
            set { NomorUrut = value; }
        }

        [DataMember]
        public string nama
        {
            get { return Nama; }
            set { Nama = value; }
        }

        [DataMember]
        public string jurusan
        {
            get { return Jurusan; }
            set { Jurusan = value; }
        }

        [DataMember]
        public string prodi
        {
            get { return Prodi; }
            set { Prodi = value; }
        }

        [DataMember]
        public string visi
        {
            get { return Visi; }
            set { Visi = value; }
        }

        [DataMember]
        public string misi
        {
            get { return Misi; }
            set { Misi = value; }
        }

        [DataMember]
        public byte[] picture
        {
            get { return pic; }
            set { pic = value; }
        }
    }
}