using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyholeController : MonoBehaviour
{
    public bool is_match_ = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        is_match_ = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        is_match_ = false;
    }
}
