using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    public GameObject tennisBall;
    public AudioClip audioClip;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        audioSource.volume = GetComponent<Rigidbody>().GetComponent<Rigidbody>().velocity.magnitude;
        audioSource.PlayOneShot(audioClip);
    }
}
