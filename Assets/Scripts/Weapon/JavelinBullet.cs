using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinBullet : MonoBehaviour
{
    public int atkValue = 30;
    private Rigidbody rgb;
    private Collider col;

    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == Tag.PLAYER)
        {
            return;
        }
        rgb.velocity = Vector3.zero;
        rgb.isKinematic = true;
        col.enabled = false;

        transform.parent = collision.gameObject.transform;

        Destroy(this.gameObject, 1f);

        if (collision.transform.tag == Tag.ENEMY)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(atkValue);
        }
    }
}
