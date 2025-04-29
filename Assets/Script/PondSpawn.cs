using UnityEngine;

public class Spawner2D : MonoBehaviour
{
    public GameObject[] prefabs;          // Array ของ Prefab
    public float spawnDistance = 20f;     // ระยะห่างก่อน spawn ถัดไป
    public float prefabMoveSpeed = 5f;    // ความเร็ว prefab เคลื่อนที่

    private GameObject lastSpawned;

    void Start()
    {
        SpawnNew();
    }

    void Update()
    {
        if (lastSpawned == null || Vector3.Distance(transform.position, lastSpawned.transform.position) >= spawnDistance)
        {
            SpawnNew();
        }
    }

    void SpawnNew()
    {
        int index = Random.Range(0, prefabs.Length);
        GameObject prefab = prefabs[index];

        GameObject spawned = Instantiate(prefab, transform.position, Quaternion.identity);
        spawned.AddComponent<Moveleft>().speed = prefabMoveSpeed;

        lastSpawned = spawned;
    }
}
