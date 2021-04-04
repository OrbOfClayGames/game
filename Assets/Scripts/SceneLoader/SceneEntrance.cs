using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    public string transitionName;
    
    // Start is called before the first frame update
    void Start()
    {
        if (transitionName == PlayerController.instance.areaTransitionName)
        {
            PlayerController.instance.transform.position = transform.position;
            PlayerController.instance.GetComponent<Animator>().SetBool("walking", false);            
            PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
