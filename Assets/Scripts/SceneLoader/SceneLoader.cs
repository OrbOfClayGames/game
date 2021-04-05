using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities.Inspector;

public class SceneLoader : MonoBehaviour
{
    public SceneField sceneToLoad;

    public string levelTransitionname;

    public SceneEntrance sceneEntrance;

    private void Start()
    {
        sceneEntrance.transitionName = levelTransitionname;
    }

    public void LoadSceneAfterFadeToBlackFinished()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<ScreenFaderManager>().StartFadeToBlack();

            //directly load scene if no fade to black required
            //SceneManager.LoadScene(sceneToLoad);

            PlayerController.instance.levelTransitionname = levelTransitionname;
        }

        
    }    
}
