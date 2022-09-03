using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    //[SerializeField] string _nextSceneName;
    PlaySound playSound;
    [SerializeField] AudioSource music;
    [SerializeField] GameObject _canvas;

    private void Start()
    {
        playSound = GetComponent<PlaySound>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            music.volume = 0.1f;
            playSound.Play();
            _canvas.SetActive(true);
            //Invoke("NextScene", playSound.source.clip.length);             
        }
    }

    /*
    private void NextScene()
    {
        SceneManager.LoadScene(_nextSceneName);
    }
    */
}
