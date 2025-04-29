using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    private float topBound = 25;
    private float lowerBound = -3;

    // Update is called once per frame
    void Update()
    {
        // [2] if the object goes out of the top bound
        if (transform.position.x > topBound)
        {
            // [3] destroy the object
            Destroy(gameObject);
        }
        else if (transform.position.x < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
