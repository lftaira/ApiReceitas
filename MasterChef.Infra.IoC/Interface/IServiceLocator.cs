namespace MasterChef.Infra.IoC.Interface
{
    public interface IServiceLocator
    {
        T GetService<T>();
    }
}