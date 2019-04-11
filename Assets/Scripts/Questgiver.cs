using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * As of now, each questgiver can only give 1 quest, simpler to implement
 * 
 * 
 */
public class Questgiver : MonoBehaviour
{
    public Quest quest;
    public Player player;

    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;
    public Text experienceText;
    public Text goldText;

    public int questWindowViewDistance;
    public LayerMask whatIsPlayer;

    //no drag and drop for each questgiver
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        questWindow = GameObject.Find("QuestWindow");
    }

    void FixedUpdate()
    {
        ProximityClose();
    }

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        experienceText.text = quest.expReward.ToString();
        goldText.text = quest.goldReward.ToString();
    }

    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
    }

    //closes quest window if player exits specified range
    public void ProximityClose()
    {
        //check for any questgivers, if none exist, close the active window
        Collider2D target = Physics2D.OverlapCircle(gameObject.transform.position, questWindowViewDistance, whatIsPlayer);
        if (target == null && gameObject.GetComponent<Questgiver>().questWindow.activeInHierarchy)
        {
            cout 
            CloseQuestWindow();
        }
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        player.activeQuests.Add(quest);
        player.GetComponent<Player>().PrintQuests();
    }

}
