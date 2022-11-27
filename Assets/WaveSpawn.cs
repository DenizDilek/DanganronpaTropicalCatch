using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawn : MonoBehaviour
{
    public GameObject waveObject;
    public bool isSpawning;
    public float waveSpeed = 1f;
    private void Awake() {
        StartCoroutine(SpawnTimely());
    }
    private void Update() {
        
    }
    IEnumerator SpawnTimely(){
        while(isSpawning){
            int times = Random.Range(1,8);
            for(int i=0;i<=times;i++){
                StartCoroutine(SpawnWaves());
            }
            yield return new WaitForSeconds(3);
        }
        yield break;
        
    }
    IEnumerator SpawnWaves(){
        float numberX = Random.Range(-4f,4f);
        float numberY = Random.Range(0f,1f);
            yield return new WaitForSeconds(1);
            GameObject newWave = Instantiate(waveObject,new Vector2(transform.position.x+numberX,transform.position.y-numberY),Quaternion.identity);
            newWave.transform.parent = gameObject.transform;
            newWave.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f,-10f)*waveSpeed);
            
            yield return new WaitForSeconds(3);
            Destroy(newWave);
            yield break ;
            
        
    }
}
