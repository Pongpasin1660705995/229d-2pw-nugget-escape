using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlsyerController : MonoBehaviour
{
    private CharacterController Controller;
    private Vector3 Velocity;
    private bool Cooldown;

    private GameObject LookAt;
    private int Speed;
    public GameObject Cube1;
    public GameObject Cube2;

    public TextMeshProUGUI ScoreText;
    private int Score;
    private void OntriggerEnter(Collider other)
    {
        if (other.tag == "Score")
        {
            Score++;
        }

        if (other.tag == "Obstacle")
        {
            SceneManager.LoadScene("GamePlay");
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = Score.ToString();
    }
}
