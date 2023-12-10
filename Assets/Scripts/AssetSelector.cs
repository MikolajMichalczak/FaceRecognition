using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR.ARFoundation;

public class AssetSelector : MonoBehaviour
{
    [SerializeField] private XROrigin origin;
    [SerializeField] public List<ARModel> models = new List<ARModel>();
    private ARFaceManager faceManager;
    private const int framesToSkip = 3;
    private int iter = 0;
    [HideInInspector] public int index = 0;
    [HideInInspector] public bool isChanging = false;

    // Singleton instance
    private static AssetSelector instance;

    public static AssetSelector Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AssetSelector>();
                if (instance == null)
                {
                    Debug.LogError("AssetSelector instance not found in the scene.");
                }
            }
            return instance;
        }
    }

    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        faceManager = origin.GetComponent<ARFaceManager>();
    }

    private void Update()
    {
        if (isChanging)
        {
            index = Mathf.Clamp(index, 0, models.Count - 1);
            faceManager.facePrefab = models[index].prefab;
            ToggleFaceManager(false);
            iter++;

            if (iter > framesToSkip)
            {
                iter = 0;
                isChanging = false;
                ToggleFaceManager(true);
            }
        }
    }

    private void ToggleFaceManager(bool isEnabled)
    {
        faceManager.enabled = isEnabled;
    }
}
