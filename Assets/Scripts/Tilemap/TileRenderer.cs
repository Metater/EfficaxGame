using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRenderer
{
    private readonly TilemapManager tilemapManager;

    public readonly Vector2Int position;

    public readonly List<TileSprite> tileSprites = new List<TileSprite>();

    // keeps track of what quad indicies its using on each layer

    public TileRenderer(TilemapManager tilemapManager, Vector2Int position)
    {
        this.tilemapManager = tilemapManager;
        this.position = position;
    }

    public void Render(string tileSprites)
    {

    }
}
