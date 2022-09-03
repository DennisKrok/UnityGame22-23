using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBounceSound : MonoBehaviour
{
    //Credits: https://www.youtube.com/watch?v=sOLfxVbUrAc

    PlaySound _playSound;

    private void Start()
    {
        _playSound = GetComponent<PlaySound>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
            _playSound.Play();
    }
}
