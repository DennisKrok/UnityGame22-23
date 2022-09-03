using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int LeftOrRight;
    private string _side;

    private bool hit = false;

    private void Start()
    {
        if (LeftOrRight == 1) {
            _side = "right";
        } else if (LeftOrRight == 2) {
            _side = "left";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
            hit = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
            hit = false;
    }

    public bool HitWall() {
        return hit;
    }
}
