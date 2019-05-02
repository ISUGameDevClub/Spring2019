using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunFromBattle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LevelChanger.Instance.FadeToLevel(0);
    }
}
