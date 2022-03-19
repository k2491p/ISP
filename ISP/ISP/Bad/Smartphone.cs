using System;
using System.Collections.Generic;
using System.Text;

namespace ISP.Bad
{
    public sealed class Smartphone : IPhone
    {
        public void SendMail()
        {
            // メールを送る
        }

        public void Call()
        {
            // 電話をする
        }

        public void UseApp()
        {
            // アプリを使う
        }
    }
}
