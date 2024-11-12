using Azure;
using Azure.Data.Tables;

public class MenuItem : ITableEntity
{
    public string PartitionKey { get; set; } = "CanteenMenu";
    public string RowKey { get; set; } // Day of the week
    public string ColdDish { get; set; }
    public string HotDish { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
}