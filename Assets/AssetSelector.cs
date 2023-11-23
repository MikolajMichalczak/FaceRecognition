using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AssetSelector : MonoBehaviour
{
    [SerializeField]
    XROrigin origin;

    [SerializeField]
    List<GameObject> prefabs = new List<GameObject>();

    int index;
    bool change = false;
    int iter = 0;

    public void Update()
    {
        if(index > prefabs.Count)
        {
            index = 0;
        }
        if(index < 0)
        {
            index = prefabs.Count - 1;
        }
        
        origin.GetComponent<ARFaceManager>().facePrefab = prefabs[index];
        if(change)
        {
            origin.GetComponent<ARFaceManager>().enabled = false;
            iter++;
            if(iter > 10)
            {
                iter = 0;
                change = false;
                origin.GetComponent<ARFaceManager>().enabled = true;
            }
        }
    }

    public void IncrementIndex()
    {
        index++;
        change = true;
    }

    public void DecrementIndex()
    {
        index--;
        change = true;
    }
}
