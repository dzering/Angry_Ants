using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] Text scoreText;
    IScoreViewModel scoreViewModel;
    string startText;

    private void Start()
    {
        startText = scoreText.text;
    }
    public void Initialize(IScoreViewModel scoreViewModel)
    {
        this.scoreViewModel = scoreViewModel;
        scoreViewModel.OnChangeText += TextUpdate;
    }

    public void OnChange(int count)
    {
        scoreViewModel.UpdateState(count);
    }

    void TextUpdate(int count)
    {
        scoreText.text = startText + count;
    }

    ~ScoreView()
    {
        scoreViewModel.OnChangeText -= OnChange;
    }
}
