using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Static Tile Data", menuName = "Scriptable Objects/Tile Data/New Static Tile Data")]
public class StaticTileData : TileData
{
    public bool inferName = false;
    public string tileSprite;

    public override Tile NewTile(TilemapManager tilemapManager, TileData data, Vector2Int position, int layer, Orientation orientation)
    {
        return new StaticTile().Init(tilemapManager, data, position, layer, orientation);
    }

    public void OnValidate()
    {
        if (inferName)
        {
            inferName = false;
            tileSprite = name + " 0";
        }
    }
}
