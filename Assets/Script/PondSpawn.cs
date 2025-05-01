using UnityEngine;

public class Spawner2D : MonoBehaviour
{
    public GameObject[] prefabTypeA;      // ประเภท A (เช่น ท่อ)
    public GameObject[] prefabTypeB;      // ประเภท B (เช่น เมฆ)

    public float spawnDistance = 20f;
    public float prefabMoveSpeed = 5f;

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
        // เลือกประเภท A หรือ B
        GameObject[] chosenGroup = Random.value < 0.6f ? prefabTypeA : prefabTypeB;

        // สุ่ม prefab จากกลุ่มที่เลือก
        int index = Random.Range(0, chosenGroup.Length);
        GameObject prefab = chosenGroup[index];

        // สร้างและกำหนดการเคลื่อนที่
        GameObject spawned = Instantiate(prefab, transform.position, Quaternion.identity);
        spawned.AddComponent<Moveleft>().speed = prefabMoveSpeed;

        lastSpawned = spawned;
    }
}