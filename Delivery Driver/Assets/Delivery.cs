using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float destroyDelay = 0.5f;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            Destroy(collision.gameObject, destroyDelay);
            spriteRenderer.color = collision.gameObject.GetComponent<SpriteRenderer>().color;
        }

        else if (collision.gameObject.tag == "Customer" && hasPackage)
        {
            hasPackage = false;
        }
    }
}
