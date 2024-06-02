
namespace AppBlog.Models.Dto
{
    public class UserListParams
    {
        public string? filterField { get; set; }
        public string? filterValue { get; set; }
        public string? sortField { get; set; }
        public bool sortAsc { get; set; } = true;
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 10;

        public void Deconstruct(
            out string filterField,
            out string filterValue,
            out string sortField,
            out bool sortAsc,
            out int page,
            out int pageSize
        )
        {
            filterField = this.filterField;
            filterValue = this.filterValue;
            sortField = this.sortField;
            sortAsc = this.sortAsc;
            page = this.page;
            pageSize = this.pageSize;
        }
    }
}
