using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private int damageBullet;
    [SerializeField] private Transform bulletDeparturePoint;
    [SerializeField] private GameObject prefabBullet;    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projecTille = Instantiate(prefabBullet, bulletDeparturePoint.position, bulletDeparturePoint.rotation);
            projecTille.GetComponent<Bullet>().Damage = damageBullet;
        }
    }
}
