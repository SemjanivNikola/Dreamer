using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelDoors : MonoBehaviour
{
    public SceneController SceneController;

    public string  nextLevelName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Here. + " + collider);
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Inside");
            SceneController.SceneLoad(nextLevelName);
        }
    }
}
