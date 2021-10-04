using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModel : IScoreModel
{
    public int CurrentCount { get; set; }
    public ScoreModel(int value)
    {
        CurrentCount = value;
    }
}
