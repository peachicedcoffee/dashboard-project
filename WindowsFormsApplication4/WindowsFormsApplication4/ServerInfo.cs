using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    public class ServerInfo
    {
        public ServerInfo()
        {
            DbType = DbType.MSSQL;
        }

        [DisplayName("db 타입")]
        public DbType DbType { get; set; }

        [DisplayName("서버 주소")]
        public string Server { get; set; }

        [DisplayName("포트")]
        public string Port { get; set; }

        public string DbName { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
    }
}
