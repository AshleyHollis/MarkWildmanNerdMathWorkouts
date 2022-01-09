namespace MarkWildmanNerdMathWorkouts.Shared.Models
{
    public class WorkoutProgramSchedule
    {
        public List<WorkoutProgram> Programs;
        public WorkoutProgramSchedule()
        {
            Programs = new List<WorkoutProgram>();
        }

        public void AddProgram(WorkoutProgram workoutProgram)
        {
            Programs.Add(workoutProgram);
        }

        public override string ToString()
        {
            var programsSortedByDay = FlattenWorkoutProgramsByDay();

            return string.Join(Environment.NewLine, programsSortedByDay);
        }

        private List<WorkoutProgram> FlattenWorkoutProgramsByDay()
        {
            var flattenedPrograms = new List<WorkoutProgram>();
            foreach (var program in Programs)
            {
                foreach (var day in program.WorkoutDays)
                {
                    flattenedPrograms.Add(new WorkoutProgram(program, day));
                }
            }

            return flattenedPrograms.OrderBy(a => a.WorkoutDays.SingleOrDefault()).ToList();
        }
    }
}