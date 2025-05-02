using UnityEngine;

public class DestroyNugget : MonoBehaviour
{
    private float topBound = 10f;
    private float lowerBound = -10f;
    private PlayerController player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.GetComponent<PlayerController>();
        }
    }

    void Update()
    {
        if (transform.position.y > topBound || transform.position.y < lowerBound)
        {
            if (player != null)
            {
                player.lives = 0;
                player.GameOver();
            }
        }
    }
}
