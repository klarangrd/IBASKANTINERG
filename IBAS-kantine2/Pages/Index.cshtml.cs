using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IndexCSS
{
    public class IndexModel : PageModel
    {
        private readonly TableClient _tableClient;
        private readonly string connectionString = "DefaultEndpointsProtocol=https;EndpointSuffix=core.windows.net;AccountName=ibasbikeproductionklara;AccountKey=tYjOHBSk7X19PyCg56caEKfZc0aMtSHQ4HiAOg2FFyhM/XdtWXlTGL0v9QKOBYQ2bA1Rxgf+IMxe+ASt25TUBw==;BlobEndpoint=https://ibasbikeproductionklara.blob.core.windows.net/;FileEndpoint=https://ibasbikeproductionklara.file.core.windows.net/;QueueEndpoint=https://ibasbikeproductionklara.queue.core.windows.net/;TableEndpoint=https://ibasbikeproductionklara.table.core.windows.net/";

        public List<MenuItem> MenuItems { get; set; } = new();

        public IndexModel()
        {
            _tableClient = new TableClient(connectionString, "WeeklyMenu"); // Ensure this matches your table name
        }

        public void OnGet()
        {
            try
            {
                // Fetch all items with PartitionKey "CanteenMenu"
                var items = _tableClient.Query<MenuItem>(m => m.PartitionKey == "CanteenMenu");

                foreach (var item in items)
                {
                    Console.WriteLine($"Day: {item.RowKey}, ColdDish: {item.ColdDish}, HotDish: {item.HotDish}");
                    MenuItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // For development, consider displaying the error on the page temporarily for troubleshooting
            }
        }
    }
}
