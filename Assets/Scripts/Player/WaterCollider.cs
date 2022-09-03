using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterCollider : MonoBehaviour
{
    [SerializeReference] GameObject _canvas;
    PlaySound playSound;

    private void Start()
    {
        playSound = GetComponent<PlaySound>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Death")
        {
            _canvas.SetActive(true);
            playSound.PlayFromList(2);
        }
    }
}
