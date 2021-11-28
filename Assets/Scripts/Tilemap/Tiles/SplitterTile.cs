using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitterTile : Tile
{
    public TilemapQuad quad;
    public TilemapQuad[] connectedConveyors = new TilemapQuad[4];

    private SplitterTileData data;

    private int frame = 0;

    public override void Awake()
    {
        data = Data as SplitterTileData;
        quad = tilemapManager.GetTilemapLayerRenderer(3).GetTilemapQuad();
        TilemapLayerRenderer conveyors = tilemapManager.GetTilemapLayerRenderer(4);
        for (int i = 0; i < 4; i++)
            connectedConveyors[i] = conveyors.GetTilemapQuad();
    }
    public override void Render()
    {
        quad.Set(tilemapManager.tileSpriteRegistry.GetTileSprite(data.tileSprites[frame]),
            new Vector3(Position.x, Position.y),
            FromOrientation(Orientation));
        //connectedConveyors[0].Set(tilemapManager.tileSpriteRegistry.GetTileSprite("")
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
