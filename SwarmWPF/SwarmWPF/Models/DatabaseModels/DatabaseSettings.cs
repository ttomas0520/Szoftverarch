namespace SwarmWPF.Models.DatabaseModels
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string SimulationsCollectionName { get; set; } = null!;
    }
}
