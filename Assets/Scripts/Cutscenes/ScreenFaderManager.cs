using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class ScreenFaderManager : MonoBehaviour
{
    [Header("Sequences")]
    public CutsceneTimelineBehaviour fadeFromBlackTimeline;
    public CutsceneTimelineBehaviour fadeToBlackTimeline;




    [Header("Events")]
    public UnityEvent fadeFromBlackFinishedEvent;
    public UnityEvent fadeToBlackFinishedEvent;
    
    void Start()
    {
        StartFadeFromBlack();
    }




    public void StartFadeFromBlack()
    {
        fadeFromBlackTimeline.StartTimeline();
    }

    public void StartFadeToBlack()
    {
        fadeToBlackTimeline.StartTimeline();
    }

    public void FadeFromBlackFinished()
    {
        fadeFromBlackFinishedEvent.Invoke();
    }

    public void FadeToBlackFinished()
    {
        fadeToBlackFinishedEvent.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
