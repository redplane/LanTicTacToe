using System.ServiceModel;

namespace SharedLayer.Interfaces
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        double AddNumber(double dblX, double dblY);

        [OperationContract]
        double SubtractNumber(double dblX, double dblY);

        [OperationContract]
        double MultiplyNumber(double dblX, double dblY);

        [OperationContract]
        double DivideNumber(double dblX, double dblY);
    }
}
