using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile
{
    protected TilemapManager tilemapManager;
    public TileData Data { get; protected set; }
    public Vector2Int Position { get; protected set; }
    public int Layer { get; protected set; }
    public Orientation Orientation { get; protected set; }

    public Tile Init(TilemapManager tilemapManager, TileData data, Vector2Int position, int layer, Orientation orientation)
    {
        this.tilemapManager = tilemapManager;
        Data = data;
        Position = position;
        Layer = layer;
        Orientation = orientation;
        Awake();
        Render();
        return this;
    }

    public abstract void Awake();

    public abstract void Render();

    public abstract void Tick(ulong tickId);

    public abstract void Destroy();

    public static float FromOrientation(Orientation orientation)
    {
        return orientation switch
        {
            Orientation.Right => 0f,
            Orientation.Up => 90f,
            Orientation.Left => 180f,
            Orientation.Down => 270f,
            _ => 0f,
        };
    }
}
