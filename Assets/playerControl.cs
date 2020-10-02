using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpheight = 1.0f;
    public GameObject tornadoEffect;

    private float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Building")
        {
            Debug.Log("Triggered by Building");
            GameObject fx = Instantiate(tornadoEffect, transform.position, Quaternion.identity);
            Destroy(other.gameObject, 2);
            score++;
            Debug.Log("score: " + score);
        }
        
    }
}
