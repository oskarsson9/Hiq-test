using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiq_test
{
    public class Room
    {
        public Room()
        {

        }
        public Room(int width, int height)
        {
            Width = width;
            Height = height;
            RoomPositions = new int[height, width];
        }
        public int Height { get; set; }

        public int Width { get; set; }

        public int[,] RoomPositions { get; set; }

        public void SetCarPosition(int x, int y)
        {
            RoomPositions = new int[Height, Width];
            RoomPositions[y, x] = 1;
        }

        public (int y, int x) GetCarPosition()
        {
            for (int y = 0; y < RoomPositions.GetLength(0); y++)
            {
                for (int x = 0; x < RoomPositions.GetLength(1); x++)
                {
                    if (RoomPositions[y, x] == 1)
                    {
                        return (y, x);
                    }
                }
            }

            return (0, 0);
        }
    }
}
