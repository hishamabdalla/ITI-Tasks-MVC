namespace ITI.ViewModel
{
    public class TraineeViewModel
    {
        public int TraineeId { get; set; }
        public string TraineeName { get; set; }

        public List<TraineeCoursesViewModel> trainneCourses { get; set; }

    }
    public class TraineeCoursesViewModel
    {
        public string CourseName { get; set; }

        public int Degree { get; set; }

        public string DegreeColor { get; set; }

    }



}
