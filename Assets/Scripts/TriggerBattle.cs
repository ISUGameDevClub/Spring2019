using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerBattle : MonoBehaviour
{

    public Animator animator;

    
    private Animation Fade_Out;

    private int levelToLoad;

    public string sceneToLoad;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Destroy(GameObject.Find("Enemy"));
            Fade_Out.Play();
            FadeToLevel(1);
            Application.LoadLevel(sceneToLoad);
            //LoadBattleScreen();
        }
    }
    
    void LoadBattleScreen()
    {
        GameController.control.inBattle = true;
        Destroy(GameObject.Find("Enemy"));
        GameController.control.playerDead = true;
        Application.LoadLevel(sceneToLoad);
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        //Application.LoadLevel(sceneToLoad);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
        OnFadeComplete();
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
