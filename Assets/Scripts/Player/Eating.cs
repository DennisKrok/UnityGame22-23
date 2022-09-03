using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    int _eatenMushroomCals;
    GameObject _lastEatenMushroom;
    [SerializeField] int _mushroomM = 2, _mushroomL = 3;
    [SerializeField] float scaleM = 1, scaleL = 1.6f, basicScale = 0.7f;
    PlaySound _playSound;

    PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playSound = GetComponent<PlaySound>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _eatenMushroomCals > 0)
        {
            LoseCal();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_eatenMushroomCals == 0)
        {
            if (collision.tag == "Mushroom_m")
            {
                Grow(_mushroomM, collision);
            }
            else if (collision.tag == "Mushroom_l")
            {
                Grow(_mushroomL, collision);
            }
        }
    }

    private void Grow(int Cal, Collider2D collision)
    {
        if (Cal == _mushroomM)
        {
            this.gameObject.transform.localScale = new Vector3(scaleM, scaleM, 0); //grow the player size M
            collision.gameObject.SetActive(false); //destroy the mushroom
            _lastEatenMushroom = collision.gameObject;
            _eatenMushroomCals += _mushroomM;

            _playerMovement.Speed *= 0.8f;
            _playerMovement.JumpForce *= 1.5f;

            _playSound.PlayFromList(0);
        }
        else if (Cal == _mushroomL)
        {
            this.gameObject.transform.localScale = new Vector3(scaleL, scaleL, 0); //grow the player to size L
            collision.gameObject.SetActive(false); //destroy the mushroom
            _lastEatenMushroom = collision.gameObject;
            _eatenMushroomCals += _mushroomL;

            _playerMovement.Speed *= 0.5f;
            _playerMovement.JumpForce *= 1.8f;
            
            _playSound.PlayFromList(0);
        }
    }

    private void LoseCal()
    {
        //shrink player to basic scale
        this.gameObject.transform.localScale = new Vector3(basicScale, basicScale, 0);

        //show mushroom again and set the position to the left of the player
        if(Input.GetAxisRaw("Horizontal") > 0)
        _lastEatenMushroom.gameObject.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z);
        else _lastEatenMushroom.gameObject.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);

        _lastEatenMushroom.gameObject.SetActive(true);

        //set amount of mushrooms eaten to zero
        _eatenMushroomCals = 0;

        //set all paremeters of player movement to original values
        _playerMovement.Speed = _playerMovement.originalSpeed;
        _playerMovement.JumpForce = _playerMovement.originalJumpForce;
    }
}
