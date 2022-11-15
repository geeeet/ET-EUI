using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{

    public enum AccountType
    {
        General = 0,
        BlackList = 1,
    }

    [ChildType]
    public class Account : Entity, IAwake
    {
        /// <summary>
        /// 账户名
        /// </summary>
        private string accountName;
        /// <summary>
        /// 密码
        /// </summary>
        private string password;
        /// <summary>
        /// 账号创建时间
        /// </summary>
        private long createTime;

        private int accountType;

        public string AccountName { get => accountName; set => accountName = value; }
        public string Password { get => password; set => password = value; }
        public long CreateTime { get => createTime; set => createTime = value; }
        public int AccountType { get => accountType; set => accountType = value; }
    }
}
