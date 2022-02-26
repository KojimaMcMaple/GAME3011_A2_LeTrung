using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int player_level = 1;

    public float GetUnlockThreshold()
    {
        if (player_level == 1)
        {
            return 1.0f;
        }
        else if (player_level == 2)
        {
            return 0.8f;
        }
        else if (player_level == 3)
        {
            return 0.6f;
        }
        return 1.0f;
    }
}
