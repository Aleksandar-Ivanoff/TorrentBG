namespace TorrentBG.Services.Category
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Services.Category.Models;

    public interface ICategoryService
    {
         ICollection<string> GetCategoriesNameModel();
        string GetCategoryIdByName(string categoryName);

       IEnumerable<CategoryDropDownServiceModel> GetCategoriesForDropDown();
            

    }
}
