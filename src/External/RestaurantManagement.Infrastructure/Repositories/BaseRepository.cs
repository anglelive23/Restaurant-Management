namespace RestaurantManagement.Infrastructure.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        #region Fields and Properties
        protected readonly RestaurantContext _context;
        #endregion

        #region Constructors
        public BaseRepository(RestaurantContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        #endregion

        #region Interface Implementation
        public IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate = null)
        {
            try
            {
                IQueryable<T>? data = _context
                      .Set<T>();

                if (predicate is not null)
                    data = data.Where(predicate);

                return data;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _context
                    .Set<T>().FindAsync(id);

                return entity;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }
        #endregion
    }
}
