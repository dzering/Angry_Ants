using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class SpawnController : MonoBehaviour, IObserver
{
    public event System.Action<int> OnChangeCountEnemy;
    public event System.Action<int> OnChangeScorePlayer;

    int scorePlayer;
    int ScorePlayer
    {
        get { return scorePlayer; }
        set { scorePlayer = value; OnChangeScorePlayer(scorePlayer); }
    }

    //EnemyFactory[] insectionCreator;
    SpawnPoints spawnPoints;
    Transform insectionsHolder;

    [SerializeField] int maxNumber;
    [SerializeField] float timeBetwenSpawn;
    int currentNumber;
    float currentTime;

    void Start()
    {
        currentNumber = 0;
        //var factories = Object.Instantiate(Resources.Load("Factories/InsectionsCreator"));
        //insectionCreator = Object.FindObjectsOfType<EnemyFactory>();

        var p = Object.Instantiate(Resources.Load("Spawns/SpawnPoints"));
        spawnPoints = Object.FindObjectOfType<SpawnPoints>();

        //if (insectionCreator != null)
        //{
        //    StartCoroutine(Spawn());
        //}
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        string holderName = "Insections";
        if (!GameObject.Find(holderName))
        {
            insectionsHolder = new GameObject(holderName).transform;
        }

        var rnd = new System.Random();
        var factory = new SpiderFactory();
        while (currentNumber < maxNumber)
        {

            //int rndItem = rnd.Next(insectionCreator.Length);
            //var insection = insectionCreator[rndItem].CreateInsection();
            // var insection = factory.CreateSpider();
            // insection.Events.Subscribe(State.Dead, this);

            var spider = factory.CreateInsection();
            spider.EventM.Subscribe(State.Dead, this);

            int NumberOfSpawnPoints = spawnPoints.Position.Length;
            var rndItem = rnd.Next(spawnPoints.Position.Length);
            spider.transform.position = spawnPoints.Position[rndItem].transform.position;
            spider.transform.parent = insectionsHolder;
            currentNumber++;
            OnChangeCountEnemy?.Invoke(currentNumber);

            yield return new WaitForSeconds(timeBetwenSpawn);
        }
    }

    void Scoring()
    {
        ScorePlayer++;
    }

    public void ChangeState()
    {
        Scoring();
    }
}
