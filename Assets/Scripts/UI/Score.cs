using UnityEngine;
using UnityEngine.UI;

internal sealed class Score : IObserver
{
    Text scoreText;
    int Number { get; set; }

    public Score(Text text)
    {
        scoreText = text;
    }

    public void ChangeState() { 
        Count();
    }

    public void Count()
    {  
        scoreText.text = scoreText.text + $"{ Number}"; 
    }
    
}
