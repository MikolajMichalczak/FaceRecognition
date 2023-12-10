using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TilesCreator : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;
    private AssetSelector assetSelector;

    void Start()
    {
        assetSelector = AssetSelector.Instance;
        int idx = 0;

        foreach (ARModel model in assetSelector.models)
        {
            GameObject tile = Instantiate(tilePrefab);
            tile.transform.SetParent(this.gameObject.transform, false);

            TMPro.TextMeshProUGUI modelName = tile.transform.Find("Name").GetComponent<TMPro.TextMeshProUGUI>();
            Image modelImage = tile.transform.Find("Image").GetComponent<Image>();
            tile.GetComponent<TileIndex>().Index = idx;

            modelName.text = model.name;
            modelImage.sprite = model.icon;
            idx++;

        }
    }
    
}
