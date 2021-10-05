using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class SpawnController : MonoBehaviour, IObserver
{
    public event System.Action<int> OnChangeCountEnemy;
    public event System.Action<int> OnChangeScorePlayer;


    SpawnPoints spawnPoints;
    Transform insectionsHolder;

    [SerializeField] int maxNumber;
    [SerializeField] float timeBetwenSpawn;

    int killedEnemiesNumber;
    int currentEnemiesNumber;
    float currentTime;
    public int KilledEnemiesNumber
    {
        get { return killedEnemiesNumber; }
        set { killedEnemiesNumber = value; OnChangeScorePlayer(killedEnemiesNumber); }
    }

    void Start()
    {
        currentEnemiesNumber = 0;
        var p = Object.Instantiate(Resources.Load("Spawns/SpawnPoints"));
        spawnPoints = Object.FindObjectOfType<SpawnPoints>();
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
        while (currentEnemiesNumber < maxNumber)
        {
            var spider = factory.CreateInsection();
            spider.EventM.Subscribe(State.Dead, this);

            int NumberOfSpawnPoints = spawnPoints.Position.Length;
            var rndItem = rnd.Next(spawnPoints.Position.Length);
            spider.transform.position = spawnPoints.Position[rndItem].transform.position;
            spider.transform.parent = insectionsHolder;
            currentEnemiesNumber++;
            OnChangeCountEnemy?.Invoke(currentEnemiesNumber);

            yield return new WaitForSeconds(timeBetwenSpawn);
        }
    }

    void Scoring()
    {
        KilledEnemiesNumber++;
        currentEnemiesNumber--;
        OnChangeCountEnemy?.Invoke(currentEnemiesNumber);
    }

    public void UpdateState()
    {
        Scoring();
    }
}
