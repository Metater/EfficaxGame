using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTile : Tile
{
    public TilemapQuad quad;

    private BasicTileData data;

    private int frame = 0;

    public override void Awake()
    {
        data = Data as BasicTileData;
        quad = tilemapManager.GetTilemapLayerRenderer(3).GetTilemapQuad();
    }
    public override void Render()
    {
        quad.Set(tilemapManager.tileSpriteRegistry.GetTileSprite(data.tileSprites[frame]),
            new Vector3(Position.x, Position.y),
            FromOrientation(Orientation));
    }
    public override void Tick(ulong tickId)
    {
        if (tickId % data.ticksPerFrame == 0)
        {
            frame = (int)(tickId / data.ticksPerFrame % ((ulong)data.tileSprites.Count));
            Render();
        }
    }
    public override void Destroy()
    {
        quad.Retire();
    }
}
