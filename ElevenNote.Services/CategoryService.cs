using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }
        // Create

        public bool CreateCategory(CategoryCreate model)
        {
            var entity = new Category()
            {
                OwnerId = _userId,
                CategoryName = model.Title,
                CategoryDescription = model.Description
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Read

        public IEnumerable<CategoryListItem> GetCategory()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Categories
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new CategoryListItem
                        {
                            CategoryId = e.CategoryId,
                            Title = e.CategoryName,
                            Description = e.CategoryDescription
                           
                        }
                    );
                return query.ToArray();

            }
        }

        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == id && e.OwnerId == _userId);

                return
                    new CategoryDetail
                    {
                        CategoryId = entity.CategoryId,
                        CategoryName = entity.CategoryName,
                        CategoryDescription = entity.CategoryDescription
                    };
            }
        }

        // Update

        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext()) 
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == model.CategoryId && e.OwnerId == _userId);

                entity.CategoryName = model.CategoryName;
                entity.CategoryDescription = model.CategoryDescription;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete

        public bool DeleteCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == categoryId && e.OwnerId == _userId);

                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
