using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopkick : MonoBehaviour
{
    public AudioSource playSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Ball")
        {
            GameObject.Find("Kick").SetActive(false);
            playSound.Play();
        }
        
    }
    

}
