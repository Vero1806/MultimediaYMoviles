using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBandera : MonoBehaviour
{
    public score puntosBandera;
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
        puntosBandera.totalScore += 50;
        Destroy(this.gameObject);
    }
}
