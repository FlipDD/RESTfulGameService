using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace filnet
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1
    {
        private static List<UserData> Users = new List<UserData>(
       new UserData[] {
        new UserData("Peter", "peter", "12345"),
        new UserData("Fil", "fil", "12345"),
        new UserData("Mary", "mary@gmail.com", "54321"),
        new UserData("Bob", "bob@gmail.com", "bobbob")
       });

        static string GenerateSHA256Hash(string rawdata)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(
                rawdata));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
        UriTemplate = "/login", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        public LoginResponse Login(string email, string password)
        {
            var user = Users.FirstOrDefault(x => x.email == email && x.password == password);
            if (user != null)
            {
                user.hash = GenerateSHA256Hash(DateTime.Now.ToString());
                return new LoginResponse(ResponseStatus.Successed, user.id, user.name, user.hash, user.totalbeastpoints, user.totalbeastdeaths, user.totalmechapoints, user.totalmechadeaths);
            }
            return new LoginResponse(ResponseStatus.Failed, -1, "", "",
            -1, -1, -1, -1);    
        }

        [WebGet(UriTemplate = "/GetUserInfo?user={id}", ResponseFormat =
        WebMessageFormat.Json)]
        [OperationContract]
        public UserInfoResponse GetUserInfo(string id)
        {
            int uid = int.Parse(id);
            foreach (UserData udata in Users)
            {
                if (udata.id == uid)
                {
                    return new UserInfoResponse(ResponseStatus.Successed,
                    udata.name, udata.totalbeastpoints, udata.totalbeastdeaths, 
                    udata.totalmechapoints, udata.totalmechadeaths);
                }
            }
            return new UserInfoResponse(ResponseStatus.Failed, "", -1, -1, -1, -1);
        }

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
        UriTemplate = "/AddBeastPoint", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        public PostResponse AddUserBeastpoint(string userid, string hash)
        {
            int uid = int.Parse(userid);
            foreach (UserData udata in Users)
            {
                if ((udata.id == uid) && (udata.hash.Equals(hash)))
                {
                    udata.totalbeastpoints++;
                    return new PostResponse(ResponseStatus.Successed);
                }
            }
            return new PostResponse(ResponseStatus.Failed);
        }

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
        UriTemplate = "/AddMechaPoint", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        public PostResponse AddUserMechapoint(string userid, string hash)
        {
            int uid = int.Parse(userid);
            foreach (UserData udata in Users)
            {
                if ((udata.id == uid) && (udata.hash.Equals(hash)))
                {
                    udata.totalmechapoints++;
                    return new PostResponse(ResponseStatus.Successed);
                }
            }
            return new PostResponse(ResponseStatus.Failed);
        }

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
        UriTemplate = "/AddBeastDeath", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        public PostResponse AddUserBeastDeath(string userid, string hash)
        {
            int uid = int.Parse(userid);
            foreach (UserData udata in Users)
            {
                if ((udata.id == uid) && (udata.hash.Equals(hash)))
                {
                    udata.totalbeastdeaths++;
                    return new PostResponse(ResponseStatus.Successed);
                }
            }
            return new PostResponse(ResponseStatus.Failed);
        }

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
        UriTemplate = "/AddMechaDeath", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        public PostResponse AddUserMechaDeath(string userid, string hash)
        {
            int uid = int.Parse(userid);
            foreach (UserData udata in Users)
            {
                if ((udata.id == uid) && (udata.hash.Equals(hash)))
                {
                    udata.totalmechadeaths++;
                    return new PostResponse(ResponseStatus.Successed);
                }
            }
            return new PostResponse(ResponseStatus.Failed);
        }
    }
}
