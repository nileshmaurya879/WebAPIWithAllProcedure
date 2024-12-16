using FinalWebAPI.Dto;
using FinalWebAPI.Interface;
using FinalWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Runtime.InteropServices;

namespace FinalWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategory()
        {
            try
            {
                var data = await _categoryRepository.GetAllCategory();
                if (data?.Count() > 0)
                    return Ok(data);
                return NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("GetCategoryWithPagination")]
        public async Task<ActionResult> GetCategoryWithPagination(int pageSize,int pageNumber)
        {
            try
            {
                var data = await _categoryRepository.GetAllCategoryWithPagination(pageSize,pageNumber);
                if (data?.Count() > 0)
                    return Ok(data);
                return NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddCategory([FromBody] CategoryDto category)
        {
            try
            {
                var data = await _categoryRepository.AddCategory(category);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateCategory([FromBody] CategoryDto category)
        {
            try
            {
                var data = await _categoryRepository.UpdateCategory(category);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteCategory([FromBody] CategoryDto category)
        {
            try
            {
                var data = await _categoryRepository.DeleteCategory(category);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("AddFile")]
        public async Task<ActionResult> AddFile([FromForm] FileDetailsDto fileDetails,IFormFile formFile)
        {
            try
            {
                FileDetails fileDetails1 = new FileDetails() { FileName = fileDetails.FileName};
               
                using (var stream = new MemoryStream())
                {
                    formFile.CopyTo(stream);
                    fileDetails1.FileData = stream.ToArray();
                }
               
              
                var data = await _categoryRepository.AddFile(fileDetails1);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("Getfile")]
        public async Task<ActionResult> GetFile()
        {
            try
            {
                var data = await _categoryRepository.GetFile();
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("GetStudentDetails")]
        public async Task<ActionResult> GetStudentDetails(int studentId)
        {
            try
            {
                var data = await _categoryRepository.GetStudentDetailsAsync(studentId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("GetStudent")]
        public async Task<ActionResult> GetStudent()
        {
            try
            {
                var data = await _categoryRepository.GetStudents();
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("AddStudent")]
        public async Task<ActionResult> AddStudent([FromBody]Student student)
        {
            try
            {
                var data = await _categoryRepository.AddStudents(student);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut("UpdateStudent")]
        public async Task<ActionResult> UpdateStudent([FromBody] Student student)
        {
            try
            {
                var data = await _categoryRepository.UpdateStudent(student);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("DeleteStudent")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            try
            {
                var data = await _categoryRepository.DeleteStudent(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetStudent001")]
        public async Task<ActionResult> GetStudent001()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-GNQU118;Initial Catalog=TwstDBUpdateVersion_3.0.0;Integrated Security=True; Trust server certificate=true;");
                SqlCommand cmd = new SqlCommand("Select * from Student", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<Student> student = new List<Student>();
                while (dr.Read())
                {
                    Student student1 = new Student();
                    student1.StudentName = dr["StudentName"].ToString();
                    student1.StudentRollNo =Convert.ToInt32(dr["StudentRollNo"].ToString());
                    student.Add(student1);
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("AddStudent001")]
        public async Task<ActionResult> AddStudent001(Student student)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-GNQU118;Initial Catalog=TwstDBUpdateVersion_3.0.0;Integrated Security=True; Trust server certificate=true;");
                SqlCommand cmd = new SqlCommand("insert into Student(StudentName,StudentRollNo) values(@studenntName,@studentRollno)", con);
                cmd.Parameters.AddWithValue("@studenntName",student.StudentName);
                cmd.Parameters.AddWithValue("@studentRollno", student.StudentRollNo);
                con.Open();
                cmd.ExecuteNonQuery();
                return Ok(student);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("UpdateStudent001")]
        public async Task<ActionResult> UpdateStudent001(Student student)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-GNQU118;Initial Catalog=TwstDBUpdateVersion_3.0.0;Integrated Security=True; Trust server certificate=true;");
                SqlCommand cmd = new SqlCommand("Update Student set StudentName = @studenntName, StudentRollNo = @studentRollno where Id = @studId", con);
                cmd.Parameters.AddWithValue("@studenntName", student.StudentName);
                cmd.Parameters.AddWithValue("@studentRollno", student.StudentRollNo);
                cmd.Parameters.AddWithValue("@studId", student.Id);
                con.Open();
                cmd.ExecuteNonQuery();
                return Ok(student);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("DeleteStudent001")]
        public async Task<ActionResult> DeleteStudent001(int id)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-GNQU118;Initial Catalog=TwstDBUpdateVersion_3.0.0;Integrated Security=True; Trust server certificate=true;");
                SqlCommand cmd = new SqlCommand("Delete from Student where Id  = @studId", con);
                cmd.Parameters.AddWithValue("@studId", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("GetOutputData")]
        public async Task<ActionResult> GetOutputData()
        {
            try
            {
                var data = await _categoryRepository.GetOutputDate();
                return Ok(new { data.cate, data.total });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("GetMultipleData")]
        public async Task<ActionResult> GetMultipleData()
        {
            try
            {
                var data = await _categoryRepository.GetMultipleData();
                return Ok(new { data.Item1, data.Item2 });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("AddCategory_002")]
        public async Task<ActionResult> AddCategory_002([FromBody] CategoryDto category)
        {
            try
            {
                var data = await _categoryRepository.AddCategory_002(category);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("UpdateCategory_002")]
        public async Task<ActionResult> UpdateCategory_002([FromBody] CategoryDto category)
        {
            try
            {
                var data = await _categoryRepository.UpdateCategory_002(category);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteCategory_002")]
        public async Task<ActionResult> DeleteCategory_002(int CatId)
        {
            try
            {
                var data = await _categoryRepository.DeleteCategory_002(CatId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
