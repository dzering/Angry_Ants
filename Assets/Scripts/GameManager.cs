using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    Camera mainCamera;
    IObserver score;

    private void Start()
    {
        mainCamera = Camera.main;
        score = new Score(scoreText);
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
