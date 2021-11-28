using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TileRegistry : MonoBehaviour
{
    #if UNITY_EDITOR
    [SerializeField] private bool refresh = false;
    public void OnValidate()
    {
        if (refresh)
        {
            refresh = false;
            string[] guids = AssetDatabase.FindAssets("t:TileData", new string[] { "Assets/Scriptable Objects/Tiles" });
            TileData[] tileDataAssets = new TileData[guids.Length];
            for (int i = 0; i < guids.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                tileDataAssets[i] = AssetDatabase.LoadAssetAtPath<TileData>(path);
            }
            registry = new List<TileData>(tileDataAssets);
        }
    }
    #endif

    [SerializeField] private List<TileData> registry = new List<TileData>();

    private void Awake()
    {
        
    }

    public TileData GetTileData(string name)
    {
        return registry.Find(tileData => tileData.name == name);
    }
}
