using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hidePanel : MonoBehaviour
{
    public GameObject Panel;
    public GameObject backPanel;
    int counter;

    public void showHidePanel()
    {
        counter++;
        if (counter % 2 == 1)
        {
            Panel.gameObject.SetActive(false);
            backPanel.gameObject.SetActive(true);
        }
        else
        {
            Panel.gameObject.SetActive(true);
            backPanel.gameObject.SetActive(false);
        }
    }

}
