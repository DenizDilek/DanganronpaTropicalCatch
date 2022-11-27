using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public void mouseOn(){
        AudioManager am = FindObjectOfType<AudioManager>();
        am.Play("ButtonHover");
    }
     public void mouseOff(){
        
    }
    public void mouseClick(){
        AudioManager am = FindObjectOfType<AudioManager>();
        am.Play("ButtonPressed");
    }
}
