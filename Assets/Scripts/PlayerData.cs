using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int maxHealth;
    public int currentHealth;
    public float[] position;

    public PlayerData (Player player)
    {
        level = player.level;
        maxHealth = player.maxHealth;
        currentHealth = player.currentHealth;

        position = new float[2]; //Brackey's tutorial did 3 positions but since we are 2d, we may only need 2?
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;

    }
}
