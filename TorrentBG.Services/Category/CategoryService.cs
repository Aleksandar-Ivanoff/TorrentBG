namespace TorrentBG.Services.Category
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Data;

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext data;

        public CategoryService(ApplicationDbContext data)
        {
            this.data = data;
        }
        public ICollection<string> GetCategoriesForView()
        {
            return this.data.Categories.Select(x => x.Name).ToList();
        }

        public string GetCategoryIdByName(string categoryName) => this.data.Categories.Where(x => x.Name == categoryName).Select(x=>x.Id).Single();
        
           
        
    }
}
