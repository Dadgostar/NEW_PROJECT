﻿using AP_PROJECT.Class;
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

        public static Student GetStudent(int student_id)
        {
            return StudentTable.Select(x => x).Where(x => x.Id == student_id).ToArray()[0];
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

        public static bool SetMark(int course_id, int student_id, Teacher teacher, int mark)
        {
            try {
                termCourseStudentTable.Select(x => x).Where(
                    x => x.Student.Id == student_id && x.TermCourse.Teacher.Id == teacher.Id && x.TermCourse.Id == course_id)
                    .ToArray()[0].Mark = mark;
                saveData(termCourseStudentTable);
            }catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public static Course GetCourse(int cours_id)
        {
            var result=termCourseTable.Select(x => x.Course).Where(x => x.Id == cours_id).ToArray();
            if (result.Length == 0)
                return null;
            return result[0];
        }
        internal static List_of_terms.Data[] GetListOfTerms(Student student)
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
                    Status = term.Item3>12?"passed":"failed"
                });
            }
            return datas.ToArray();
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
            var TermList = termCourseStudentTable.Select(x => x).Where(x => x.Student == student && x.Status == "passed").Select(x => x.TermCourse.Term).OrderBy(x=>x.TermNum).Distinct();
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
            studentFile.Close();

            StreamReader teacherFile = new StreamReader("teacher.txt");
            while ((line = teacherFile.ReadLine()) != null)
            {
                var items = line.Split('\t');
                TeacherTable.Add(new Teacher(){Id =int.Parse(items[0]),FirstName = items[1],LastName = items[3],Password = items[3]});
            }
            teacherFile.Close();

            StreamReader courseFile = new StreamReader("course.txt");
            while ((line = courseFile.ReadLine()) != null)
            {
                var items = line.Split('\t');
                CourseTable.Add(new Course(){Id =int.Parse(items[0]),ECT = int.Parse(items[1]), Name = items[2],type = items[3]});
            }
            courseFile.Close();

            StreamReader termFile = new StreamReader("term.txt");
            while ((line = termFile.ReadLine()) != null)
            {
                var items = line.Split('\t');
                TermTable.Add(new Term() { 
                    TermNum = int.Parse(items[0])
                    ,TermName = items[1]
                    });
            }
            termFile.Close();

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
            prereQuisiteFile.Close();

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
            termCourseFile.Close();

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
            termCourseStudentFile.Close();
        }
        private static void saveData(List<TermCourseStudent> termCourseStudentTable)
        {
            StreamWriter termCourseStudentFile = new StreamWriter("termcoursestudent.txt");
            foreach(var item in termCourseStudentTable)
            {
                termCourseStudentFile.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                    item.Mark,item.ObjectionToMark,item.AnswerToObjection,item.TermCourse.Id,item.Student.Id,item.Status
                    );
            }
            termCourseStudentFile.Close();
        }
    }
   
}

