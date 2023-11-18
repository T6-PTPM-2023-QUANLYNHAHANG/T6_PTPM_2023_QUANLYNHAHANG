using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Account_DTO
    {
        string _username;
        string _displayname;
        string _password;
        int? _idType;

        public Account_DTO(string username, string displayname, string password, int? idType)
        {
            _username = username;
            _displayname = displayname;
            _password = password;
            _idType = idType;
        }
        public Account_DTO()
        {
            
        }
        public string Username { get => _username; set => _username = value; }
        public string Displayname { get => _displayname; set => _displayname = value; }
        public string Password { get => _password; set => _password = value; }
        public int? IdType { get => _idType; set => _idType = value; }
    }
}
