using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] private float rot_angle_ = 30.0f;
    [SerializeField] private LockManager lock_manager_;
    private bool is_dragged_ = false;
    private PlayerController player_;
    private GameManager game_manager_;

    private void Awake()
    {
        player_ = FindObjectsOfType<PlayerController>()[0];
        game_manager_ = FindObjectsOfType<GameManager>()[0];
    }

    private void Update()
    {
        if (is_dragged_)
        {
            DoMove();
            if (Input.GetMouseButton(1))
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + rot_angle_ * Time.deltaTime);
            }
        }
    }

    private void DoMove()
    {
        Vector2 mouse_pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 obj_world_pos = Camera.main.ScreenToWorldPoint(mouse_pos);
        transform.position = obj_world_pos;
    }

    private void OnMouseDown()
    {
        is_dragged_ = true;
    }

    private void OnMouseUp()
    {
        is_dragged_ = false;
        //if (lock_manager_.CanUnlock())
        //{
        //    Debug.Log("> CanUnlock!");
        //}
        if (lock_manager_.CheckUnlockProgress() >= player_.GetUnlockThreshold())
        {
            Debug.Log("> CanUnlock!");
            game_manager_.GoToNextLevel();
        }
    }
}
