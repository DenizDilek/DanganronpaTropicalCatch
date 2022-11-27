using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false ;
    public TextMeshProUGUI scoreText;
    public float _currentTime;
    public TextMeshProUGUI _timerText ;
    public TextMeshProUGUI _endGameScore ;
    public GameObject gameOverUI;
    public GameObject sequenceUI;
    public float _duration;
    public GameObject AudioManager;
    
    private int score ;
    public float restartDelay = 1f;
    
    
    
    // Start is called before the first frame update
    void Awake(){
        if(!FindObjectOfType<AudioManager>()){
            Instantiate(AudioManager);
        }
        StartCoroutine(WaitSequence());
    }
    void Start()
    {
        
        score = 0 ;
        scoreText.text = "X " + score;
        _currentTime = _duration;
        _timerText.text = _currentTime.ToString();
        StartCoroutine(CountdownTime());


    }
    void Update()
    {
        if(_currentTime == 0){
            _endGameScore.text = score.ToString();
            gameOverUI.SetActive(true);
           
            _currentTime = _duration;
            if(gameHasEnded == false){
            {
                gameHasEnded = true;
                PlayEndGameMusic();
                Time.timeScale = 0f;
                
            }
        }
        }
    }
    public void PlayEndGameMusic(){
        StartCoroutine(EndGameMusic());
        
    }
    IEnumerator EndGameMusic(){
        AudioManager am = FindObjectOfType<AudioManager>();
        am.Play("EndGame");
        while(gameHasEnded){
            if(!gameHasEnded){
            
            am.Stop("EndGame");
            break;
            }
            yield return new WaitForSecondsRealtime(1f);
        }
        

        
        yield return null;
    }
    public void UpdateScore(int AddtoScore){
        score += AddtoScore ; 
        scoreText.text ="X " + score;

    }
    public void EndGame(){
        if(gameHasEnded == false){
            {
                gameHasEnded = true ;
                
            }
        }
    }
    public void Restart(){
        gameHasEnded = false;
        AudioManager am = FindObjectOfType<AudioManager>();
        am.StopAllAudios();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    IEnumerator CountdownTime(){
        AudioManager am = FindObjectOfType<AudioManager>();
        am.Play("MainTheme");
        am.SkipSeconds("MainTheme",15);
        while(_currentTime>0){
         yield return new WaitForSeconds(1f);
          if(_currentTime <= 10){
                _timerText.faceColor = Color.red;
            }else if(_currentTime == 0){
                _timerText.color = Color.white;
            }
         
         _currentTime--;
         _timerText.text = _currentTime.ToString();
        } 
        am.Stop("MainTheme");
        yield return null;
    }
    IEnumerator WaitSequence(){
        Transform text = sequenceUI.transform.Find("Text");
        Animator animator = text.gameObject.GetComponent<Animator>();
        TextMeshProUGUI txtinside =text.gameObject.GetComponent<TextMeshProUGUI>();
        Time.timeScale = 0f;
        sequenceUI.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        animator.SetBool("Ready",true);
        txtinside.text = "Go !";
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1f;
        sequenceUI.SetActive(false);
        yield return null;
        
    }

}
