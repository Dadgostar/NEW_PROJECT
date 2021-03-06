﻿using AP_PROJECT.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AP_PROJECT.View;
using AP_PROJECT.View.Professor;
using AP_PROJECT.View.Student;
using PlainCrypto.Abstract;
using PlainCrypto;
namespace AP_PROJECT
{
 
    public class Module
    {
        public static List<Student> StudentTable = new List<Student>();
        public static List<Teacher> TeacherTable = new List<Teacher>();
        public static List<Course> CourseTable = new List<Course>();
        public static List<TermCourse> termCourseTable = new List<TermCourse>();
        public static List<TermCourseStudent> termCourseStudentTable = new List<TermCourseStudent>();
        public static List<PreQuisite> preQuisiteTable = new List<PreQuisite>();
        public static List<Clerk> ClerkTable = new List<Clerk>();
        public static List<Term> TermTable = new List<Term>(); 
        static byte[] key = { 158, 23, 64, 96, 57, 225, 36, 85 };
        static byte[] Iv = { 63, 208, 159, 46, 37, 77, 1, 59 };
        // crypto.SetIV(Iv);
        internal static Clerk_student_list.Data[] GetStudentsDataForClerk(Clerk clerk)
        {
            throw new NotImplementedException();
        }

       

        public static bool addStudent(string firstName, string lastName, string password)
        {
            try
            {
                int id = StudentTable.Select(x => x.Id).Max() + 1;
                StudentTable.Add(new Student()
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password
                   
                });
                saveData(StudentTable);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        internal static Clerk_student_list.Data[] GetAddedStudentByEducAssist(string newStudentId, string newStudentName)
        {
            throw new NotImplementedException();
        }

        internal static Registeration_offered__courses_educAssist.Data[] GetOfferedCoursesData()
        {

            throw new NotImplementedException();
        }

        public static Teacher getTeacher(int id)
        {
            return TeacherTable.Select(x => x).Where(x => x.Id == id).ToArray()[0];
        }

        public static Student_offeredCourses.Data[] GetStudentOfferedCoursesData(Student student, int term)
        {
            return termCourseStudentTable.Select(x => x).Where(x => x.Student.Id == student.Id && x.TermCourse.Term.TermNum == term)
            .Select(x => new Student_offeredCourses.Data()
            {
                ID = x.TermCourse.Id,
                ECT = x.TermCourse.Course.ECT,
                Name = x.TermCourse.Course.Name,
                Professor = x.TermCourse.Teacher.LastName,
                Status = x.Status,
                Time = x.TermCourse.Time,
                Mark = x.Mark
            }).ToArray();
        }

        public static int getLastTerm(Student student)
        {
            return termCourseStudentTable.Select(x => x).Where(x => x.Student.Id == student.Id).Select(x => x.TermCourse.Term.TermNum).Max();
        }

        internal static Professor_exception_list.Data[] GetExceptionListData(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public static Student GetStudent(int student_id)
        {
            return StudentTable.Select(x => x).Where(x => x.Id == student_id).ToArray()[0];
        }

        public static WeekSchedule.Data[] GetStudentSchedule(Student student)
        {
            WeekSchedule.Data[] datas = new WeekSchedule.Data[4];
            for (int i = 0; i < 4; i++)
                datas[i] = new WeekSchedule.Data() { Day = "day_" + i };
            int lastTermNum = termCourseStudentTable.Select(x => x).Where(x => x.Student.Id == student.Id).Select(x => x.TermCourse.Term.TermNum).Max();
            var result = termCourseStudentTable.Select(x => x).Where(x => x.Student.Id == student.Id && x.TermCourse.Term.TermNum == lastTermNum).Select(x => x.TermCourse);
            foreach (var course in result)
            {
                switch (course.Time)
                {
                    case 0:
                        datas[0].CourseNameTime1 = datas[2].CourseNameTime1 = course.Course.Name;
                        break;
                    case 1:
                        datas[0].CourseNameTime2 = datas[2].CourseNameTime2 = course.Course.Name;
                        break;
                    case 2:
                        datas[0].CourseNameTime3 = datas[2].CourseNameTime3 = course.Course.Name;
                        break;
                    case 3:
                        datas[0].CourseNameTime4 = datas[2].CourseNameTime4 = course.Course.Name;
                        break;
                    case 4:
                        datas[1].CourseNameTime1 = datas[3].CourseNameTime1 = course.Course.Name;
                        break;
                    case 5:
                        datas[1].CourseNameTime2 = datas[3].CourseNameTime2 = course.Course.Name;
                        break;
                    case 6:
                        datas[1].CourseNameTime3 = datas[3].CourseNameTime3 = course.Course.Name;
                        break;
                    case 7:
                        datas[1].CourseNameTime4 = datas[3].CourseNameTime4 = course.Course.Name;
                        break;
                }
            }
            return datas;
        }

        public static double GetStudentMark(int student_id, int teacher_id, int cours_id)
        {
            return termCourseStudentTable.Select(x => x)
                .Where(x => x.Student.Id == student_id && x.TermCourse.Teacher.Id == teacher_id && x.TermCourse.Course.Id == cours_id)
                .Select(x => x.Mark).ToArray()[0];
        }

        public static PreQuisite GetRequisite(int courseId)
        {
            throw new NotImplementedException();
        }

        internal static Professor_listof_objections.Data[] GetObjectionListData(Teacher teacher)
        {
            List<Professor_listof_objections.Data> datas = new List<Professor_listof_objections.Data>();
            var objectionList = termCourseStudentTable.Select(x => x).Where(x => x.ObjectionToMark != "null" && x.AnswerToObjection == "null" && x.TermCourse.Teacher.Id == teacher.Id).ToArray();
            foreach (var objection in objectionList)
            {
                datas.Add(new Professor_listof_objections.Data()
                {
                    course_id = "" + objection.TermCourse.Course.Id
                 ,
                    course_name = "" + objection.TermCourse.Course.Name
                 ,
                    student_id = "" + objection.Student.Id
                 ,
                    student_name = "" + objection.Student.FirstName + " " + objection.Student.LastName
                });
            }
            return datas.ToArray();
        }

        internal static Registeration_offered__courses_educAssist.Data[] GetAddedCourse_byEduAssist(string courseId, string profId, string term_of_course, string place,string volume,string Time)
        {
            //List<TermCourse> datas = new List<TermCourse>();
            //var termcourses
            List<Registeration_offered__courses_educAssist.Data> datas = new List<Registeration_offered__courses_educAssist.Data>();
            if (AddToCourseTermTable(courseId, profId, term_of_course, place, volume, Time))
                {
                    
                    var termcourse = termCourseTable.Select(x => x).ToList();
                    foreach (var termcours in termcourse)
                    {
                        datas.Add(new Registeration_offered__courses_educAssist.Data()
                        {
                            course_id = termcours.Course.Id + "",
                            course_name = GetCourse(termcours.Course.Id).Name,

                            teacher = termcours.Teacher.Id + "",
                            units = termcours.Course.ECT + "",
                            volume = termcours.Capacity + "",
                            time = termcours.Time + ""
                        });
                    }
                }
                else
                {
                    var termcourse = termCourseTable.Select(x => x).ToList();
                    foreach (var termcours in termcourse)
                    {
                        datas.Add(new Registeration_offered__courses_educAssist.Data()
                        {
                            course_id = termcours.Course.Id + "",
                            course_name = GetCourse(termcours.Course.Id).Name,

                            teacher = termcours.Teacher.Id + "",
                            units = termcours.Course.ECT + "",
                            volume = termcours.Capacity + "",
                            time = termcours.Time + ""
                        });
                    }
                }
            return datas.ToArray();
        }
        //public static Course GetCourse(int id)
       // {
          //return CourseTable.Select(x => x).Where(x => x.Id == id).ToArray()[0];
        //}
        public static bool AddToCourseTermTable(string courseId, string profId, string term_of_course, string place, string volume, string Time)
        {
            try
            {
                int id = termCourseTable.Select(x => x.Id).Max() + 1;
                var item = new TermCourse();
                item.Id = id;
                item.Course.Id = CourseTable.Select(x => x).Where(x => x.Id == int.Parse(courseId)).Select(x => x.Id).ToArray()[0];
                item.Term.TermNum = int.Parse(term_of_course);
                item.Teacher.Id = int.Parse(profId);
                item.Time = int.Parse(Time);
                item.Place = place;
                item.Capacity = int.Parse(volume);
                termCourseTable.Add(item);
                saveData(termCourseTable);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
}
            public static Professor_courses.Data[] GetProfessorCoursesData(Teacher teacher)
        {
            List<Professor_courses.Data> datas = new List<Professor_courses.Data>();
            var courses = termCourseTable.Select(x => x).Where(x => x.Teacher.Id == teacher.Id).ToList();
            foreach (var course in courses)
            {
                datas.Add(new Professor_courses.Data()
                {
                    course_id = "" + course.Course.Id
                 ,
                    course_name = course.Course.Name
                 ,
                    type = course.Course.type
                 ,
                    time = "" + course.Time
                 ,
                    units = course.Course.ECT
                 ,
                    students = termCourseStudentTable.Select(x => x).Where(x => x.TermCourse.Id == course.Id).Count()
                });
            }
            return datas.ToArray();
        }

        public static bool SetObjection(int courseId, int studentId, Teacher teacher)
        {
            return true;
        }

        public static Course GetCourse(int course_id)
        {
            var result = termCourseTable.Select(x => x.Course).Where(x => x.Id == course_id).ToArray();
            if (result.Length == 0)
                return null;
            return result[0];
        }

        public static bool SetMark(int course_id, int student_id, Teacher teacher, double mark)
        {
            try
            {
                var item = termCourseStudentTable.Select(x => x).Where(x => x.Student.Id == student_id && x.TermCourse.Teacher.Id == teacher.Id && x.TermCourse.Course.Id == course_id)
                .ToArray()[0];
                item.Mark = mark;
                item.Status = mark > 10 ? "passed" : "failed";
                saveData(termCourseStudentTable);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public static List_of_terms.Data[] GetListOfTerms(Student student)
        {
            List<List_of_terms.Data> datas = new List<List_of_terms.Data>();
            var termAvg = GetTermAvgGrade(student);
            foreach (var term in termAvg)
            {
                datas.Add(new List_of_terms.Data()
                {
                    Term = term.Item1.TermNum
                    ,
                    Total_Units = (int)term.Item2
                    ,
                    Status = term.Item3 > 12 ? "passed" : "failed"
                });
            }
            return datas.ToArray();
        }


        public static Course_students.Data[] GetStudentsMark(int cours_id, Teacher teacher)
        {
            return termCourseStudentTable.Select(x => x)
                .Where(x => x.TermCourse.Course.Id == cours_id && x.TermCourse.Teacher.Id == teacher.Id)
                .Select(x => new Course_students.Data()
                {
                    mark = "" + x.Mark,
                    student_id = "" + x.Student.Id,
                    student_name = x.Student.FirstName + " " + x.Student.LastName
                }).ToArray();
        }

        public static bool EditPassword(Person user, string newPassword, string oldPassword, string confirm, Person person)
        {
            if (!AccessTo(person, user, "EditPassword"))
                return false;
            if (newPassword != confirm || user.Password != oldPassword)
                return false;
            try
            {
                if (user is Teacher)
                {
                    TeacherTable.Select(x => x).Where(x => x.Id == user.Id && x.Password == oldPassword).ToArray()[0].Password = newPassword;
                    saveData(TeacherTable);
                }
                if (user is Student)
                {
                    StudentTable.Select(x => x).Where(x => x.Id == user.Id && x.Password == oldPassword).ToArray()[0].Password = newPassword;
                    saveData(StudentTable);
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public static Person Login(string userName, string passWord)
        {
            int Id = -1;
            int.TryParse(userName, out Id);
            var temp1 = StudentTable.Select(x => x).Where(x => x.Id == Id && x.Password == passWord);// checking if the username is a student
            if (temp1.Count() > 0)
            {
                return temp1.ToList()[0];
            }
            var temp2 = TeacherTable.Select(x => x).Where(x => x.Id == Id && x.Password == passWord);
            if (temp2.Count() > 0)
            {
                return temp2.ToList()[0];
            }
           var temp3 = ClerkTable.Select(x => x).Where(x => x.Id == Id && x.Password == passWord);
            if (temp3.Count() > 0)
            {
                return temp3.ToList()[0];
            }
            return null;
        }

        public static List<Tuple<Term, double, double>> GetTermAvgGrade(Student student)
        {
            var TermList = termCourseStudentTable.Select(x => x).Where(x => x.Student == student && x.Status == "passed").Select(x => x.TermCourse.Term).OrderBy(x => x.TermNum).Distinct();
            List<Tuple<Term, double, double>> result = new List<Tuple<Term, double, double>>();
            foreach (var term in TermList)
            {
                var CoursesInTermList = termCourseStudentTable.Select(x => x).Where(x => x.Student == student && x.TermCourse.Term.TermNum == term.TermNum);
                var Sum = CoursesInTermList.Select(x => x.Mark * x.TermCourse.Course.ECT).Sum();
                var Count = CoursesInTermList.Select(x => x.TermCourse.Course.ECT).Sum();
                result.Add(new Tuple<Term, double, double>(term, Count, Sum / Count));
            }
            return result;
        }

        public static string GetPayment(Student student)
        {
            var CoursesInTermList = termCourseStudentTable.Select(x => x).Where(x => x.Student == student); 
            var Count = CoursesInTermList.Select(x => x.TermCourse.Course.ECT).Sum();
            return ""+Count*50+"Toman";
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
            CryptoSymmetric crypto = new CryptoDES(new byte[] { 158, 23, 64, 96, 57, 225, 36, 85 });

            while ((line = studentFile.ReadLine()) != null)
            {
                line = crypto.Decrypt(line);
                var items = line.Split('\t');
                StudentTable.Add(new Student() { Id = int.Parse(items[0]), FirstName = items[1], LastName = items[2], Password = items[3] ,EntranceYear = items[4].ToString()});
            }
            studentFile.Close();
            StreamReader teacherFile = new StreamReader("teacher.txt");
            crypto = new CryptoDES(new byte[] { 158, 23, 64, 96, 57, 225, 36, 85 }); 
            while ((line = teacherFile.ReadLine()) != null)
            {
                line = crypto.Decrypt(line);
                var items = line.Split('\t');
                TeacherTable.Add(new Teacher() { Id = int.Parse(items[0]), FirstName = items[1], LastName = items[3], Password = items[3] });
            }
            teacherFile.Close();

            StreamReader courseFile = new StreamReader("course.txt");
            crypto = new CryptoDES(new byte[] { 158, 23, 64, 96, 57, 225, 36, 85 }); 
            while ((line = courseFile.ReadLine()) != null)
            {
                line = crypto.Decrypt(line);
                var items = line.Split('\t');
                CourseTable.Add(new Course() { Id = int.Parse(items[0]), ECT = int.Parse(items[1]), Name = items[2], type = items[3] });
            }
            courseFile.Close();

            StreamReader termFile = new StreamReader("term.txt");
            crypto = new CryptoDES(new byte[] { 158, 23, 64, 96, 57, 225, 36, 85 });
            while ((line = termFile.ReadLine()) != null)
            {
                line = crypto.Decrypt(line);
                var items = line.Split('\t');
                TermTable.Add(new Term()
                {
                    TermNum = int.Parse(items[0])
                    ,
                    TermName = items[1]
                });
            }
            termFile.Close();

            StreamReader prereQuisiteFile = new StreamReader("prerequisite.txt");
            crypto = new CryptoDES(new byte[] { 158, 23, 64, 96, 57, 225, 36, 85 });
            while ((line = prereQuisiteFile.ReadLine()) != null)
            {
                line = crypto.Decrypt(line);
                var items = line.Split('\t');
                preQuisiteTable.Add(new PreQuisite()
                {
                    Course1 = (CourseTable.Select(x => x).Where(x => x.Id == int.Parse(items[0])).ToArray())[0]
                    ,
                    Course2 = (CourseTable.Select(x => x).Where(x => x.Id == int.Parse(items[1])).ToArray())[0]
                    ,
                    Status = items[2]
                });
            }
            prereQuisiteFile.Close();

            StreamReader termCourseFile = new StreamReader("termcourse.txt");
            crypto = new CryptoDES(new byte[] { 158, 23, 64, 96, 57, 225, 36, 85 });
            while ((line = termCourseFile.ReadLine()) != null)
            {
                line = crypto.Decrypt(line);
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
            termCourseFile.Close();

            StreamReader termCourseStudentFile = new StreamReader("termcoursestudent.txt");
            crypto = new CryptoDES(new byte[] { 158, 23, 64, 96, 57, 225, 36, 85 });
            while ((line = termCourseStudentFile.ReadLine()) != null)
            {
                line = crypto.Decrypt(line);
                var items = line.Split('\t');
                termCourseStudentTable.Add(new TermCourseStudent()
                {
                    Mark = double.Parse(items[0])
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
                });
            }

            termCourseStudentFile.Close();
            StreamReader clerkFile = new StreamReader("clerk.txt");
            crypto = new CryptoDES(new byte[] { 158, 23, 64, 96, 57, 225, 36, 85 });
            while ((line = clerkFile.ReadLine()) != null)
            {
                line = crypto.Decrypt(line);
                var items = line.Split('\t');
                ClerkTable.Add(new Clerk()
                {
                    Id = int.Parse(items[0])
                    ,
                    FirstName = items[1]
                    ,
                    LastName = items[2]
                    ,
                    Password = items[3]
                });
            }
            clerkFile.Close();

        }
        public static void saveData(List<Student> studentTable)
        {
            StreamWriter file = new StreamWriter("student.txt");
            CryptoSymmetric crypto = new CryptoDES(new byte[] { 158, 23, 64, 96, 57, 225, 36, 85 });
            foreach (var item in studentTable)
            {
                var tempString = item.Id.ToString() + "\t" + item.FirstName.ToString() + "\t" + item.LastName.ToString() + "\t" + item.Password.ToString() + "\t" + item.EntranceYear;
                file.WriteLine(crypto.Encrypt(tempString));
            }
            file.Close();
        }
        
        public static void saveData(List<Teacher> teacherTable)
        {
            StreamWriter file = new StreamWriter("teacher.txt");
            CryptoSymmetric crypto = new CryptoDES(new byte[] { 158, 23, 64, 96, 57, 225, 36, 85 });
            foreach (var item in teacherTable)
            {
                var tempString = item.Id.ToString() + "\t" + item.FirstName.ToString() + "\t" + item.LastName.ToString() + "\t" + item.Password.ToString();
                file.WriteLine(crypto.Encrypt(tempString));
            }
            file.Close();
        }

        public static void saveData(List<TermCourse> termCourseTable)
            {
                StreamWriter file = new StreamWriter("termcourse.txt");
                CryptoSymmetric crypto = new CryptoDES(new byte[] { 158, 23, 64, 96, 57, 225, 36, 85 });
                foreach (var item in termCourseTable)
                {
                    var tempString = item.Id.ToString()+"\t"+item.Course.Id.ToString()+"\t"+item.Term.TermNum.ToString()+ "\t"+item.Teacher.Id.ToString()+"\t"+item.Time+"\t"+ item.Place+"\t"+ item.Capacity;
                    file.WriteLine(crypto.Encrypt(tempString));
                }
                file.Close();
            }

            public static void saveData(List<TermCourseStudent> termCourseStudentTable)
            {
                StreamWriter termCourseStudentFile = new StreamWriter("termcoursestudent.txt");
                CryptoSymmetric crypto = new CryptoDES(new byte[]{ 158, 23, 64, 96, 57, 225, 36, 85 });
                foreach (var item in termCourseStudentTable)
                {
                    var tempString = item.Mark.ToString()+"\t"+item.AnswerToObjection.ToString()+"\t"+item.ObjectionToMark.ToString() + "\t" + item.TermCourse.Id.ToString() + "\t" + item.Student.Id.ToString() + "\t" + item.Status.ToString();
                    termCourseStudentFile.WriteLine(crypto.Encrypt(tempString));
                }
                termCourseStudentFile.Close();
            }
        public static void saveData(List<Course> CourseTable)
        {
            StreamWriter CourseFile = new StreamWriter("course.txt");
            CryptoSymmetric crypto = new CryptoDES(new byte[] { 158, 23, 64, 96, 57, 225, 36, 85 });
            foreach (var item in CourseTable)
            {
                var tempString = String.Format("{0}\t{1}\t{2}\t{3}", item.Id, item.ECT, item.Name, item.type);
                CourseFile.WriteLine(crypto.Encrypt(tempString));
            }
            CourseFile.Close();
        }
            public static void saveData(List<Clerk> ClerkTable)
            {
                StreamWriter ClerkFile = new StreamWriter("clerk.txt");
                CryptoSymmetric crypto = new CryptoDES(new byte[] { 158, 23, 64, 96, 57, 225, 36, 85 });
                foreach (var item in ClerkTable)
                {
                    var tempString = item.Id.ToString() + "\t" + item.FirstName.ToString() + "\t" + item.LastName.ToString() + "\t" + item.Password.ToString();
                    ClerkFile.WriteLine(crypto.Encrypt(tempString));
                }
                ClerkFile.Close();
            }
        public static void saveData(List<PreQuisite> Table)
        {
            StreamWriter PreqFile = new StreamWriter("prerequisite.txt");
            CryptoSymmetric crypto = new CryptoDES(new byte[] { 158, 23, 64, 96, 57, 225, 36, 85 });
            foreach (var item in Table)
            {
                var tempString = item.Course1.Id.ToString() + "\t" + item.Course2.Id.ToString() + "\t" +item.Status.ToString();
                PreqFile.WriteLine(crypto.Encrypt(tempString));
            }
            PreqFile.Close();
        }
        public static void saveData(List<Term> termTable)
        {
            StreamWriter termFile = new StreamWriter("term.txt");
            CryptoSymmetric crypto = new CryptoDES(new byte[] { 158, 23, 64, 96, 57, 225, 36, 85 });
            foreach (var item in termTable)
            {
                var tempString = item.TermNum.ToString() + "\t" + item.TermName.ToString() ;
                termFile.WriteLine(crypto.Encrypt(tempString));
            }
            termFile.Close();
        }
        public static void saveData()
        {
            saveData(StudentTable);
            saveData(TeacherTable);
            saveData(CourseTable);
            saveData(termCourseTable);
            saveData(termCourseStudentTable);
            saveData(preQuisiteTable);
            saveData(ClerkTable);
            saveData(TermTable);
        }


    }

}

