using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : Units
{
    //original
    public GameObject UIcontrol;
    private UIcontrol UIControlScript;

    public float speed = 10.0f;
    public float jumpheight = 1.0f;
    //Tornado effects added.
    public GameObject tornadoEffect;
    //Child objects of Player
    public GameObject tornadOff;
    public GameObject tornadOn;

    AudioSource audioSoure;

    [SerializeField] private int tornadoPower;
    // Start is called before the first frame update
    void Start()
    {
        audioSoure = GetComponent<AudioSource>();
        UIControlScript = UIcontrol.GetComponent<UIcontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        float translationZ = Input.GetAxis("Vertical") * speed;
        float translationX = Input.GetAxis("Horizontal") * speed;
        float translationY = Input.GetAxis("Jump") * jumpheight;
        translationZ *= Time.deltaTime;
        translationX *= Time.deltaTime;
        translationY *= Time.deltaTime;
        transform.Translate(translationX, translationY, translationZ);
        if (Input.GetMouseButtonDown(0))
        {
            tornadOff.SetActive(false);
            tornadOn.SetActive(true);
            tornadoPower = 100;
        }
        if (Input.GetMouseButtonUp(0))
        {
            tornadOff.SetActive(true);
            tornadOn.SetActive(false);
            tornadoPower = 1;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Building")
        {
            /**
            Debug.Log("Triggered by Building");
            //Tornado effect and score
            GameObject fx = Instantiate(tornadoEffect, transform.position, Quaternion.identity);
            Destroy(other.gameObject, 2);
            score++;
            Debug.Log("score: " + score);
            //remove fx when it's finished
            Destroy(fx, 2);
            */
            Debug.Log("Triggered by Building");
            if (tornadoPower >= other.GetComponent<Units>().shield)
            {
                other.GetComponent<Units>().ApplyDamage(30);
                if (other.GetComponent<Units>().health <= 0)
                {
                    //Score when building is destroyed.
                    UIControlScript.UpdateScore();
                    //Incresing tornado size when destroy buildings.
                    transform.localScale = transform.localScale + new Vector3(other.GetComponent<Units>().ruinSize, other.GetComponent<Units>().ruinSize, other.GetComponent<Units>().ruinSize);
                }
                audioSoure.Play();
                //Tornado effect and score
                //UIControlScript.UpdateScore();
                GameObject fx = Instantiate(tornadoEffect, transform.position, Quaternion.identity);
                Destroy(fx, 2);
            }
            
        }
    }
}
