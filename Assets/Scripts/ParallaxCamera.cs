using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxCamera : MonoBehaviour
{
    public delegate void ParallaxCameraDelegate(float deltaMovement);
     public ParallaxCameraDelegate onCameraTranslate;
     private float oldPosition;

     // Restricting camera to move out of the level border
     private int minPosition = 1;
     private int maxPosition = 190;

    // Start is called before the first frame update
    void Start()
    {
        oldPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x != oldPosition)
         {
             Debug.Log("position --> " + transform.position);
             if (oldPosition > minPosition && oldPosition < maxPosition && onCameraTranslate != null)
             {
                 float delta = oldPosition - transform.position.x;
                 onCameraTranslate(delta);
             }
             oldPosition = transform.position.x;
         }
    }
}
