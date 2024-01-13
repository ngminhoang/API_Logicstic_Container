using Repositories_Do_An.DBcontext_vs_Entities;

namespace API_Do_An.APIModels
{
    public class FilteredOrdersResult
    {
        public OrderModel order { get; set; }
        public bool checkWAL { get; set; }
    }
}
