using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] ScoreView scoreCount;
    [SerializeField] ScoreView enemyCount;

    SpawnController spawnController;
    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        spawnController = GetComponent<SpawnController>();

        enemyCount.Initialize(new ScoreViewModel(new ScoreModel(0)));
        scoreCount.Initialize(new ScoreViewModel(new ScoreModel(0)));
        spawnController.OnChangeCountEnemy += enemyCount.OnChange;
        spawnController.OnChangeScorePlayer += scoreCount.OnChange;
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
