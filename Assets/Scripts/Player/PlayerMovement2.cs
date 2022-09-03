using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50);
    private Rigidbody2D _rb;

    // Update is called once per frame
    void Update()
    {
        /*float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        movement *= Time.deltaTime;

        transform.Translate(movement);*/

        float inputX = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector3(speed.x * inputX, 0);
        _rb.AddForce(movement, ForceMode2D.Impulse);

        movement *= Time.deltaTime;

        //transform.Translate(movement);
    }
}