using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TileSpriteRegistry : MonoBehaviour
{
    #if UNITY_EDITOR
    [SerializeField] private bool refresh = false;
    public void OnValidate()
    {
        if (refresh)
        {
            refresh = false;
            tileSprites.Clear();
            string[] guids = AssetDatabase.FindAssets("t:TileSpriteData", new string[] { "Assets/Scriptable Objects/Tile Sprites" });
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                AssetDatabase.LoadAssetAtPath<TileSpriteData>(path).Unpack(tileSprites, new Vector2(textureAtlasSize.x, textureAtlasSize.y));
            }
        }
    }
    #endif

    [SerializeField] private TilemapManager tilemapManager;

    [SerializeField] private Vector2Int textureAtlasSize;

    [SerializeField] private List<TileSprite> tileSprites = new List<TileSprite>();

    private readonly Dictionary<string, TileSprite> registry = new Dictionary<string, TileSprite>();

    private void Awake()
    {
        tileSprites.ForEach(tileSprite => registry.Add(tileSprite.name, tileSprite));
    }

    public TileSprite GetTileSprite(string name)
    {
        return registry[name];
    }
}
