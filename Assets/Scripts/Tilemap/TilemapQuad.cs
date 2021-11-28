using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapQuad
{
    private TilemapLayerRenderer layer;
    public readonly int index;

    public TileSprite TileSprite { get; private set; }
    public Vector3 Position { get; private set; }
    public float Rotation { get; private set; }
    public Vector3 QuadSize { get; private set; }

    public bool MarkedToRetire { get; private set; } = false;

    public TilemapQuad(TilemapLayerRenderer layer, int index)
    {
        this.layer = layer;
        this.index = index;
    }

    public void Set(TileSprite tileSprite, Vector3 position, float rotation)
    {
        TileSprite = tileSprite;
        Position = position;
        Rotation = rotation;
        QuadSize = new Vector3(1, 1);
        layer.RenderTilemapQuad(this);
    }

    public void Retire()
    {
        MarkedToRetire = true;
        QuadSize = Vector3.zero;
        layer.RenderTilemapQuad(this);
    }

    public void Retired()
    {
        MarkedToRetire = false;
    }
}
