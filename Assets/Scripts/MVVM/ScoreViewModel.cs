using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreViewModel : IScoreViewModel
{
    public IScoreModel ScoreModel { get; set; }

    public event Action<int> OnChange;

    public ScoreViewModel(IScoreModel scoreModel)
    {
        ScoreModel = scoreModel; 
    }
    public void UpdateData(int count)
    {
        ScoreModel.CurrentCount = count;
        OnChange?.Invoke(ScoreModel.CurrentCount);
    }
}
