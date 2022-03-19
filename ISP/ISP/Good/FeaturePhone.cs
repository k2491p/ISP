using System;
using System.Collections.Generic;
using System.Text;

namespace ISP.Good
{
    // ガラケー
    public sealed class FeaturePhone : IMail, ICall
    {
        public void SendMail()
        {
            // メールを送る
        }

        public void Call()
        {
            // 電話をする
        }

    }
}
