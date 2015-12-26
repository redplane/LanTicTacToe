using SharedLayer.Interfaces;

namespace ServiceLayer.Models
{
    public class Calculator : ICalculator
    {
        public double AddNumber(double dblX, double dblY)
        {
            return (dblX + dblY);
        }

        public double SubtractNumber(double dblX, double dblY)
        {
            return (dblX - dblY);
        }

        public double MultiplyNumber(double dblX, double dblY)
        {
            return (dblX*dblY);
        }

        public double DivideNumber(double dblX, double dblY)
        {
            if (dblY == 0.0)
                return 0;

            return dblX/dblY;
        }
    }
}