using TMPro;
using UnityEngine;

public class LoopCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI timeBetweenEnemySpawnText;
    private int _maxNumber = 4;
    private int _number;
    private float _timeBetweenEnemySpawn = 2f;
    private float _timeBetweenEnemySpawnStart;
    private float _currentTime;
    private bool _isExecute;

    public void Start()
    {
        _maxNumber++;
        _timeBetweenEnemySpawnStart = _timeBetweenEnemySpawn;
        timeBetweenEnemySpawnText.text = _timeBetweenEnemySpawn.ToString();
    }

    private void Update()
    {
        Execute();
    }

    private void Execute()
    {
        if (_currentTime < _timeBetweenEnemySpawn)
        {
            _currentTime += Time.deltaTime;
            return;
        }
        
        _number++;
        _number %= _maxNumber;
       
        if (_number == 0)
        {
            _number++;
            _timeBetweenEnemySpawn--;
            timeBetweenEnemySpawnText.text = _timeBetweenEnemySpawn.ToString();
        }

        if (_timeBetweenEnemySpawn == 0)
        {
            _timeBetweenEnemySpawn = _timeBetweenEnemySpawnStart;
            timeBetweenEnemySpawnText.text = _timeBetweenEnemySpawn.ToString();
        }

        _currentTime = 0;
        counterText.text = _number.ToString();
    }
}
