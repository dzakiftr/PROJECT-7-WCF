using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCF_Server
{
    [DataContract]
    public class MahasiswaInfo
    {
        int NIM;
        string Nama, TempatLahir, TglLahir, Jurusan;
        string Prodi, Password;

        [DataMember]
        public int ID
        {
            get { return NIM; }
            set { NIM = value; }
        }

        [DataMember]
        public string nama
        {
            get { return Nama; }
            set { Nama = value; }
        }

        [DataMember]
        public string tempatlahir
        {
            get { return TempatLahir; }
            set { TempatLahir = value; }
        }

        [DataMember]
        public string tglLahir
        {
            get { return TglLahir; }
            set { TglLahir = value; }
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
        public string password
        {
            get { return Password; }
            set { Password = value; }
        }
    }
}