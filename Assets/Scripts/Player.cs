using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 3;
    public int maxHealth = 10;
    public int currentHealth = 5;

    public List<Quest> activeQuests;
    public int exp;
    public int gold;
    public int interactRange;
    public LayerMask whatIsQuestgiver;

    void FixedUpdate()
    {
        interact();
    }

    void Start()
    {
        activeQuests = new List<Quest>();
    }
    
    //uses E as keybind
    public void interact()
    {
        if (Input.GetAxis("Interact") == 1)
        {
            //check for any questgivers, if any, show quest window
            Collider2D target = Physics2D.OverlapCircle(gameObject.transform.position, interactRange, whatIsQuestgiver);
            if (target != null)
            {
                target.gameObject.GetComponent<Questgiver>().OpenQuestWindow();
            }

            //other interactions can go here too

        }
    }

    //debug purposes
    public void PrintQuests()
    {
        Debug.Log("Quest: " + activeQuests[0].title);
    }
}
