namespace HORTI.USER.CROSSCUTTING.DBBASEMONGO.CONNECTION
{
    public sealed class MongoDBHortiConnection : IMongoDBHortiConnection
    {
        public string SessionCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMongoDBHortiConnection
    {
        string SessionCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
