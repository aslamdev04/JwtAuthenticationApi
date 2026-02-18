using CRUDOPERATIONAPIYOUTUBE1.Models;

namespace CRUDOPERATIONAPIYOUTUBE1.Interface
{
    public interface IStudentRepository
    {
        public Task<CommonResponse> CreateStudent(CreateStudent request);
        public Task<CommonResponse> DeleteStudent(int? ID);

        public Task<SelectStudents> SelectStudents();
        public Task<CreateStudentResponse> GetStudent(int? ID);

        public Task<CommonResponse> UpdateStudent(CreateStudent request);
    }
}
