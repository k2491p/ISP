using System;
using System.Collections.Generic;
using System.Text;

namespace ISP.Bad
{
    public sealed class Pager : IPhone
    {
        public void SendMail()
        {
            // メールを送る
        }

        public void Call()
        {
            // 電話をする
            // 使えない
        }

        public void UseApp()
        {
            // アプリを使う
            // 使えない
        }
    }
}
