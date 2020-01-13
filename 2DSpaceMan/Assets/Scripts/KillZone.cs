using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audio;
   
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
           
            PlayerController player = collision.GetComponent<PlayerController>();
            player.Die();
            audio.Play();
            
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        audio.Stop();
    }
}
