using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LockUIController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private bool is_rand_ = true;
    [SerializeField] private float rot_angle_ = 30.0f;
    [SerializeField] private int rot_dir_ = -1;
    [SerializeField] private Vector2 rot_range_ = new Vector2(20.0f, 70.0f);
    private int rot_count_ = 3;
    private RectTransform rectt_;
    private Image img_;

    void Awake()
    {
        rectt_ = GetComponent<RectTransform>();
        img_ = GetComponent<Image>();
        img_.alphaHitTestMinimumThreshold = 0.5f;
        if (is_rand_)
        {
            int id = int.Parse(transform.name.Substring(transform.name.Length-1));
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
        rectt_.rotation = Quaternion.Euler(0, 0, rot_angle_ * rot_count_);
    }

    //private void OnMouseDown()
    //{
    //    rectt_.rotation = Quaternion.Euler(0, 0, rectt_.eulerAngles.z + rot_angle_ * rot_dir_);
    //}

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("> LockController OnPointerDown");
        rectt_.rotation = Quaternion.Euler(0, 0, rectt_.eulerAngles.z + rot_angle_ * rot_dir_);
    }
}
