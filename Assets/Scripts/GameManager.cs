using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    ////MVVM test
    //[SerializeField] ScoreView scoreView;
    ////

    [SerializeField] Text scoreText;
    [SerializeField] ScoreView bugsNumberText;

    SpawnController spawnController;
    Camera mainCamera;

    Score bugsNumber;
    Score score;

    private void Start()
    {
        mainCamera = Camera.main;
        spawnController = GetComponent<SpawnController>();

        var scoreModel = new ScoreModel(0);
        var scoreViewModel = new ScoreViewModel(scoreModel);
        bugsNumberText.Initialize(scoreViewModel);

        spawnController.OnChangeCount += scoreViewModel.UpdateState;
        // bugsNumber = new Score(bugsNumberText);
        // spawnController.OnChangeCount += bugsNumber.UpdateCountText;


        ////MVVM test
        //ScoreModel scoreModel = new ScoreModel(0);
        //ScoreViewModel scoreViewModel = new ScoreViewModel(scoreModel);
        //scoreView.Initialize(scoreViewModel);
        //spawnController.OnChangeCount += scoreViewModel.UpdateState;
        ////
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
