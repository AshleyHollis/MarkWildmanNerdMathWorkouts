using MarkWildmanNerdMathWorkouts.Shared.Helpers;

namespace MarkWildmanNerdMathWorkouts.Shared.Models
{
    public class WorkoutProgram
    {
        public readonly string Code;
        public readonly string Name;
        public List<WorkoutExerciseNew> Excercises;
        public readonly List<DayOfWeek> WorkoutDays;

        public WorkoutProgram(string code, string name, List<DayOfWeek> workoutDays)
        {
            Excercises = new List<WorkoutExerciseNew>();

            Code = code;
            Name = name;
            WorkoutDays = workoutDays;
        }

        public WorkoutProgram(WorkoutProgram program, DayOfWeek workoutDay)
        {
            Excercises = new List<WorkoutExerciseNew>();

            Code = program.Code;
            Name = program.Name;
            WorkoutDays = new List<DayOfWeek> { workoutDay };
        }

        public void AddExcercise(WorkoutExerciseNew excercise)
        {
            Excercises.Add(excercise);
        }

        public override string ToString()
        {
            var output = string.Empty;

            var flattenedWorkouts = FlattenWorkoutProgramsByDay();
            var programOutput = string.Join(Environment.NewLine, flattenedWorkouts.Select(a => string.Format("{0}|{1}|{2}|", a.WorkoutDays.Single().ToShortString(), a.Code, a.Name)));

            return programOutput;
        }

        private List<WorkoutProgram> FlattenWorkoutProgramsByDay()
        {
            var flattenedPrograms = new List<WorkoutProgram>();
            foreach (var day in WorkoutDays)
            {
                flattenedPrograms.Add(new WorkoutProgram(this, day));
            }

            return flattenedPrograms;
        }
    }
}