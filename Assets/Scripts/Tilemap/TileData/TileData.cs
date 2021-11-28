using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileData : ScriptableObject
{
    public List<string> tags = new List<string>();
    public abstract Tile NewTile(TilemapManager tilemapManager, TileData data, Vector2Int position, int layer, Orientation orientation);
}
