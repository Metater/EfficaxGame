using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tile Sprite Data", menuName = "Scriptable Objects/Tile Sprite Data/New Tile Sprite Data")]
public class TileSpriteData : ScriptableObject
{
    public Vector2Int atlasPosition;
    public uint seriesLength = 1;

    public void Unpack(List<TileSprite> tileSprites, Vector2 atlasSize)
    {
        for (int i = 0; i < seriesLength; i++)
            tileSprites.Add(new TileSprite(name + " " + i, atlasPosition + new Vector2Int(i, 0), atlasSize));
    }
}
