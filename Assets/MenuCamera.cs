using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    private Vector3 startPoaition;
    private int totalxMovement;
    private int totalyMovement;
    private bool toRight;
    private bool toUp;


    // Start is called before the first frame update
    void Start()
    {
        startPoaition = transform.position;
        totalxMovement = 0;
        totalyMovement = 0;
        toRight = true;
        toUp = true;
}

    // Update is called once per frame
    void FixedUpdate()
    {
        totalxMovement++;
        if (toRight && totalxMovement < 400)
        {
            transform.position = transform.position + new Vector3(0.01f, 0);
        }
        else if (toRight && totalxMovement > 400)
        {
            toRight = false;
            totalxMovement = 0;
        }
        else if (!toRight && totalxMovement < 400)
        {
            transform.position = transform.position - new Vector3(0.01f, 0);
        }
        else if (!toRight && totalxMovement > 400)
        {
            toRight = true;
            totalxMovement = 0;
        }

        totalyMovement++;
        if (toUp && totalyMovement < 300)
        {
            transform.position = transform.position + new Vector3(0, 0.01f);
        }
        else if (toUp && totalyMovement > 300)
        {
            toUp = false;
            totalyMovement = 0;
        }
        else if (!toUp && totalyMovement < 300)
        {
            transform.position = transform.position - new Vector3(0, 0.01f);
        }
        else if (!toUp && totalyMovement > 300)
        {
            toUp = true;
            totalyMovement = 0;
        }
    }
}
