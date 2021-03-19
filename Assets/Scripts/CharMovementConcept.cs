using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovementConcept : MonoBehaviour
{
    // config parameters
    [SerializeField] float xVelocity = 3f;

    // state
    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {            
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, 0f);
        }
    }
}
