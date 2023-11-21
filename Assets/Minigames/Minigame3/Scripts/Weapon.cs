using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject Arrow_with_FirePrefab;
    public Transform firePoint;
    public float fireForce = 20F;

    public void Fire()
    {
        GameObject arrow = Instantiate(Arrow_with_FirePrefab, firePoint.position, firePoint.rotation);
        arrow.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, (ForceMode2D)ForceMode2D.Impulse);
    }

}
