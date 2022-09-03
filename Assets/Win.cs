using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] string _nextSceneName;

    public void NextLevel()
    {
        SceneManager.LoadScene(_nextSceneName);
    }
}
