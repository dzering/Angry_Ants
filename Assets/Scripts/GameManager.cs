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
        spawnController.OnChangeCountEnemy += enemyCount.UpdateChanges;
        spawnController.OnChangeScorePlayer += scoreCount.UpdateChanges;
    }

    private void Update()
    {
        foreach (var item in spawnController.Enemies)
        {
            item.Move();
        }
    }
}
