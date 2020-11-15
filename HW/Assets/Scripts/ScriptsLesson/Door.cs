using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private int doorId;
    private Color colorDor;

    private void Start()
    {
        if (key)
        {
            gameObject.GetComponentInChildren<MeshRenderer>().material.color = key.GetComponent<Key>().ColorKey;
            doorId = key.GetComponent<Key>().KeyId;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ListKeys>(out ListKeys listKeys))
        {
            if (listKeys.HaveKey(doorId))
            {
                transform.rotation = Quaternion.LookRotation(-transform.right);
            }
        }
    }    
}
