using System.Linq;
using System.Runtime.Serialization;

namespace filnet
{
    public class UserData
    {
        private static int ID_CONT = 0;
        public int id;
        public string name;
        public string email;
        public string password;
        public int totalbeastpoints;
        public int totalbeastdeaths;
        public int totalmechapoints;
        public int totalmechadeaths;
        public string hash;
        public UserData(string nname, string nemail, string npass)
        {
            id = ID_CONT++;
            name = nname;
            email = nemail;
            password = npass;
            totalbeastpoints = 0;
            totalbeastdeaths = 0;
            totalmechapoints = 0;
            totalmechadeaths = 0;
        hash = "";
        }
    }

    public enum ResponseStatus { Successed, Failed };

    [DataContract]  
    public class LoginResponse
    {
        [DataMember] public ResponseStatus status;
        [DataMember] public int userid;
        [DataMember] public string name;
        [DataMember] public string hash;
        [DataMember] public int totalbeastpoints;
        [DataMember] public int totalbeastdeaths;
        [DataMember] public int totalmechapoints;
        [DataMember] public int totalmechadeaths;
        public LoginResponse(ResponseStatus nstatus, int nuserid, string
        nname, string nhash, int ntotalbeastpoints, int ntotalbeastdeaths, int ntotalmechapoints, int ntotalmechadeaths)
        {
            status = nstatus;
            userid = nuserid;
            name = nname;
            hash = nhash;
            totalbeastpoints = ntotalbeastpoints;
            totalbeastdeaths = ntotalbeastdeaths;
            totalmechapoints = ntotalmechapoints;
            totalmechadeaths = ntotalmechadeaths;
        }
    }

    [DataContract]
    public class UserInfoResponse
    {
        [DataMember] public ResponseStatus status;
        [DataMember] public string name;
        [DataMember] public int totalbeastpoints;
        [DataMember] public int totalbeastdeaths;
        [DataMember] public int totalmechapoints;
        [DataMember] public int totalmechadeaths;
        public UserInfoResponse(ResponseStatus nstatus, string nname, int ntotalbeastpoints, int ntotalbeastdeaths, int ntotalmechapoints, int ntotalmechadeaths)
        {
            status = nstatus;
            name = nname;
            totalbeastpoints = ntotalbeastpoints;
            totalbeastdeaths = ntotalbeastdeaths;
            totalmechapoints = ntotalmechapoints;
            totalmechadeaths = ntotalmechadeaths;
        }
    }

    [DataContract]
    public class PostResponse
    {
        [DataMember] public ResponseStatus status;
        public PostResponse(ResponseStatus nstatus)
        {
            status = nstatus;
        }
    } 
}