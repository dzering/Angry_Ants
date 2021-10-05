using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreViewModel
{
    IScoreModel ScoreModel { get; }
    event System.Action<int> OnChange;
    void UpdateModel(int value);
    
}
