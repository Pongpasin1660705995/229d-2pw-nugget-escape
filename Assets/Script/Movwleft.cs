using UnityEngine;

public class Movwleft : MonoBehaviour
{
  
       public float speed = 10f;
       private float leftBound = -15f;
   
       void Update()
       {
           transform.Translate(Vector3.left * speed * Time.deltaTime);
   
       }

}
