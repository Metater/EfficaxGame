using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Basic Tile Data", menuName = "Scriptable Objects/Tile Data/New Basic Tile Data")]
public class BasicTileData : TileData
{
    public List<string> tileSprites;
    public ulong ticksPerFrame;

    // later add option for using the same sprites as the name and find them automatically??!??

    public override Tile NewTile(TilemapManager tilemapManager, TileData data, Vector2Int position, int layer, Orientation orientation)
    {
        return new BasicTile().Init(tilemapManager, data, position, layer, orientation);
    }
}
