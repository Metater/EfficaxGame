using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TileSprite
{
    public string name;
    public Vector2Int atlasPosition;
    public Vector2 uv00;
    public Vector2 uv11;

    public TileSprite(string name, Vector2Int atlasPosition, Vector2 atlasSize)
    {
        this.name = name;
        this.atlasPosition = atlasPosition;
        uv00 = new Vector2((atlasPosition.x * 16) / atlasSize.x, (atlasPosition.y * 16) / atlasSize.y);
        uv11 = new Vector2(((atlasPosition.x * 16) + 16) / atlasSize.x, ((atlasPosition.y * 16) + 16) / atlasSize.y);
    }
}
