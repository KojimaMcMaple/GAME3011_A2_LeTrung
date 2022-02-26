using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour
{
    private List<LockController> locks_ = new List<LockController>();
    public float unlock_progress = 0.0f;
    private GameManager game_manager_;

    private void Awake()
    {
        game_manager_ = FindObjectsOfType<GameManager>()[0];

        foreach (Transform child in transform)
        {
            LockController control = child.GetComponent<LockController>();
            if (control != null)
            {
                locks_.Add(control);
            }
        }
    }

    private void FixedUpdate()
    {
        game_manager_.UpdateProgress(CheckUnlockProgress());
    }

    public void SetUpLocks()
    {
        foreach (LockController lc in locks_)
        {
            lc.RandRotLock();
        }
    }

    public bool CanUnlock()
    {
        foreach (LockController lc in locks_)
        {
            if (!lc.IsPatternMatch())
            {
                return false;
            }
        }
        return true;
    }

    public float CheckUnlockProgress()
    {
        int locked = 0;
        int unlocked = 0;
        foreach (LockController lc in locks_)
        {
            if (!lc.IsPatternMatch())
            {
                locked++;
            }
            else
            {
                unlocked++;
            }
        }
        return ((float)unlocked / (float)locks_.Count);
    }
}
