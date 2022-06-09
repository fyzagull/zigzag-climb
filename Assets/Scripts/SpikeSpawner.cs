using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _verticalSpawnDistance;
    [SerializeField] private float _paddingX;
    [SerializeField] private int _paddingY;

    [Header("Referances")]
    [SerializeField] private GameObject[] _spikePrefabs;

    private int _spawnCount = 0;

    private void Update()
    {
        if (ControlUnit.Instance.Ball.transform.position.y > _spawnCount * _verticalSpawnDistance)
        {
            SpawnSpikes();
            _spawnCount++;
        }
    }

    private void SpawnSpikes()
    {
        var r = Mathf.Abs(transform.position.x);

        var prefab = _spikePrefabs[Random.Range(0, _spikePrefabs.Length)];
        var rotation = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)); ;
        var firstSpike = Instantiate(prefab, new Vector3(Random.Range(-r, r), 10 + ControlUnit.Instance.Ball.transform.position.y + _verticalSpawnDistance + Random.Range(-_paddingY, _paddingY)), rotation);

        prefab = _spikePrefabs[Random.Range(0, _spikePrefabs.Length)];
        rotation = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)); ;
        Instantiate(prefab, new Vector3(firstSpike.transform.position.x + (Random.value <= 0.5f ? 1 : -1) * Random.Range(2, _paddingX), firstSpike.transform.position.y + (Random.value <= 0.5f ? 1 : -1) * Random.Range(5, _paddingY)), rotation);
    }
}
