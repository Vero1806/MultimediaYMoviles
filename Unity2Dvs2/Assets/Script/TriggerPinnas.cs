using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TriggerPinnas : MonoBehaviour
{
    public score puntosPinnas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        puntosPinnas.totalScore += 10;
        Destroy(this.gameObject);
    }
}
