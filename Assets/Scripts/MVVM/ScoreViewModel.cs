using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreViewModel : IScoreViewModel
{
    public IScoreModel ScoreModel { get; set; }

    public event Action<int> OnChangeText;

    public ScoreViewModel(IScoreModel score)
    {
        ScoreModel = score;
    }
    public void UpdateState(int count)
    {
        ScoreModel.CurrentCount = count;
        OnChangeText?.Invoke(ScoreModel.CurrentCount);
    }
}
