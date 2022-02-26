using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{
    [SerializeField] private bool is_rand_ = true;
    [SerializeField] private float rot_angle_ = 30.0f;
    [SerializeField] private int rot_dir_ = -1;
    [SerializeField] private Vector2 rot_range_ = new Vector2(20.0f, 70.0f);
    private int rot_count_ = 3;
    private SpriteRenderer img_;
    private List<KeyholeController> keyholes_ = new List<KeyholeController>();

    void Awake()
    {
        img_ = GetComponent<SpriteRenderer>();
        RandRotLock();

        foreach (Transform child in transform)
        {
            KeyholeController control = child.GetComponent<KeyholeController>();
            if (control != null)
            {
                keyholes_.Add(control);
            }
        }
    }

    private void FixedUpdate()
    {
        if (IsPatternMatch())
        {
            img_.color = Color.black;
        }
        else
        {
            img_.color = Color.white;
        }
    }

    public void RandRotLock()
    {
        if (is_rand_)
        {
            int id = int.Parse(transform.name.Substring(transform.name.Length - 1));
            if (id % 2 == 0)
            {
                rot_dir_ = 1;
            }
            else
            {
                rot_dir_ = -1;
            }
            rot_angle_ = Random.Range(rot_range_.x, rot_range_.y); //[minInclusive..maxInclusive]
            rot_count_ = Random.Range(1, 7); //[minInclusive..maxExclusive)
        }
        transform.rotation = Quaternion.Euler(0, 0, rot_angle_ * rot_count_);
    }

    public bool IsPatternMatch()
    {
        foreach (KeyholeController kh in keyholes_)
        {
            if (!kh.is_match_)
            {
                return false;
            }
        }
        return true;
    }

    private void OnMouseDown()
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + rot_angle_ * rot_dir_);
    }
}
