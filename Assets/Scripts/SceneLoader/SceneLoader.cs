using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities.Inspector;

public class SceneLoader : MonoBehaviour
{
    public SceneField sceneToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        
    }    
}
