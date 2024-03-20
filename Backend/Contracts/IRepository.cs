namespace Backend.Contracts
{
    /// Represents a generic repository interface for performing data operations on entities.
    /// @typeparam T The type of entity.
    /// /
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Asynchronously retrieves a list of entities of type T.
        /// </summary>
        /// <typeparam name="T">The type of the entities.</typeparam>
        /// <returns>A task containing a list of entities of type T.</returns>
        /// <remarks>
        /// This method retrieves a list of entities of type T from a data source.
        /// The method execution is asynchronous.
        /// </remarks>
        Task<List<T>> GetEntitiesAsync();

        /// <summary>
        /// Retrieves an entity asynchronously by its ID. </summary> <param name="id">The ID of the entity to retrieve.</param> <returns>A task representing the asynchronous operation. The task result is the retrieved entity.</returns>
        /// /
        Task<T> GetEntityByIdAsync(int id);

        /// <summary>
        /// Creates a new entity asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of entity.</typeparam>
        /// <param name="entity">The entity to create.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean value indicating whether the entity was successfully created.</returns>
        /// <remarks>
        /// This method creates a new entity of the specified type asynchronously.
        /// </remarks>
        Task<bool> CreateEntityAsync(T entity);

        /// Updates an entity asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="entity">The entity to be updated.</param>
        /// <returns>A task representing the operation. The task result contains a boolean value indicating whether the update was successful or not.</returns>
        Task<bool> UpdateEntityAsync(T entity);

        /// <summary>
        /// Deletes the entity with the given ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to be deleted.</param>
        /// <returns>A task representing the asynchronous operation. The task result indicates whether the deletion was successful (true) or not (false).</returns>
        Task<bool> DeleteEntityAsync(int id);
    }
}
