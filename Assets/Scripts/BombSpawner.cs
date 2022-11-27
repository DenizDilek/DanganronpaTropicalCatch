using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public int ExistingTimer;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(BombSpawnerEnd());
        StopCoroutine(BombSpawnerEnd());
        
    }

    // Update is called once per frame
    IEnumerator BombSpawnerEnd(){
        yield return new WaitForSeconds(ExistingTimer);
        Destroy(gameObject);
    }
}
