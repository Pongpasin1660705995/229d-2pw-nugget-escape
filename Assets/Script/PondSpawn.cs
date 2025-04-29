using UnityEngine;

public class Spawner2D : MonoBehaviour
{
    public GameObject[] prefabs;          // Array �ͧ Prefab
    public float spawnDistance = 20f;     // ������ҧ��͹ spawn �Ѵ�
    public float prefabMoveSpeed = 5f;    // �������� prefab ����͹���

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
