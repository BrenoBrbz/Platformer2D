using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    public float speed = 5f;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.velocity = new Vector2(-speed, myRigidbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);
        }
        else
        {
            // Mantém a velocidade horizontal zero quando não pressiona A ou D
            myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
        }
    }
}
