using System;
using System.Collections.Generic;
using System.Text;

namespace ISP.Good
{
    // スマートフォン
    public sealed class Smartphone : IMail, ICall, IApp
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
