namespace Backend.Contracts
{
    public interface IUnitOfWork
    {
         ICustomerRepo CustomerRepo { get;  }

        Task CompleteAsync();
    }
}
