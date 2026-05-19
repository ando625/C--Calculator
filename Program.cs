// ========================================
// 電卓アプリ
// ========================================

// アプリの入り口 - Mainメソッド
// "namespace" = このプログラムの「名前のグループ」（引き出しのラベルみたいなもの）

namespace Calculator
{
    // "class" = プログラムの設計図（「電卓」という設計図を作る）
    class Program
    {
        // "static void Main" = プログラムが起動したとき「最初に動く部屋」
        // ここから処理がスタートする！
        static void Main(string[] args)
        {
            // Console.WriteLine = 画面に文字を表示する命令
            // "=" が「表示しろ」ではなく WriteLine() が「表示しろ」
            Console.WriteLine("=============================");
            Console.WriteLine("    ようこそ！C# 電卓アプリ    ");
            Console.WriteLine("=============================");

            // CalculatorHelper というクラスの「Run」という部屋を呼び出す
            // → 実際の計算処理はそっちに書く（役割を分ける！）
            CalculatorHelper.Run();
        }
    }
}