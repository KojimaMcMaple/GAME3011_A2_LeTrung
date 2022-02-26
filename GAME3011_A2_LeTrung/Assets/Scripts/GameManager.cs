using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timer_txt_;
    private float timer_;
    private bool is_victory_ = false;
    [SerializeField] private TMP_Text difficulty_;
    [SerializeField] private TMP_Text progress_;
    [SerializeField] private TMP_Text player_level_;
    [SerializeField] private TMP_Text unlock_threshold_;
    [SerializeField] private List<GameObject> levels_ = new List<GameObject>();
    private int level_idx_ = 0;
    private PlayerController player_;

    private void Awake()
    {
        player_ = FindObjectsOfType<PlayerController>()[0];

        SetupLevel();
    }

    private void FixedUpdate()
    {
        if (!is_victory_)
        {
            if (timer_ > 0)
            {
                timer_ -= Time.deltaTime;
            }
            else
            {
                SetupLevel();
            }
            timer_txt_.text = timer_.ToString();
        }
    }

    public void SetupLevel()
    {
        if (level_idx_ == 0)
        {
            timer_ = 180.0f;
        }
        else if (level_idx_ == 1)
        {
            timer_ = 120.0f;
        }
        else if (level_idx_ == 2)
        {
            timer_ = 60.0f;
        }
        timer_txt_.text = timer_.ToString();

        int tmp = level_idx_ + 1;
        difficulty_.text = "Difficulty: " + tmp.ToString();
        progress_.text = "Progress: 0%";
        player_level_.text = "Player Level: " + player_.player_level;
        unlock_threshold_.text = "Threshold to Unlock: " + player_.GetUnlockThreshold();

        KeyController[] keys = FindObjectsOfType<KeyController>();
        foreach (KeyController key in keys)
        {
            key.transform.position = new Vector3(5.0f, 0, 0);
        }

        LockManager[] locks = FindObjectsOfType<LockManager>();
        foreach (LockManager lok in locks)
        {
            lok.SetUpLocks();
        }
    }

    public void GoToNextLevel()
    {
        if (level_idx_ < levels_.Count)
        {
            levels_[level_idx_].SetActive(false);
            level_idx_++;
            levels_[level_idx_].SetActive(true);
            SetupLevel();
        }
        else
        {
            is_victory_ = true;
            timer_txt_.text = "You Win!";
        }
    }

    public void UpdateProgress(float value)
    {
        progress_.text = "Progress: "+(value*100.0f).ToString()+"%";
    }
}
