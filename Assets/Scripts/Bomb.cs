using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            AudioManager am = FindObjectOfType<AudioManager>();
            am.Play("CaptureBad");
            gameManager.UpdateScore(-5);
            Destroy(gameObject);
        }
    }
}
