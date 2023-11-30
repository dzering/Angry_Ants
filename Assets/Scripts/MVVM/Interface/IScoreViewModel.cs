namespace MVVM.Interface
{
    public interface IScoreViewModel
    {
        IScoreModel ScoreModel { get; }
        event System.Action<int> OnChange;
        void UpdateModel(int value);
    
    }
}
