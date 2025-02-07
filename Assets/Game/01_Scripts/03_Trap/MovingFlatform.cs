using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
            return;

        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
            return;

        if (collision.transform != null && collision.transform.parent == transform)
        {
            collision.transform.SetParent(null);
        }
    }
}
