using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListKeys : MonoBehaviour
{
    [SerializeField] private List<int> listKeys;

    public void AddKey(int keyId)
    {
        listKeys.Add(keyId);
    }

    public bool HaveKey(int keyId)
    {
        if (listKeys.Contains(keyId))
        {
            listKeys.Remove(keyId);
            return true;
        }
        else
        {
            return false;
        }
    }
}
