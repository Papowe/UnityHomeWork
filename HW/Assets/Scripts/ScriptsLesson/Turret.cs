using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speedRotation;
    [SerializeField] private float targetDistance;
    [SerializeField] private float timeBulletSpawn = 3f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gun;
    [SerializeField] private Transform target;
    [SerializeField] private AudioClip audioClipShot;
    [SerializeField] private AudioSource audioSourceShot;

    private Transform bulletDeparturePoint;
    private float duration;

    private void Start()
    {
        bulletDeparturePoint = gun.GetChild(0).transform;
    }
    private void Update()
    {
        if (target)
        {
            Vector3 targetDir = target.position - gun.position + new Vector3(0, 1, 0);

            if (targetDir.sqrMagnitude < targetDistance * targetDistance)
            {
                duration += Time.deltaTime;
                if (duration > timeBulletSpawn)
                {
                    PlaySoundShot();

                    GameObject projecTille = Instantiate(bullet, bulletDeparturePoint.position, bulletDeparturePoint.rotation);
                    projecTille.GetComponent<Bullet>().Damage = damage;
                    duration = 0;
                }

                Vector3 newDir = Vector3.RotateTowards(gun.forward, targetDir, speedRotation * Time.deltaTime, 0.0f);
                gun.rotation = Quaternion.LookRotation(newDir);
            }
        }
    }

    private void PlaySoundShot()
    {
        audioSourceShot.pitch = Random.Range(0.9f, 1.3f);
        audioSourceShot.PlayOneShot(audioClipShot);
    }
}
