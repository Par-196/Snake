using Snake.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Model
{
    public class Field
    {
        public Cell[,] Cells { get; set; }

        public Field(Cell[,] cells) 
        {
            Cells = cells;

            for (int x = 0; x < Cells.GetLength(0); x++)
            {
                for (int y = 0; y < Cells.GetLength(1); y++)
                {
                    if (x == 0 || y == 0 || x + 1 == Cells.GetLength(0) || y + 1 == Cells.GetLength(1))
                    {
                        Cells[x, y] = new Cell(TypeCell.Border);
                    }
                    else 
                    {
                        Cells[x, y] = new Cell(TypeCell.Empty);
                    }
                }
            }
        }

        public void ShowField()
        {
            for (int x = 0; x < Cells.GetLength(0); x++)
            {
                for (int y = 0; y < Cells.GetLength(1); y++)
                {
                    Console.Write(Cells[x ,y]);
                }
                Console.WriteLine();
            }
        }
    }
}
