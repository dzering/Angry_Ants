using System;
using MVVM.Interface;

namespace MVVM.ViewModel
{
    public class ScoreViewModel : IScoreViewModel
    {
        public IScoreModel ScoreModel { get; set; }

        public event Action<int> OnChange;

        public ScoreViewModel(IScoreModel scoreModel)
        {
            ScoreModel = scoreModel; 
        }
        public void UpdateModel(int count)
        {
            ScoreModel.CurrentCount = count;
            OnChange?.Invoke(ScoreModel.CurrentCount);
        }
    }
}
