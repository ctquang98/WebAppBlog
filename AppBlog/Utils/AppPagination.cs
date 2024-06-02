using Microsoft.EntityFrameworkCore;

namespace AppBlog.Utils
{
    public class AppPagination<T>
    {
        public AppPagination(int currentPage, int pageSize, int totalItems, List<T> items)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            TotalItems = totalItems;
            Items = items;
        }

        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public List<T> Items { get; set; } = new List<T>();

        public static async Task<AppPagination<T>> handlePagination(IQueryable<T> queryable, int currentPage, int pageSize)
        {
            var totalItems = await queryable.CountAsync();
            var list = await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
            return new AppPagination<T>(currentPage, pageSize, totalItems, list);
        }
    }
}
