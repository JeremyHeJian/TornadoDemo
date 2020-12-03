using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
   
    public GameObject music;
    bool active = false;

    GameObject[] musicPlayer;

    void Awake()
    {

        musicPlayer = GameObject.FindGameObjectsWithTag("AudioPlayer");
        if(musicPlayer.Length > 0)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        if (!active)
        {
            GameObject sound = Instantiate(music);
            sound.transform.parent = this.gameObject.transform;
        }
        
        

    }
    
}
