using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    public float speed = 5f;
    public float forceJump = 5f;
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public Ease ease = Ease.OutBack;

    public float animationduration = 0.3f;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Walk();
        Jump();
    }

    private void Walk()
    {
        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.linearVelocity = new Vector2(-speed, myRigidbody.linearVelocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.linearVelocity = new Vector2(speed, myRigidbody.linearVelocity.y);
        }
        else
        {
            myRigidbody.linearVelocity = new Vector2(0, myRigidbody.linearVelocity.y);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.linearVelocity = new Vector2(myRigidbody.linearVelocity.x, forceJump);
            transform.localScale = Vector3.one;

            DOTween.Kill(myRigidbody.transform);

            ScaleJump();
        }
    }
    private void ScaleJump()
    {
        myRigidbody.transform.DOScaleY(jumpScaleY, animationduration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidbody.transform.DOScaleX(jumpScaleX, animationduration).SetLoops(2, LoopType.Yoyo).SetEase(ease);      
    }
}
