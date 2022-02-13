using CrudWebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudWebApiDemo.Controllers
{
    public class StudentController : ApiController
    {

        WebAPIDemotestEntities testDb = new WebAPIDemotestEntities();

        public IHttpActionResult GetALLStudents() {
            IList<StudentViewModel> student = null;
            using (var x = new WebAPIDemotestEntities()) {
                student = x.Students
                    .Select(c => new StudentViewModel()
                    {
                        StudentId = c.StudentId,
                        FName = c.FirstName,
                        LName = c.LastName

                    }).ToList<StudentViewModel>();
            }
            if (student.Count == 0)
                return NotFound();

            return Ok(student);
        }


        public IHttpActionResult PostNewStudent(Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            { 
   
                Student student1 = new Student();
                student1.FirstName = student.FirstName;
                student1.LastName = student.LastName;

            testDb.Students.Add(student1);
            testDb.SaveChanges();
            }
            return Ok("Done");
        }

        public IHttpActionResult Put(Student student)
        {
            bool status;
            try {
                Student student1 = testDb.Students.Where(s => s.StudentId == student.StudentId).FirstOrDefault();
                if (student1 != null) {
                    student1.FirstName = student.FirstName;
                    student1.LastName = student.LastName;
                    testDb.Entry(student).State = System.Data.Entity.EntityState.Modified;
                    testDb.SaveChanges();
                }
                status = true;
            }
            catch(Exception)
            {
                status = false;
            }
            return Ok();
          
        }

        public IHttpActionResult Delete(int id) {
                if (id <= 0)

                    return BadRequest("Please Enter valid Student ID");

                using (var ctx = new WebAPIDemotestEntities())
                {
                    var student = ctx.Students
                        .Where(c => c.StudentId == id)
                        .FirstOrDefault();

                    ctx.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                    ctx.SaveChanges();

                }
                return Ok();

            }
        }

    } 



