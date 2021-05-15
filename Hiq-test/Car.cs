namespace Hiq_test
{
    public class Car
    {
        public Car()
        {

        }
        public Car(string heading)
        {
            Heading = heading;
        }

        public string Heading { get; set; }

        public void Move(string commands, Room room)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'F':
                        MoveForward(room);
                        break;
                    case 'B':
                        MoveBackwords(room);
                        break;
                    case 'L':
                        RotateLeft();
                        break;
                    case 'R':
                        RotateRight();
                        break;
                }
            }
        }

        private void MoveForward(Room room)
        {
            var (carPositionY, carPositionX) = room.GetCarPosition();

            switch (Heading)
            {
                case "N":
                    room.SetCarPosition(carPositionX, carPositionY + 1);
                    break;
                case "S":
                    room.SetCarPosition(carPositionX, carPositionY - 1);
                    break;
                case "W":
                    room.SetCarPosition(carPositionX - 1, carPositionY);
                    break;
                case "E":
                    room.SetCarPosition(carPositionX + 1, carPositionY);
                    break;
            }
            
        }

        private void MoveBackwords(Room room)
        {
            var (carPositionY, carPositionX) = room.GetCarPosition();

            switch (Heading)
            {
                case "N":
                    room.SetCarPosition(carPositionX, carPositionY - 1);
                    break;
                case "S":
                    room.SetCarPosition(carPositionX, carPositionY + 1);
                    break;
                case "W":
                    room.SetCarPosition(carPositionX + 1, carPositionY);
                    break;
                case "E":
                    room.SetCarPosition(carPositionX - 1, carPositionY);
                    break;
            }
        }

        private void RotateLeft()
        {
            switch (Heading)
            {
                case "N":
                    Heading = "W";
                    break;
                case "S":
                    Heading = "E";
                    break;
                case "W":
                    Heading = "S";
                    break;
                case "E":
                    Heading = "N";
                    break;
            }
        }

        private void RotateRight()
        {
            switch (Heading)
            {
                case "N":
                    Heading = "E";
                    break;
                case "S":
                    Heading = "W";
                    break;
                case "W":
                    Heading = "N";
                    break;
                case "E":
                    Heading = "S";
                    break;
            }
        }

    }
}
