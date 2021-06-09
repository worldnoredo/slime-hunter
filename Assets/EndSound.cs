using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSound : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying){
            Destroy(gameObject);
        }
    }
}
