using System;
using System.Collections.Generic;

namespace aoc_2021
{
    public static class Day04
    {
        public static string[] GetNumbers(string nums)
        {
            return nums.Split(',');
        }

        public static List<Board> GetBoards(string[] data)
        {
            var boards = new List<Board>();
            for (int i = 1; i < data.Length; i++)
            {
                if (data[i].Length == 0)
                {
                    //get the next 5 rows
                    string[] rows = {
                        data[i+1],
                        data[i+2],
                        data[i+3],
                        data[i+4],
                        data[i+5]
                    };

                    var b = new Board(rows);
                    i += 5;
                    boards.Add(b);
                }
            }
            return boards;
        }

        public static int GetFirstWinScore(string[] data)
        {
            var numbers = GetNumbers(data[0]);
            var boards = GetBoards(data);
            foreach (var num in numbers)
            {
                foreach (var board in boards)
                {
                    for (int i = 0; i < board.rows.Count; i++)
                    {
                        for (int j = 0; j < board.cols.Count; j++)
                        {
                            if (board.rows[i][j] == num)
                            {
                                board.rows[i][j] = "X";
                                board.cols[j][i] = "X";
                            }
                        }
                    }

                    if (board.CheckCols() || board.CheckRows())
                    {
                        System.Console.WriteLine($"This board wins. \n{board}");
                        return board.GetScore(Convert.ToInt32(num));
                    }
                }
            }
            return 0;
        }


        public static int GetLastWinScore(string[] data)
        {
            var numbers = GetNumbers(data[0]);
            var boards = GetBoards(data);
            int lastWinnerScore = 0;
            foreach (var num in numbers)
            {
                foreach (var board in boards)
                {
                    if (board.completed)
                    {
                        continue;
                    }

                    for (int i = 0; i < board.rows.Count; i++)
                    {
                        for (int j = 0; j < board.cols.Count; j++)
                        {
                            if (board.rows[i][j] == num)
                            {
                                board.rows[i][j] = "X";
                                board.cols[j][i] = "X";
                            }
                        }
                    }

                    if (board.CheckCols() || board.CheckRows())
                    {
                        System.Console.WriteLine($"This board wins. \n{board}");
                        board.completed = true;
                        lastWinnerScore = board.GetScore(Convert.ToInt32(num));
                    }
                }
            }
            return lastWinnerScore;
        }

        public class Board
        {
            public List<string[]> rows;
            public List<string[]> cols;

            public bool completed;
            public Board(string[] rows)
            {
                this.completed = false;
                this.rows = new List<string[]>();
                this.cols = new List<string[]>();

                for (int i = 0; i < rows.Length; i++)
                {
                    this.rows.Add(rows[i].Split(' ', StringSplitOptions.RemoveEmptyEntries));
                }

                for (int i = 0; i < this.rows.Count; i++)
                {
                    this.cols.Add(new string[] {
                        this.rows[0][i],
                        this.rows[1][i],
                        this.rows[2][i],
                        this.rows[3][i],
                        this.rows[4][i],
                    });
                }
            }

            public override string ToString()
            {
                string res = "";
                for (int i = 0; i < this.rows.Count; i++)
                {
                    for (int j = 0; j < this.cols.Count; j++)
                    {
                        res += this.rows[i][j] + ",";
                    }
                    res += "\n";
                }
                return res;
            }

            public bool CheckRows()
            {
                foreach (var row in this.rows)
                {
                    bool allMarked = true;
                    foreach (var s in row)
                    {
                        if (s != "X")
                        {
                            allMarked = false;
                        }
                    }
                    if (allMarked == true)
                    {
                        return true;
                    }
                }
                return false;
            }
            public bool CheckCols()
            {
                foreach (var col in this.cols)
                {
                    bool allMarked = true;
                    foreach (var s in col)
                    {
                        if (s != "X")
                        {
                            allMarked = false;
                        }
                    }
                    if (allMarked == true)
                    {
                        return true;
                    }
                }
                return false;
            }

            public int GetScore(int factor)
            {
                int score = 0;
                foreach (var row in this.rows)
                {
                    foreach (var s in row)
                    {
                        score += s == "X" ? 0 : Convert.ToInt32(s);
                    }
                }
                return score * factor;
            }
        }
    }
}