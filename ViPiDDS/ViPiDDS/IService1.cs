using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ViPiDDS
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        ViUsrLst ViUsrLctn(ViUsrDtl ViUsr, Boolean mode, RemoteFileInfo request);
        
    }


    [DataContract]
    public class ViUsrDtl
    {
        String uid   = "XXXXXXXXX" ;
        float  lang  = 000.0000F ;
        float  lat   = 000.0000F;

        [DataMember]
        public String UID
        {
            get { return uid;  }
            set { uid = value; }
        }

        [DataMember]
        public float Lang
        {
            get { return lang;  }
            set { lang = value; }
        }

        [DataMember]
        public float Lat
        {
            get { return lat;  }
            set { lat = value; }
        }
    }

    [DataContract]
    public class ViUsrLst
    {
        List<String> uidLst   = new List<string>();
        Boolean  check ;
        String filePath;

        [DataMember]
        public List<String> UidLst
        {
            get { return uidLst; }
            set { uidLst = value; }
        }

        [DataMember]
        public Boolean Check
        {
            get { return check;  }
            set { check = value; }
        }

        [DataMember]
        public String FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

    }

    
    [MessageContract]
    public class RemoteFileInfo : IDisposable
    {
        [MessageHeader(MustUnderstand = true)]
        public string FileName;

        [MessageHeader(MustUnderstand = true)]
        public long Length;

        [MessageBodyMember(Order = 1)]
        public System.IO.Stream FileByteStream;

        public void Dispose()
        { 
            if (FileByteStream != null)
            {
                FileByteStream.Close();
                FileByteStream = null;
            }
        }   
    }
}
