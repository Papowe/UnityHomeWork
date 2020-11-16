using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private Color colorKey;
    [SerializeField] private int keyId;
    [SerializeField] private float speedRotation;

    public Color ColorKey { get => colorKey; }
    public int KeyId { get => keyId; }

    private void Awake()
    {
        keyId = Random.Range(0, 999);
    }

    private void Start()
    {        
        var objectOfKey = gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (var components in objectOfKey)
        {
            components.material.color = ColorKey;
        }        
    }

    private void Update()
    {
        AnimationKey(speedRotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ListKeys>(out ListKeys listKeys))
        {
            listKeys.AddKey(keyId);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    private void AnimationKey(float speedRotation)
    {        
        transform.Rotate(Vector3.up * speedRotation * Time.deltaTime, Space.World);
    }
}
