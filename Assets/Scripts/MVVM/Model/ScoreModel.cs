using MVVM.Interface;

namespace MVVM.Model
{
    public class ScoreModel : IScoreModel
    {
        public int CurrentCount { get; set; }
        public ScoreModel(int value)
        {
            CurrentCount = value;
        }
    }
}
