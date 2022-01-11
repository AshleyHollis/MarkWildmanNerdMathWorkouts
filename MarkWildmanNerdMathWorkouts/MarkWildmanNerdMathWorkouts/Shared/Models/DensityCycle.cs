namespace MarkWildmanNerdMathWorkouts.Shared.Models
{
    public class DensityCycle
    {
        private Weight _weight;
        private int _volumeCycleSets;
        private int _volumeCycleReps;
        private int _targetReps;
        private int _currentSets;
        private int _currentReps;
        private bool _isBilateral;

        public DensityCycle(Weight weight,int volumeCycleSets, int volumeCycleReps, int targetReps, bool isBilateral)
        {
            _weight = weight;
            _volumeCycleSets = volumeCycleSets;
            _volumeCycleReps = volumeCycleReps;
            _currentReps = volumeCycleReps;
            _targetReps = targetReps;
            _isBilateral = isBilateral;
        }

        public WorkoutIncrement Next()
        {
            var nextSets = GetNextSets(++_currentReps);

            while (GetNextSets(_currentReps + 1) == nextSets)
            {
                nextSets = GetNextSets(++_currentReps);
            }

            _currentSets = nextSets;

            if (_currentReps == _targetReps) return new WorkoutIncrement(_weight, _currentSets, _currentReps, true, _isBilateral);

            return new WorkoutIncrement(_weight, _currentSets, _currentReps, false, _isBilateral);
        }

        private int GetNextSets(int reps)
        {
            return (_volumeCycleSets * _volumeCycleReps) / reps;
        }
    }
}