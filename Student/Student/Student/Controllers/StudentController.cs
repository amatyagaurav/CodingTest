using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Student.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Controllers
{
    //[EnableCors("*")]
    [Route("[controller]")]
    [ApiController]
    //[EnableCors("AllowOrigin")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("api/GetAllSubjects")]
        public List<ClassDetail> GetAllSubjects()
        {
            try
            {
                List<ClassDetail> classDetails = ReadJson().SelectMany(x => x.class_details).GroupBy(x => x.subject_code).Select(x => x.FirstOrDefault()).ToList();

                return classDetails;
            }
            catch(Exception ex) {
                throw ex;
            }
            


        }
        public List<StudentVM> ReadJson()
        {
            try
            {
                List<StudentVM> studentList = new List<StudentVM>();
                using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "Json/output.json"))
                {
                    string json = r.ReadToEnd();
                    studentList = JsonConvert.DeserializeObject<List<StudentVM>>(json);
                }
                return studentList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        [Route("api/GetStudentBySubject")]
        public List<StudentVM> GetStudentBySubject(string SubjectCode)
        {
            try
            {
                var studentList = ReadJson().Select(x => new StudentVM
                {
                    student_id = x.student_id,
                    classdetails = x.class_details.FirstOrDefault(x => x.subject_code == SubjectCode)
                }).Where(x => x.classdetails != null).ToList();
                return studentList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
    }
}

