using System;
namespace AP_PROJECT.Class
{
    public class TermCourseStudent
    {
        public int Mark { set; get; }
        public String ObjectionToMark  { get; set; }
        public String AnswerToObjection { get; set; }
        public TermCourse TermCourse { set; get; }
        public Student Student { set; get; }
        public string Status { set; get; }
        public TermCourseStudent()
        {
        }
    }
}
