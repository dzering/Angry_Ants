using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class SpawnController : MonoBehaviour, IObserver
{

    public System.Action<int> OnChangeCount;
    public System.Action<int> OnChangeScore;

    int score;
    int Score
    {
        get { return score; }
        set { score = value; OnChangeScore(score); }
    }

    InsectionCreator[] insectionCreator;
    SpawnPoints spawnPoints;
    Transform insectionsHolder;

    [SerializeField] int maxNumber;
    [SerializeField] float timeBetwenSpawn;
    int currentNumber;
    float currentTime;

    void Start()
    {
        currentNumber = 0;
        var factories = Object.Instantiate(Resources.Load("Factories/InsectionsCreator"));
        insectionCreator = Object.FindObjectsOfType<InsectionCreator>();

        var p = Object.Instantiate(Resources.Load("Spawns/SpawnPoints"));
        spawnPoints = Object.FindObjectOfType<SpawnPoints>();

        if (insectionCreator != null)
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        string holderName = "Insections";
        if (!GameObject.Find(holderName))
        {
            insectionsHolder = new GameObject(holderName).transform;
        }

        var rnd = new System.Random();
        while (currentNumber < maxNumber)
        {
 
            int rndItem = rnd.Next(insectionCreator.Length);
            var insection = insectionCreator[rndItem].CreateInsection();
            insection.Events.Subscribe(State.Dead, this);

            int CountSpawnPoints = spawnPoints.Position.Length;
            rndItem = rnd.Next(spawnPoints.Position.Length);
            insection.transform.position = spawnPoints.Position[rndItem].transform.position;
            insection.transform.parent = insectionsHolder;
            currentNumber++;
            OnChangeCount?.Invoke(currentNumber);

            yield return new WaitForSeconds(timeBetwenSpawn);
        }
    }

    void Scoring()
    {
        Score++;
    }

    public void ChangeState()
    {
        Scoring();
    }
}
