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
        public int totalpoints;
        public int totaldeaths;
        public string hash;
        public UserData(string nname, string nemail, string npass)
        {
            id = ID_CONT++;
            name = nname;
            email = nemail;
            password = npass;
            totalpoints = 0;
            totaldeaths = 0;
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
        [DataMember] public int totalpoints;
        [DataMember] public int totaldeaths;
        public LoginResponse(ResponseStatus nstatus, int nuserid, string
        nname, string nhash, int ntotalpoints, int ntotaldeaths)
        {
            status = nstatus;
            userid = nuserid;
            name = nname;
            hash = nhash;
            totalpoints = ntotalpoints;
            totaldeaths = ntotaldeaths;
        }
    }

    [DataContract]
    public class UserInfoResponse
    {
        [DataMember] public ResponseStatus status;
        [DataMember] public string name;
        [DataMember] public int totalpoints;
        [DataMember] public int totaldeaths;
        public UserInfoResponse(ResponseStatus nstatus, string nname, int
        ntotalpoints, int ntotaldeaths)
        {
            status = nstatus;
            name = nname;
            totalpoints = ntotalpoints;
            totaldeaths = ntotaldeaths;
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