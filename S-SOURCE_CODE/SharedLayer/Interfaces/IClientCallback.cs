using System.ServiceModel;

namespace SharedLayer.Interfaces
{
    public interface IClientCallback
    {
        [OperationContract]
        bool TempUpdate(double temp);
    }
}