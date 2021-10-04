using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreViewModel
{
    IScoreModel ScoreModel { get; }
    event System.Action<int> OnChangeText;
    void UpdateState(int value);
    
}
