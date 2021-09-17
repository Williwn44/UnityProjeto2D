using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    
    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forcJump = 3;

    [Header("Animation Setup")]
    public float animationDuration = .4f;
    private float jumpScaleY = 2.5f;
    private float jumpScaleX = 0.6f;
    private float _currentSpeed;
    public Ease Ease = Ease.OutBack;

    [Header("Animation Player")]

    public string boolRun = "Run";
    public Animator animator;
    public float scaleChangeDuration = .1f;


    private void Update()
    {
        HandleJump();
        HandleMoviment();
        
    }
    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            _currentSpeed = speedRun;
        else
            _currentSpeed = speed;


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if(myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, scaleChangeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            if(myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, scaleChangeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else
        {
            animator.SetBool(boolRun, false);
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity -= friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity += friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.velocity = Vector2.up * forcJump;
            myRigidbody.transform.localScale = Vector2.one;          
            DOTween.Kill(myRigidbody.transform);

            //HandleScaleJump();
        }
        
        
    }
    private void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(Ease);
        myRigidbody.transform.DOScaleY(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(Ease);
    }
   
    
}
