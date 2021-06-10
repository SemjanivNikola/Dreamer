using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItems : MonoBehaviour
{
    public Text shardCounterDisplayer;
    private int shardCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Shard"))
        {
            Debug.Log("collided");
            Destroy(collider.gameObject);
            shardCounter++;
            shardCounterDisplayer.text = shardCounter.ToString();
        }
    }
}
