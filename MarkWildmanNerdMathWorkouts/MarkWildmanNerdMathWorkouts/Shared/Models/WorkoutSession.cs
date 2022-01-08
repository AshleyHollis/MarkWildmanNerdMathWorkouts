using MarkWildmanNerdMathWorkouts.Shared.Enums;

namespace MarkWildmanNerdMathWorkouts.Shared.Models
{
    public class WorkoutSession
    {
        public DateTime Date { get; protected set; }
        public WorkoutType WorkoutType { get; protected set; }
        public WorkoutLevel WorkoutLevel { get; protected set; }
        public WeightLevel WeightLevel { get; protected set; }
        public HeartRateLevel HeartRateLevel { get; protected set; }
        public ThoughtLevel ThoughtLevel { get; protected set; }
        public string Title => GenerateTitle();

        public string Notes { get; set; }

        public List<WorkoutExercise> WorkoutExercises { get; protected set; }

        public WorkoutSession(DateTime date, WorkoutType workoutType, WorkoutLevel workoutLevel, WeightLevel weightLevel, HeartRateLevel heartRateLevel, ThoughtLevel thoughtLevel)
        {
            Date = date;
            WorkoutType = workoutType;
            WorkoutLevel = workoutLevel;
            Notes = string.Empty;
            WorkoutExercises = new List<WorkoutExercise>();
            WeightLevel = weightLevel;
            HeartRateLevel = heartRateLevel;
            ThoughtLevel = thoughtLevel;
        }

        // TODO: Generate title based off
        private string GenerateTitle()
        {
            var workoutTypeShortName = string.Empty;
            var workoutLevelShortName = string.Empty;

            switch (WorkoutType)
            {
                case WorkoutType.KettleBell:
                    workoutTypeShortName = "KB";
                    break;
                case WorkoutType.ClubBell:
                    workoutTypeShortName = "CB";
                    break;
                case WorkoutType.Mace:
                    workoutTypeShortName = "MA";
                    break;
                case WorkoutType.BodyWeight:
                    workoutTypeShortName = "BW";
                    break;                
                default:
                    throw new ArgumentOutOfRangeException(nameof(WorkoutType), WorkoutType, "");
            }

            switch (WorkoutLevel)
            {
                case WorkoutLevel.Recovery:
                    workoutLevelShortName = "R";
                    break;
                case WorkoutLevel.Light:
                    workoutLevelShortName = "L";
                    break;
                case WorkoutLevel.Medium:
                    workoutLevelShortName = "M";
                    break;
                case WorkoutLevel.Heavy:
                    workoutLevelShortName = "H";
                    break;             
                default:
                    throw new ArgumentOutOfRangeException(nameof(WorkoutType), WorkoutType, "");
            }

            return string.Format("{0} - {1}", workoutTypeShortName, workoutLevelShortName);
        }

        public void AddWorkoutExcercise(WorkoutExercise workoutExercise)
        {
            WorkoutExercises.Add(workoutExercise);
        }
    }
}