namespace DatabaseAccess
{
    public interface ISQLDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T, P>(string sql, P parameters);
        Task SaveData<T>(string sql, T parameters);
    }
}