using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTile : Tile
{
    public TilemapQuad quad;

    private StaticTileData data;

    public override void Awake()
    {
        data = Data as StaticTileData;
        quad = tilemapManager.GetTilemapLayerRenderer(7).GetTilemapQuad();
    }
    public override void Render()
    {
        quad.Set(tilemapManager.tileSpriteRegistry.GetTileSprite(data.tileSprite),
            new Vector3(Position.x, Position.y),
            FromOrientation(Orientation));
    }
    public override void Tick(ulong tickId)
    {
        
    }
    public override void Destroy()
    {
        quad.Retire();
    }
}
