using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerBattle : MonoBehaviour
{
    public string sceneToLoad;

    private void Update()
    {
        findEnemy();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Destroy(GameObject.Find("Enemy"));
            LevelChanger.Instance.FadeToLevel(1);
            //SceneManager.LoadScene(sceneToLoad);
            //LoadBattleScreen();
        }
    }

    public bool findEnemy()
    {
        if (GameObject.Find("Enemy") == false)
        {
            return true;
        }
        return false;
    }
    
    void LoadBattleScreen()
    {
        GameController.control.inBattle = true;
        Destroy(GameObject.Find("Enemy"));
        GameController.control.playerDead = true;
        Application.LoadLevel(sceneToLoad);
    }
    
}
