using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;
    public Rigidbody2D body;
    private SpriteRenderer sprite;

    public GameObject bombSpawner;
    private float position ;
    public float speed = 5f; 
    private bool didArrive = false;
    public GameObject goodStuff;
    public GameObject badStuff;

    public bool spawnGood = true;
    public bool spawnBad = true;
    [SerializeField] public float TimeBetweenObjectPositive =5f;
    [SerializeField] public float TimeBetweenObjectNegative =5f;
    [SerializeField] public float TimeBetweenMoves = 1f;


    
    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        position = Random.Range(-3f,3f);
        StartCoroutine(SpawnGood());
        StartCoroutine(SpawnBad());
        
    }
    public void Update(){
        MoveAi();
        
        
        
    }
    public void MoveAi(){
        float direction =1f;
        if(position<transform.position.x || position>transform.position.x){
            
            
            if(position-0.3<transform.position.x && transform.position.x<position+0.3){
                didArrive = true;
                position = Random.Range(-3.3f,3.3f);
                body.velocity = new Vector2(0,0);
                didArrive =false;
                direction = Mathf.Sign(position -transform.position.x) ;
            }
            else{
                direction = Mathf.Sign(position -transform.position.x) ;
            }
        }
        if(!didArrive){
            body.velocity = new Vector2(body.velocity.x+direction*(speed*Time.deltaTime),body.velocity.y);
        }
        if(direction == 1f){
            
            sprite.flipX = true;
        }else{
            sprite.flipX = false;
        }
    }
    IEnumerator SpawnGood(){
        yield return new WaitForSeconds(0.1f);
        while(spawnGood){
            Instantiate(goodStuff,new Vector2(transform.position.x,transform.position.y-0.5f),Quaternion.identity);
            yield return new WaitForSeconds(TimeBetweenObjectPositive);
        }
        
    }
     IEnumerator SpawnBad(){
        yield return new WaitForSeconds(0.1f);
        while(spawnBad){
            float spawner = Random.Range(-3.3f,3.3f);
            if(spawner-0.3<transform.position.x && transform.position.x<spawner+0.3){
                while(spawner-0.3<transform.position.x && transform.position.x<spawner+0.3){
                    spawner = Random.Range(-3.3f,3.3f);
                }
            }
            GameObject BombSpawner = Instantiate(bombSpawner,new Vector2(spawner,transform.position.y+0.1f),Quaternion.identity);
            GameObject Bomb = Instantiate(badStuff,new Vector2(spawner,transform.position.y-1),Quaternion.identity);
            Bomb.GetComponent<Rigidbody2D>().AddForce(new Vector2(10f,-15f)*10);
            yield return new WaitForSeconds(TimeBetweenObjectNegative);
        }
        
    }

    
}
