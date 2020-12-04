using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    [SerializeField] private Color colorKey;
    [SerializeField] private int keyId;
    [SerializeField] private GameObject effectKey;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ListKeys>(out ListKeys listKeys))
        {
            listKeys.AddKey(keyId);
            Instantiate(effectKey, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
