using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCF_Server
{
    [DataContract]
    public class VoteInfo
    {
        int ID, NomorUrut;

        [DataMember]
        public int NIM { get; set; }

        [DataMember]
        public int Nomor_Urut { get; set; }
    }
}