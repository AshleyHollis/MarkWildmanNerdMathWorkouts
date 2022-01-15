using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkWildmanNerdMathWorkouts.Application.Features.Workouts
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
            var programOutput = string.Join(Environment.NewLine, programsSortedByDay);

            var excercisesSortedByDay = FlattenWorkoutExcercisesByDay();
            var excercisesOutput = string.Join(Environment.NewLine, excercisesSortedByDay);

            return $"{programOutput}{Environment.NewLine}{Environment.NewLine}{excercisesOutput}";
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

        private List<WorkoutExerciseNew> FlattenWorkoutExcercisesByDay()
        {
            var excercises = Programs.SelectMany(a => a.Excercises).ToList();
            var flattenedExcercises = new List<WorkoutExerciseNew>();
            foreach (var excercise in excercises)
            {
                foreach (var day in excercise.WorkoutDays)
                {
                    flattenedExcercises.Add(new WorkoutExerciseNew(excercise, day));
                }
            }

            return flattenedExcercises.OrderBy(a => a.WorkoutDays.SingleOrDefault()?.DayOfWeek).ThenBy(a => a.WorkoutDays.SingleOrDefault()?.Order).ToList();
        }
    }
}