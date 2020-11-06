using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
# region Singleton
    public static KeyHolder instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of keyholder found");
            return;
        }

        instance = this;
        keyList = new List<Key.KeyType>();
    }
    #endregion

    private List<Key.KeyType> keyList;

    public void AddKey(Key.KeyType keyType)
    {
        keyList.Add(keyType);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    
}
