using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip se1;
    public AudioClip se2;
    AudioSource audioSource;

    void Start() {

        audioSource = this.GetComponent<AudioSource>();

    }

    public void PlayResultSound() {

        audioSource.PlayOneShot(se1);
    
    }

    public void PlayThrowSound() {

        audioSource.PlayOneShot(se2);

    }

}
