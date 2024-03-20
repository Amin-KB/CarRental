namespace Backend.Contracts
{
    /// <summary>
    /// Represents a unit of work for a specific set of repositories.
    /// </summary>
    public interface IUnitOfWork
    {
         ICustomerRepo CustomerRepo { get;  }
         ICarRepo CarRepo { get;  }
         IRentRepo RentRepo { get;  }

        Task CompleteAsync();
    }
}
