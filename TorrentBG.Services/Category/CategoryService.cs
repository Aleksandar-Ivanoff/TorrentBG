namespace TorrentBG.Services.Category
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Data;
    using TorrentBG.Services.Category.Models;

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext data;

        public CategoryService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<CategoryDropDownServiceModel> GetCategoriesForDropDown()
        {
            return this.data.Categories
                .Select(x => new CategoryDropDownServiceModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();
        }

        public ICollection<string> GetCategoriesNameModel()
        {
            return this.data.Categories.Select(x => x.Name).ToList();
        }

        public string GetCategoryIdByName(string categoryName) => this.data.Categories.Where(x => x.Name == categoryName).Select(x=>x.Id).Single();
        
           
        
    }
}
