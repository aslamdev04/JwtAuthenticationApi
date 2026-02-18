namespace CRUDOPERATIONAPIYOUTUBE1.Models
{
    public class CreateStudent
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentDOB { get; set; }
        public string Branch { get; set; }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }

    }
    public class CommonResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
    public class CreateStudentResponse
    {
        //public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentDOB { get; set; }
        public string Branch { get; set; }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
    #region SelectAllRecord
    public class SelectStudents
    {
        public List<CreateStudent> Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
    #endregion
}
