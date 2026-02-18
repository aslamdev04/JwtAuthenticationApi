using CRUDOPERATIONAPIYOUTUBE1.Interface;
using CRUDOPERATIONAPIYOUTUBE1.Models;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using Microsoft.AspNetCore.Server.HttpSys;


namespace CRUDOPERATIONAPIYOUTUBE1.Repository
{
    public class StudentRepository:IStudentRepository
    {
        private readonly string _configuration;
        public StudentRepository(IConfiguration configuration)
        {
            _configuration= configuration.GetConnectionString("ANGULARCRUD") ;
        }
        async Task<CommonResponse> IStudentRepository.CreateStudent(CreateStudent request)
        {
            var response = new CommonResponse();
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@StudentName", request.StudentName, DbType.String);
                parameters.Add("@StudentEmail", request.StudentEmail, DbType.String);
                parameters.Add("@StudentDOB", request.StudentDOB, DbType.String);
                parameters.Add("@Branch", request.Branch, DbType.String);
                parameters.Add("@MobileNumber", request.MobileNumber, DbType.String);
                parameters.Add("@MobileNumber", request.MobileNumber, DbType.String);
                parameters.Add("@IsActive", request.IsActive, DbType.String);

                using(IDbConnection con=new SqlConnection(_configuration))
                {
                    response = await con.QueryFirstAsync<CommonResponse>("API_CreateStudent", parameters, null, null, CommandType.StoredProcedure);
                }
              
               
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Code = 500;
                response.Success = false;
            }

            return response;

        }

        //Delete Student Record----->
        async Task<CommonResponse> IStudentRepository.DeleteStudent(int? ID)
        {
            var response = new CommonResponse();
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@StudentID", ID, DbType.Int32);
                using(IDbConnection con=new SqlConnection(_configuration))
                {
                    response = await con.QueryFirstOrDefaultAsync<CommonResponse>("API_DeleteStudent", parameters, null, null, CommandType.StoredProcedure);
                }
                
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Code = 500;
            }
            return response;
        }

        #region SelectAllStudents From database
        public async Task<SelectStudents> SelectStudents()
        {
            var response = new SelectStudents();
            
           
            
           
            try
            {
                using (IDbConnection con = new SqlConnection(_configuration))
                {
                    var student = new List<CreateStudent>(); 
                    var responseAllData = await con.QueryAsync<CreateStudentResponse>("API_SelectAllStudent", null, null, null, CommandType.StoredProcedure);
                    bool RunOnce = true;
                    foreach (var item in responseAllData)
                    {

                        if (RunOnce)
                        {
                            response.Message = item.Message;
                            response.Code = item.Code;
                            response.Success = item.Success;
                            RunOnce = false;
                        }

                        student.Add(new CreateStudent{
                          StudentName=  item.StudentName,
                        StudentEmail = item.StudentEmail,
                       StudentDOB = item.StudentDOB,
                       IsActive = item.IsActive,
                      Branch = item.Branch,
                   
                        });
                        
                    }
                   response.Data=student; 

                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Code = 999;
                response.Success =false;
              
            }


            return response;

        }

        #endregion

        #region SelectOneStudentData
        public async Task<CreateStudentResponse> GetStudent(int? ID)
        {
            var response = new CreateStudentResponse();
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@StudentID", ID, DbType.Int32);
                using (IDbConnection con = new SqlConnection(_configuration))
                {
                  response=await  con.QueryFirstAsync<CreateStudentResponse>("API_SelectSingleStudent", parameters, null, null, CommandType.StoredProcedure);

                }

            }
            catch (Exception ex)
            {
                response.Message=ex.Message;
                response.Code = 404;
                response.Success = false;
            }
            return response;
        }
        #endregion

        #region

        public async Task<CommonResponse> UpdateStudent(CreateStudent request)
        {
            var response = new CommonResponse();
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@StudentID", request.StudentID, DbType.Int32);
                parameters.Add("@StudentName", request.StudentName, DbType.String);
                parameters.Add("@StudentEmail", request.StudentEmail, DbType.String);
                parameters.Add("@StudentDOB", request.StudentDOB, DbType.String);
                parameters.Add("@Branch", request.Branch, DbType.String);
                parameters.Add("@MobileNumber", request.MobileNumber, DbType.String);
                parameters.Add("@MobileNumber", request.MobileNumber, DbType.String);
                parameters.Add("@IsActive", request.IsActive, DbType.String);

                using (IDbConnection con = new SqlConnection(_configuration))
                {
                    response = await con.QueryFirstAsync<CommonResponse>("API_UpdateStudent", parameters, null, null, CommandType.StoredProcedure);
                }


            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Code = 500;
                response.Success = false;
            }

            return response;
        }
        #endregion
    }
}
