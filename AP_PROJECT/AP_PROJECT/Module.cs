using AP_PROJECT.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AP_PROJECT.View;
using AP_PROJECT.View.Professor;

namespace AP_PROJECT
{
    public class Module
    {
        public static List<Student> StudentTable = new List<Student>();
        public static List<Teacher> TeacherTable = new List<Teacher>();
        public static List<Course>  CourseTable = new List<Course>();
        public static List<TermCourse> termCourseTable = new List<TermCourse>();
        public static List<TermCourseStudent> termCourseStudentTable = new List<TermCourseStudent>();
        public static List<PreQuisite> preQuisiteTable = new List<PreQuisite>();
        public static List<Term> TermTable = new List<Term>();

        internal static Student GetStudent(int student_id)
        {
            throw new NotImplementedException();
        }

        public static Professor_courses.Data[] GetProfessorCoursesData(Teacher teacher)
        {
            Professor_courses.Data[] results = new Professor_courses.Data[5];
            results[0] = new Professor_courses.Data() { course_id = "1", course_name = "name1", students = 5, type = "takhasosi", units = 3 };
            results[1] = new Professor_courses.Data() { course_id = "2", course_name = "name2", students = 4, type = "takhasosi", units = 2 };
            results[2] = new Professor_courses.Data() { course_id = "3", course_name = "name3", students = 23, type = "takhasosi", units = 4 };
            results[3] = new Professor_courses.Data() { course_id = "4", course_name = "name4", students = 53, type = "omommi", units = 3 };
            results[4] = new Professor_courses.Data() { course_id = "5", course_name = "name5", students = 10, type = "takhasosi", units = 1 };
            return results;
        }

<<<<<<< HEAD
        internal static bool SetMark(int course_id, int student_id, Teacher teacher, int mark)
        {
            throw new NotImplementedException();
        }

        internal static Course GetCourse(int cours_id)
=======
        internal static List_of_terms.Data[] GetListOfTerms(Student student)
>>>>>>> a034f168ba27477af3c99e5858f0d19e855055c5
        {
            throw new NotImplementedException();
        }

        internal static Course_students.Data[] GetStudentsMark(int cours_id, Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public static bool EditPassword(Person user , string newPassword, string oldPassword, string confirm, Person person)
        {
            if (!AccessTo(person, user, "EditPassword"))
                return false;        
            if (newPassword != confirm || user.Password != oldPassword)
                return false;
            user.Password = newPassword;
            return true;
        }


        public static Person Login(string userName, string passWord)
        {
            int Id = int.Parse(userName);
            var temp1 = StudentTable.Select(x => x).Where(x => x.Id == Id && x.Password == passWord);// checking if the username is a student
            if(temp1.Count()>0)
            {
                return temp1.ToList()[0];
            }
            
            var temp2 = TeacherTable.Select(x => x).Where(x => x.Id == Id && x.Password == passWord);
            if (temp2.Count() > 0)
            {
                return temp2.ToList()[0];
            }
            return null;
        }

        public static List<Tuple<Term,double,double>> GetTermAvgGrade(Student student)
        {
            var TermList = termCourseStudentTable.Select(x => x).Where(x => x.Student == student && x.Status=="passed").Select(x => x.TermCourse.Term).OrderBy(x=>x.TermNum).Distinct();
            List<Tuple<Term, double,double>> result = new List<Tuple<Term, double,double>>();
            foreach (var term in TermList)
            {
                var CoursesInTermList = termCourseStudentTable.Select(x => x).Where(x => x.Student == student && x.TermCourse.Term.TermNum == term.TermNum);
                var Sum = CoursesInTermList.Select(x=>x.Mark*x.TermCourse.Course.ECT).Sum();
                var Count = CoursesInTermList.Select(x => x.TermCourse.Course.ECT).Sum();
                result.Add(new Tuple<Term, double,double>(term, Count, Sum/Count));
            }
            return result;
        }

        public static double GetPayment(Student student)
        {
            return 1001;
        }

        public static double GetAvgGrade(Student student)
        {
            var temp = GetTermAvgGrade(student);
            var sum = temp.Select(x => x.Item2 * x.Item3).Sum();
            var Count = temp.Select(x => x.Item2).Sum();
            return sum / Count;
        }
        private static bool AccessTo(Person person, Person user, string AccessTo)
        {
            return true;
        }

        public Module()
        {

        }

        public static void loadData()
        {
            string line = "";

            StreamReader studentFile = new StreamReader("student.txt");
            while((line = studentFile.ReadLine()) != null)
            {
                var items = line.Split('\t');
                StudentTable.Add(new Student(){Id=int.Parse(items[0]), FirstName = items[1], LastName = items[2], Password = items[3]});
            }
            
            StreamReader teacherFile = new StreamReader("teacher.txt");
            while ((line = teacherFile.ReadLine()) != null)
            {
                var items = line.Split('\t');
                TeacherTable.Add(new Teacher(){Id =int.Parse(items[0]),FirstName = items[1],LastName = items[3],Password = items[3]});
            }
            
            StreamReader courseFile = new StreamReader("course.txt");
            while ((line = courseFile.ReadLine()) != null)
            {
                var items = line.Split('\t');
                CourseTable.Add(new Course(){Id =int.Parse(items[0]),ECT = int.Parse(items[1]), Name = items[2],type = items[3]});
            }

            StreamReader termFile = new StreamReader("term.txt");
            while ((line = termFile.ReadLine()) != null)
            {
                var items = line.Split('\t');
                TermTable.Add(new Term() { 
                    TermNum = int.Parse(items[0])
                    ,TermName = items[1]
                    });
            }

            StreamReader prereQuisiteFile = new StreamReader("prerequisite.txt");
            while ((line = prereQuisiteFile.ReadLine()) != null)
            {
                var items = line.Split('\t');
                preQuisiteTable.Add(new PreQuisite()
                {
                    Course1 = (CourseTable.Select(x => x).Where(x => x.Id == int.Parse(items[0])).ToArray())[0]
                    ,Course2 = (CourseTable.Select(x => x).Where(x => x.Id == int.Parse(items[1])).ToArray())[0]
                    ,Status = items[2]
                });
            }

            StreamReader termCourseFile = new StreamReader("termcourse.txt");
            while ((line = termCourseFile.ReadLine()) != null)
            {
                var items = line.Split('\t');
                termCourseTable.Add(new TermCourse()
                {
                    Id = int.Parse(items[0]),
                    Course = (CourseTable.Select(x => x).Where(x => x.Id == int.Parse(items[1])).ToArray())[0],
                    Term = (TermTable.Select(x => x).Where(x => x.TermNum == int.Parse(items[2])).ToArray())[0],
                    Teacher = (TeacherTable.Select(x => x).Where(x => x.Id == int.Parse(items[3])).ToArray())[0],
                    Time = int.Parse(items[4]),
                    Place = items[5],
                    Capacity = int.Parse(items[6])
                });
                ;
            }

            StreamReader termCourseStudentFile = new StreamReader("termcoursestudent.txt");
            while ((line = termCourseStudentFile.ReadLine()) != null)
            {
                var items = line.Split('\t');
                termCourseStudentTable.Add(new TermCourseStudent()
                {
                    Mark = int.Parse(items[0])
                    ,
                    ObjectionToMark = items[1]
                    ,
                    AnswerToObjection = items[2]
                    ,
                    TermCourse = (termCourseTable.Select(x => x).Where(x => x.Id == int.Parse(items[3])).ToArray())[0]
                    ,
                    Student = (StudentTable.Select(x => x).Where(x => x.Id == int.Parse(items[4])).ToArray())[0]
                    ,
                    Status = items[5]
                }) ;
            }
        }
    }
   
}

