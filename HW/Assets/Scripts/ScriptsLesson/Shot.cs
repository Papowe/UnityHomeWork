using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private int damageBullet;
    [SerializeField] private Transform bulletDeparturePoint;
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private AudioClip audioClipShot;
    [SerializeField] private AudioSource audioSourceShot;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaySoundShot();

            GameObject projecTille = Instantiate(prefabBullet, bulletDeparturePoint.position, bulletDeparturePoint.rotation);
            projecTille.GetComponent<Bullet>().Damage = damageBullet;
        }
    }

    private void PlaySoundShot()
    {
        audioSourceShot.pitch = Random.Range(0.9f, 1.3f);
        audioSourceShot.PlayOneShot(audioClipShot);
    }
}
