using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    ////MVVM test
    //[SerializeField] ScoreView scoreView;
    ////

    [SerializeField] ScoreView scoreText;
    [SerializeField] ScoreView bugsNumberText;

    SpawnController spawnController;
    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        spawnController = GetComponent<SpawnController>();

        var scoreNumberModel = new ScoreModel(0);
        var scoreNumberVM = new ScoreViewModel(scoreNumberModel);
        bugsNumberText.Initialize(scoreNumberVM);
        spawnController.OnChangeCount += scoreNumberVM.UpdateState;

        var scoreModel = new ScoreModel(0);
        var scoreViewModel = new ScoreViewModel(scoreModel);
        scoreText.Initialize(scoreViewModel);
        spawnController.OnChangeScore += scoreViewModel.UpdateState;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Action();
        }
    }

    void Action()
    {
        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out var hit, Mathf.Infinity))
        {
            if (hit.collider.TryGetComponent<EnemyBase>(out var p))
            {
                p.Dies();
            }
        }
    }
}
