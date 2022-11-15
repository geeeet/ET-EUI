namespace ET
{
    public static partial class ErrorCode
    {
        public const int ERR_Success = 0;

        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误

        // 110000以下的错误请看ErrorCore.cs

        // 这里配置逻辑层的错误码
        // 110000 - 200000是抛异常的错误
        // 200001以上不抛异常

        public const int ERR_NetWorkError = 200002;
        public const int ERR_LoginInfoError = 2000003;  //登录网络消息错误
        public const int ERR_LoginAccountNameError = 2000004;
        public const int ERR_LoginAccountPasswordError = 2000005;
        public const int ERR_LoginAccountBlackListError = 2000006;
    }
}