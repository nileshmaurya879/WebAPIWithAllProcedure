using FinalWebAPI.Dto;
using FinalWebAPI.Models;

namespace FinalWebAPI.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategory();
        Task<IEnumerable<Category>> GetAllCategoryWithPagination(int pagesize, int pageNumber);
        Task<IEnumerable<Category>> AddCategory(CategoryDto category);
        Task<IEnumerable<Category>> UpdateCategory(CategoryDto category);
        Task<IEnumerable<Category>> DeleteCategory(CategoryDto category);
        Task<bool> AddFile(FileDetails fileDetails);
        Task<List<FileDetails>> GetFile();
        Task<List<sp_StudentDetails>> GetStudentDetailsAsync(int studentId);
        Task<IEnumerable<Student>> GetStudents();
        Task<bool> AddStudents(Student student);
        Task<bool> UpdateStudent(Student student);
        Task<bool> DeleteStudent(int id);
        Task<(IEnumerable<Category> cate, int total)> GetOutputDate();
        Task<(IEnumerable<Category>, IEnumerable<Category>)> GetMultipleData();
    }
}
