using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinWeapon : Weapon
{
    public float bulletSpeed=10f;
    public GameObject bulletPrefab;
    private GameObject bulletGo;

    public void Start()
    {
        SpawnBullet();
    }
    public override void Attack()
    {
        if (bulletGo != null)
        {
            bulletGo.transform.parent = null;
            bulletGo.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            bulletGo.GetComponent<Collider>().enabled = true;
            Destroy(bulletGo, 10);
            bulletGo = null;
            Invoke("SpawnBullet", 0.5f);
        }
        else
        {
            return;
        }
    }

    private void SpawnBullet()
    {
        bulletGo = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation);
        bulletGo.transform.parent = transform;
        bulletGo.GetComponent<Collider>().enabled = false;
        if (this.tag == Tag.INTERACTABLE)
        {
            Destroy(bulletGo.GetComponent<JavelinBullet>());

            bulletGo.tag = Tag.INTERACTABLE;
            PickableObject po = bulletGo.AddComponent<PickableObject>();
            po.itemSO = GetComponent<PickableObject>().itemSO;
            Rigidbody rgd = bulletGo.GetComponent<Rigidbody>();
            rgd.useGravity = true;
            rgd.constraints = ~RigidbodyConstraints.FreezeAll; 
            bulletGo.GetComponent<Collider>().enabled = true;
            bulletGo.transform.parent = null;
            Destroy(this.gameObject);
        }
    }
}
