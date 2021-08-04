namespace TorrentBG.Services.Category
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
         ICollection<string> GetCategoriesForView();
        string GetCategoryIdByName(string categoryName);

    }
}
