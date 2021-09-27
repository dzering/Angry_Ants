using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text bugsNumberText;

    SpawnController spawnController;
    Camera mainCamera;

    Score bugsNumber;
    Score score;

    private void Start()
    {
        mainCamera = Camera.main;
        bugsNumber = new Score(bugsNumberText);
        spawnController = GetComponent<SpawnController>();
        spawnController.OnChangeCount += bugsNumber.UpdateCountText;
        // Реализовать подписку в Спаунере, при создании каждого насекомого.
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
