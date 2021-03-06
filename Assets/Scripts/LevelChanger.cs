﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : Singleton<LevelChanger>
{
    public Animator animator;

    private int levelToLoad;

    private TriggerBattle battleTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetMouseButtonDown(0))
        {
            FadeToLevel(1);
        }*/
    }

    public void FadeToNextLevel ()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
        //OnFadeComplete();
    }

    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
