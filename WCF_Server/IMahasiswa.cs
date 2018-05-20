using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Server
{
    [ServiceContract]
    public interface IMahasiswa
    {
        [OperationContract]
        bool login(string ID, string Password);
    }
}
