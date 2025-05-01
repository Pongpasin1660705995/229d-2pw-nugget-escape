using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlsyerController : MonoBehaviour
{
    private CharacterController Controller;
    private Vector3 Velocity;
    private bool Cooldown;
    public float speed;

    public float jumpTime = 0.3f; // ���ҷ������件֧�ش�٧�ش
    public float jumpHeight = 2f; // �����٧�ͧ��á��ⴴ
    public Rigidbody2D rb; // ����Ф��

    private Rigidbody2D rb2d;
    private GameObject LookAt;
    private float moveInput;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 origin = rb.position;
            Vector2 target = origin + new Vector2(0, jumpHeight); // ���ⴴ��鹵��᡹ Y
            Vector2 velocity = CalculateProjectileVelocity(origin, target, jumpTime);
            rb.velocity = velocity; // ��˹������������������ⴴ
        }

        ScoreText.text = Score.ToString();
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;

        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        return new Vector2(velocityX, velocityY);
    }
}
