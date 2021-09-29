using UnityEngine;
using UnityEngine.UI;

internal sealed class Score
{
    Text scoreText;
    string startText;

    public Score(Text text)
    {
        scoreText = text;
        startText = text.text;
    }

    public void UpdateCountText(int count)
    {
        scoreText.text = startText + count;
    }

}
