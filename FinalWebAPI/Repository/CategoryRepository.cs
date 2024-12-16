using FinalWebAPI.Dto;
using FinalWebAPI.Interface;
using FinalWebAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace FinalWebAPI.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        public readonly CategoryDBContext _categoryDBContext;
        public CategoryRepository(CategoryDBContext categoryDBContext) { 
            _categoryDBContext = categoryDBContext;
        }
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            var data = await _categoryDBContext.Category.FromSqlRaw<Category>(@"exec sp_GetAllCategory001").ToListAsync();
            return data;
        }
        public async Task<IEnumerable<Category>> GetAllCategoryWithPagination(int pagesize, int pageNumber)
        {
            var param = new List<SqlParameter>();
            param.Add(new SqlParameter("@pageSize", pagesize));
            param.Add(new SqlParameter("@pageNumber", pageNumber));
            var data = await _categoryDBContext.Category.FromSqlRaw<Category>(@"exec sp_GetCategory001 @pageSize, @pageNumber", param.ToArray()).ToListAsync();
            return data;
        }
        public async Task<IEnumerable<Category>> AddCategory(CategoryDto category)
        {
            var catid = new SqlParameter("@catId", category.CategoryId);
            var catName = new SqlParameter("@catName", category.CategoryName);
            var catopr = new SqlParameter("@operation", category.Operation);
            var data = await _categoryDBContext.Database.ExecuteSqlRawAsync(@"exec sp_AddCategory001 @catId, @catName, @operation", catid, catName, catopr);
            return null;
        }
        public async Task<IEnumerable<Category>> UpdateCategory(CategoryDto category)
        {
            var catid = new SqlParameter("@catId", category.CategoryId);
            var catName = new SqlParameter("@catName", category.CategoryName);
            var catopr = new SqlParameter("@operation", category.Operation);
            var data = await _categoryDBContext.Database.ExecuteSqlRawAsync(@"exec sp_AddCategory001 @catId, @catName, @operation", catid, catName, catopr);
            return null;
        }
        public async Task<IEnumerable<Category>> DeleteCategory(CategoryDto category)
        {
            var catid = new SqlParameter("@catId", category.CategoryId);
            var catName = new SqlParameter("@catName", category.CategoryName);
            var catopr = new SqlParameter("@operation", category.Operation);
            var data = await _categoryDBContext.Database.ExecuteSqlRawAsync(@"exec sp_AddCategory001 @catId, @catName, @operation", catid, catName, catopr);
            return null;
        }

        public async Task<bool> AddFile(FileDetails fileDetails)
        {
            await _categoryDBContext.FileDetails.AddAsync(fileDetails);
            await _categoryDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<FileDetails>> GetFile()
        {
            var data = await _categoryDBContext.FileDetails.ToListAsync();
            return data;
        }
        public async Task<List<sp_StudentDetails>> GetStudentDetailsAsync(int studentId)
        {
            List<SqlParameter> sqlParameter = new List<SqlParameter>();
            sqlParameter.Add(new SqlParameter("@studentId", studentId));

            var test2 = await _categoryDBContext.TempModels.FromSqlRaw("exec GetStudentDetails @studentId", sqlParameter.ToArray()).ToListAsync();
            var test1 = await _categoryDBContext.StudentNames.FromSqlRaw("exec GetStudentDetails @studentId", sqlParameter.ToArray()).ToListAsync();
            var test3 = await _categoryDBContext.TotalModels.FromSqlRaw("exec GetStudentDetails @studentId", sqlParameter.ToArray()).ToListAsync();

            var data = await _categoryDBContext.StudentDetails.FromSqlRaw("exec GetSubjectDetails @studentId",sqlParameter.ToArray()).ToListAsync();

            return data;
        }
        public async Task<IEnumerable<Student>> GetStudents()
        {
            var data = await _categoryDBContext.Student.ToListAsync();
            return data;
        }
        public async Task<bool> AddStudents(Student student)
        {
            await _categoryDBContext.Student.AddAsync(student);
            await _categoryDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            _categoryDBContext.Student.Update(student);
            await _categoryDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteStudent(int id)
        {
            var data = await _categoryDBContext.Student.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(data != null)
            {
                _categoryDBContext.Student.Remove(data);
                await _categoryDBContext.SaveChangesAsync();
            }
            return true;
        }
        public async Task<(IEnumerable<Category> cate,int total)> GetOutputDate()
        {
            SqlParameter id = new SqlParameter("@id", 2);
            SqlParameter sqlParameter = new SqlParameter()
            {
                ParameterName = "@cnt",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output,
            };
            var data = await _categoryDBContext.Category.FromSqlRaw(@"exec sp_output @id, @cnt output", id, sqlParameter).ToListAsync();
            int finalData = 0;
            if (data != null)
            {
                finalData = (int)sqlParameter.Value;
            }
            return (data, finalData);
        }

        public async Task<(IEnumerable<Category>, IEnumerable<Category>)> GetMultipleData()
        {
            var categories = new List<Category>();
            var specificCategories = new List<Category>();

            using (var command = _categoryDBContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_getmutipleSp";
                command.CommandType = CommandType.StoredProcedure;

                //add parameter
                var parameterId = command.CreateParameter();
                parameterId.ParameterName = "@id";
                parameterId.Value = 2;
                command.Parameters.Add(parameterId);

                var parameterName = command.CreateParameter();
                parameterName.ParameterName = "@name";
                parameterName.Value = "test002";
                command.Parameters.Add(parameterName);

                _categoryDBContext.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        categories.Add(new Category
                        {
                            CategoryId = result.GetInt32(0),
                            CategoryName = result.GetString(1),
                            // Map other properties as needed
                        });
                    }

                    result.NextResult();

                    while (result.Read())
                    {
                        specificCategories.Add(new Category
                        {
                            CategoryId = result.GetInt32(0),
                            CategoryName = result.GetString(1),
                            // Map other properties as needed
                        });
                    }
                }
            }
            return (categories,specificCategories);
        }

        public async Task<bool> AddCategory_002(CategoryDto category)
        {
            var catName = new SqlParameter("@catName", category.CategoryName);
            await _categoryDBContext.Database.ExecuteSqlRawAsync(@"exec sp_AddCategory_002 @catName", catName);
            return true;
        }

        public async Task<bool> UpdateCategory_002(CategoryDto category)
        {
            var catId = new SqlParameter("@CatId", category.CategoryId);
            var catName = new SqlParameter("@catName", category.CategoryName);
            await _categoryDBContext.Database.ExecuteSqlRawAsync(@"exec sp_UpdateCategory_002 @CatId,@catName", catId,catName);
            return true;
        }

        public async Task<bool> DeleteCategory_002(int CatId)
        {
            var catId = new SqlParameter("@CatId", CatId);
            await _categoryDBContext.Database.ExecuteSqlRawAsync(@"exec sp_DeleteCategory @CatId", catId);
            return true;
        }

    }
}
