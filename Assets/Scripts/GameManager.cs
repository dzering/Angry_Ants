using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] ScoreView scoreText;
    [SerializeField] ScoreView bugsNumberText;

    SpawnController spawnController;
    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        spawnController = GetComponent<SpawnController>();

        bugsNumberText.Initialize(new ScoreViewModel(new ScoreModel(0)));
        scoreText.Initialize(new ScoreViewModel(new ScoreModel(0)));
        spawnController.OnChangeCountEnemy += bugsNumberText.OnChange;
        spawnController.OnChangeScorePlayer += scoreText.OnChange;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) Action();
    }

    void Action()
    {
        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out var hit, Mathf.Infinity))
        {
            if (hit.collider.TryGetComponent<EnemyBase>(out var p)) p.Death(0);
        }
    }
}
