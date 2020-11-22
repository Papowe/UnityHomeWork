using System.Collections;
using UnityEngine;


public class Door : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject key;
    [SerializeField] private int doorId;
    private Color colorDor;

    #endregion

    #region UnityMethods

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
                StartCoroutine(ClosingDooor(2));
            }
        }
    }

    #endregion

    #region Methods

    private IEnumerator ClosingDooor(float time)
    {
        Quaternion curentRorartion = transform.rotation;
        Quaternion rightRotation = Quaternion.LookRotation(-transform.right);

        for (float i = 0; i < time; i += Time.deltaTime)
        { 
            transform.rotation = Quaternion.Lerp(curentRorartion, rightRotation, i);
            yield return null;
        }
    }

    #endregion
}
