using UnityEngine;

public class SpawnSwords : MonoBehaviour
{
    public GameObject Swords;
    public GameObject Spawner1;
    public GameObject Spawner2;
    
    void Start()
    {
        float RandomfLoat1 = Random.Range(0.5f, 15f);
        Spawner1.transform.position = new Vector3(Spawner1.transform.position.x, RandomfLoat1, Spawner1.transform.position.z);
        Instantiate(Swords, Spawner1.transform);
        float RandomfLoat2 = Random.Range(0.5f, 15f);
        Spawner2.transform.position = new Vector3(Spawner2.transform.position.x, RandomfLoat1, Spawner2.transform.position.z);
        Instantiate(Swords, Spawner2.transform);
    }
    
    void Update()
    {
        
    }
}
