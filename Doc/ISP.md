# SOLIDの原則とは？

SOLIDは

- 変更に強い
- 理解しやすい
などのソフトウェアを作ることを目的とした原則です。

次の5つの原則があります。

- Single Responsibility Principle (単一責任の原則)
- Open-Closed Principle (オープン・クローズドの原則)
- Liskov Substitution Principle (リスコフの置換原則)
- Interface Segregation Principle (インタフェース分離の原則)
- Dependency Inversion Principle (依存関係逆転の原則)

上記5つの原則の頭文字をとって**SOLID**の原則と言います。
今回の記事では**Interface Segregation Principle (インタフェース分離の原則)**について解説します。
その他の原則に関しては下記参照。
※随時追加予定！

# 簡単に言うと...

「**インターフェース継承先で使わないメソッドがないようにインターフェースをわけよう**」ということです。
尚、ここでいうインターフェスは、抽象クラスや基底クラスなども含んでいます。
具体例を用いながら詳しく見ていきましょう。

# 今回使用する例

ポケベル、ガラケー、スマートフォンを例に考えてみましょう。

※ここに画像

上記例をコードに落とし込みながら考えていきましょう。
※ポケベルやガラケーの細かい定義の話をし始めると、上記例と微妙にぶれたりしますので、今回は上記の仮定で話を進めます。

# インターフェース分離の原則に違反した例

ポケベル、ガラケー、スマートフォンの3つは共に電話の仲間です。
電話インターフェースを作ってコードを書いてみます。

※ここに画像

```c#:IPhone.cs
interface IPhone
{
    public void SendMail();
    public void Call();
    public void UseApp();
}
```

```c#:Pager.cs
// ポケベル
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
```

```c#:FeaturePhone.cs
// ガラケー
public sealed class FeaturePhone : IPhone
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
        // 使えない
    }
}
```

```c#:Smartphone.cs
// スマホ
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
```

`IPhone`というインターフェースにすべての振る舞いが記述されています。
すべてのクラスがこれを継承することにより、使用することのできないふるまいが定義されてしまいます。
例えば、ポケベルクラスは使用できないはずの「電話する」「アプリを使う」というふるまいが定義されています。
使用してはいけないというふるまいが定義されることで、
この仕様を知らない人が実装する際に、「ポケベルでアプリを使う」というエキセントリックなことができてしまいます。

# インターフェース分離の原則の適用例
解決方法は、文字通りインターフェースを分離していくことです。
今回は、

- メールする
- 電話する
- アプリを使う

という3つの機能があるため、それぞれを下記のように分離してみましょう。

※ここに画像

コードでの実装例は下記のようになります。

```c#:IMail.cs
interface IMail
{
    public void SendMail();
}
```



```c#:ICall.cs
interface ICall
{
    public void Call();
}
```



```c#:IApp.cs
interface IApp
{
    public void UseApp();
}
```



```c#:Pager.cs
// ポケベル
public sealed class Pager : IMail
{
    public void SendMail()
    {
        // メールを送る
    }
}
```



```c#:FeaturePhone.cs
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
```



```c#:Smartphone.cs
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
```

上記の例のように

- 必要となる最小限の機能ごとにインターフェースをわける
- 必要なインターフェースのみをすべて継承する

としていくことで、インターフェース分離の原則を達成することができます。



# まとめ
インターフェース分離の原則とは「**インターフェース継承先で使わないメソッドがないようにインターフェースをわけよう**」ということでした。
そうすることで下記のようなメリットが得られます。

- 変更に強い
- 理解しやすい

尚、今回使用したソースは[こちら](https://github.com/k2491p/ISP)に上がっています。

# 補足
本記事の中でのインターフェース分離の原則はざっくりとした理解を補助するもので正確性は欠いています。
正しい説明では
> 汎用なインターフェースが一つあるよりも、各クライアントに特化したインターフェースがたくさんあった方がよい

などと表現されています。
もう少し詳しいことが知りたい場合は、参考文献にあげているような本や記事を読んでみてください。

# 参考文献
- 本
  - [Clean Architecture 達人に学ぶソフトウェアの構造と設計](https://www.amazon.co.jp/Clean-Architecture-%E9%81%94%E4%BA%BA%E3%81%AB%E5%AD%A6%E3%81%B6%E3%82%BD%E3%83%95%E3%83%88%E3%82%A6%E3%82%A7%E3%82%A2%E3%81%AE%E6%A7%8B%E9%80%A0%E3%81%A8%E8%A8%AD%E8%A8%88-Robert-C-Martin/dp/4048930656)
- サイト
  - [きれいなコードを書くためにSOLID原則を学びました④ ~インターフェース分離の原則~](https://qiita.com/suzuki0430/items/040a186e5e8f51e6c11f)
  - [インターフェース分離の原則を考える](https://zenn.dev/maru44/articles/3405308b1b83bc)
  - [よくわかるSOLID原則4: I（インターフェース分離の原則）](https://note.com/erukiti/n/n3daa55541bc8)
  - [良い設計の第一歩!!単一責任の原則について](https://qiita.com/halkt/items/bd69962b605a00c3c842)
  - [SOLID - Wikipedia](https://ja.wikipedia.org/wiki/SOLID)
- 動画
  - [オブジェクト指向の原則３：依存関係逆転の原則とインタフェース分離の原則](https://www.udemy.com/course/objectfive3/)