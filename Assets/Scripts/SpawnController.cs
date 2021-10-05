using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class SpawnController : MonoBehaviour, IObserver
{
    public event System.Action<int> OnChangeCountEnemy;
    public event System.Action<int> OnChangeScorePlayer;

    [SerializeField] int maxNumber;
    [SerializeField] float timeBetwenSpawn;

    SpawnPoints spawnPoints;
    Transform insectionsHolder;

    int killedEnemies;
    int currentNumberEnemies;
    float currentTime;
    public int KilledEnemies
    {
        get { return killedEnemies; }
        set { killedEnemies = value; OnChangeScorePlayer(killedEnemies); }
    }

    void Start()
    {
        currentNumberEnemies = 0;

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
        while (currentNumberEnemies < maxNumber)
        {
            var spider = factory.CreateInsection();
            spider.events.Subscribe(State.Dead, this);

            int NumberOfSpawnPoints = spawnPoints.Position.Length;
            var rndItem = rnd.Next(spawnPoints.Position.Length);
            spider.transform.position = spawnPoints.Position[rndItem].transform.position;
            spider.transform.parent = insectionsHolder;
            currentNumberEnemies++;
            OnChangeCountEnemy?.Invoke(currentNumberEnemies);

            yield return new WaitForSeconds(timeBetwenSpawn);
        }
    }

    void Scoring()
    {
        KilledEnemies++;
        currentNumberEnemies--;
        OnChangeCountEnemy?.Invoke(currentNumberEnemies);

    }

    public void UpdateState()
    {
        Scoring();
    }
}
