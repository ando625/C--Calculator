// ========================================
// 計算の処理をまとめたクラス
// ========================================

namespace Calculator
{
    // "class CalculatorHelper" = 計算を担当する設計図
    // Programクラスとは別の「部屋」に計算ロジックを分けた
    class CalculatorHelper
    {
        // "static void Run()" = このクラスの「メイン処理の部屋」
        // static = クラスからそのまま呼べる（new しなくていい）
        // void = 「この部屋は結果を返さない（表示するだけ）」
        // 「計算結果を画面に表示する担当」 ユーザーとの会話担当
        //① 数字A入力 ②演算子入力 ③数字B入力 ④Calculate() に計算依頼 ⑤結果表示
        public static void Run()
        {
            // =============================================
            // ① 計算履歴を保存するリストを用意する
            // List<string> = 文字列をいくつでも入れられる箱
            // 例：["10 + 5 = 15", "3 * 4 = 12"] のように増えていく
            // =============================================
            List<String> history = new List<string>();

            // =============================================
            // ② while ループ = 条件がtrueの間ずっと繰り返す
            // true を直接書く = 「永遠に繰り返す」
            // （抜け出すには break を使う）
            // =============================================
            while (true)
            {
                Console.WriteLine("\n--- 計算を入力してください ---");

                // =============================================
                // ③ 数字Aの入力（エラーハンドリング付き）
                // double.TryParse = 変換できたら true、失敗したら false を返す
                // Parse と違ってクラッシュしない！安全版
                // =============================================
                // Console.Write = 改行しないで表示（入力を同じ行に受け付けるため）
                Console.Write("数字Aを入力してください: ");

                // Console.ReadLine() = キーボードから1行読み取る命令
                // 読み取った文字は "string"（文字列）型
                string? inputA = Console.ReadLine();

                // out numberA = 「変換成功したら numberA に入れて」という意味
                // !double.TryParse = 「変換に失敗したら」
                if (!double.TryParse(inputA, out double numberA))
                {
                    // Console.ForegroundColor = 文字の色を変える
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌数字を入力してください");
                    Console.ResetColor();
                    // continue = 「ループの先頭に戻る（やり直す）」
                    continue;
                }

                // =============================================
                // ④ 演算子の入力
                // =============================================
                Console.Write("演算子を入力してください (+ - * /):");
                // string? = 文字列型（? = 空っぽ＝nullの可能性あり、という意味）
                string? op = Console.ReadLine();

                // =============================================
                // ⑤ 数字Bの入力（エラーハンドリング付き）
                // =============================================
                Console.Write("数字Bを入力してください:");
                string? inputB = Console.ReadLine();

                if (!double.TryParse(inputB, out double numberB))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ 数字を入力してください！");
                    Console.ResetColor();
                    continue;
                }

                // =============================================
                // ⑥ 計算して結果を表示
                // =============================================
                // Calculate() という別の部屋に計算を任せる
                // 結果を "result" という変数に入れる
                double result = Calculate(numberA, op!, numberB);
                string resultText = $"{numberA} {op} {numberB} = {result}";
                Console.WriteLine($"✅ 結果: {resultText}");

                // =============================================
                // ⑦ 履歴リストに追加
                // history.Add() = リストの末尾に1件追加する
                // =============================================
                history.Add(resultText);

                // =============================================
                // ⑧ 続けるか聞く
                // =============================================
                Console.Write("\n続けますか？(y = 続ける / h = 履歴 / それ以外 = 終了):");
                string? answer = Console.ReadLine();

                if (answer == "y")
                {
                    // "y" が入力されたら → ループの先頭に戻って続ける
                    continue;
                }
                else if (answer == "h")
                {
                    // "h" が入力されたら → 履歴を表示する
                    Console.WriteLine("\n📝 計算履歴:");

                    // foreach = リストの中身を1件ずつ取り出して繰り返す
                    // item に1件ずつ入ってくる
                    foreach (string item in history)
                    {
                        Console.WriteLine($"  • {item}");
                    }
                    // 履歴表示後もループを続ける
                    continue;

                }
                else
                {
                    // y でも h でもなければ終了
                    Console.WriteLine("電卓を修了します。またね！👋");
                    // break = 「whileループを抜け出す」
                    break;
                }




            }

        }


        // --------- 計算ロジックの部屋 ---------
        // "private" = このクラスの中からしか呼べない（外から使わせない）
        // "double" = 小数も扱える数値を「返す」
        // 引数（材料）：a（数字A）、op（演算子）、b（数字B）
        //計算をして答えを返す
        private static double Calculate(double a, string op, double b)
        {
            // switch = 「opの中身によって処理を切り替える」
            // if文をたくさん書く代わりに、switch でスッキリ書ける！
            switch (op)
            {
                case "+":
                    // "return" = 「この値を答えとして返す」
                    return a + b;

                case "-":
                    return a - b;

                case "*":
                    return a * b;

                case "/":
                    // 0で割ると数学的にエラーになるのでチェック！
                    // "b == 0" = 「bがゼロかどうか確認して」
                    if (b == 0)
                    {
                        // 赤いエラーメッセージで警告を出す
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("エラー：0で割ることはできません！");
                        Console.ResetColor();
                        // エラーのときは 0 を返しておく
                        return 0;
                    }
                    return a / b;

                default:
                    // どれにも当てはまらない演算子が来たとき
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("エラー：対応していない演算子です");
                    Console.ResetColor();
                    return 0;
            }
        }
    }

}