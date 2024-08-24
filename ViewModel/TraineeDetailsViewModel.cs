using ITI.Models;

namespace ITI.ViewModel
{
    public class TraineeGradesDetailsViewModel
    {
        public int TraineeId {  get; set; }
        public string TraineeName { get; set; }

        public string CourseName { get; set; }

        public int Degree {  get; set; }

        public string DegreeColor { get; set; }

        public List<TraineeGradesDetailsViewModel> trainneCourses { get; set; }
    }
}
