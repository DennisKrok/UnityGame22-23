using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Credits: Base https://www.youtube.com/watch?v=n4N9VEA2GFo and Zero
    //Credits: Animation https://www.youtube.com/watch?v=5eVFCZZDlw8

    public float Speed = 7;
    public float JumpForce = 10;

    public readonly float originalSpeed = 7, originalJumpForce = 10;

    private Rigidbody2D _rigidbody;

    public Animator playerAnimator;

    [SerializeField] GameObject pauseMenu;

    [SerializeField] GameObject rightCollider, leftCollider;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        var movement = Input.GetAxis("Horizontal");

        Vector3 velocity = new Vector3();

        if(Input.GetKey(KeyCode.RightArrow) & rightCollider.GetComponent<WallCheck>().HitWall() == false) {
            velocity = new Vector3(velocity.x + Speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow) & leftCollider.GetComponent<WallCheck>().HitWall() == false) {
            velocity = new Vector3(velocity.x - Speed, 0, 0);
        }

        transform.position += velocity * Time.deltaTime;

        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001) {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        } else if(movement == 1 && _rigidbody.velocity.y == 0 || movement == -1 && _rigidbody.velocity.y == 0) {
            if(!GetComponent<PlaySound>().source.isPlaying)
                GetComponent<PlaySound>().PlayFromList(1);

            playerAnimator.SetBool("IsWalking", true);
        } else playerAnimator.SetBool("IsWalking", false);
        
        
        if(Input.GetKeyDown(KeyCode.Escape)) {
            pauseMenu.SetActive(true);
        }
    }

    public void HitWall(string LeftOrRight)
    {
        if(LeftOrRight ==  "right")
        {
            transform.position -= new Vector3(0.1f, 0, 0);
        } else if (LeftOrRight == "left")
        {
            transform.position += new Vector3(0.1f, 0, 0);
        }
    }
}