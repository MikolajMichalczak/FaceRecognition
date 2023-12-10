using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileIndex : MonoBehaviour
{
    private int index;

    public int Index
    {
        get
        {
            return index;
        }
        set
        {
            index = value;
        }
    }

    public void SetPrefabIdx()
    {   
        AssetSelector.Instance.isChanging = true;
        AssetSelector.Instance.index = index;
    }

}
