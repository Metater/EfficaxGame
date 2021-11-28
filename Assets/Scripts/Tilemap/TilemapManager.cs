using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapManager : MonoBehaviour
{
    [SerializeField] private TilemapLayerRenderer[] tilemapLayerRenderers;
    [SerializeField] private Vector2Int size;
    [SerializeField] private ulong tileTickDivisor;

    public const int Depth = 2;

    public TileSpriteRegistry tileSpriteRegistry;
    public TileRegistry tileRegistry;

    private Tile[,,] tilemap;

    private ulong tickDivider = 0;
    private ulong nextTickId = 0;

    private void Awake()
    {
        tilemap = new Tile[size.x, size.y, Depth];
    }

    private void FixedUpdate()
    {
        if (tickDivider % tileTickDivisor == 0)
        {
            for (int z = 0; z < Depth; z++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    for (int x = 0; x < size.x; x++)
                    {
                        tilemap[x, y, z]?.Tick(nextTickId);
                    }
                }
            }
            nextTickId++;
        }
        tickDivider++;
    }

    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        foreach (TilemapLayerRenderer tilemapLayerRenderer in tilemapLayerRenderers)
        {
            tilemapLayerRenderer.Render();
        }
    }

    public TilemapLayerRenderer GetTilemapLayerRenderer(int layer)
    {
        return tilemapLayerRenderers[layer];
    }

    public Tile SetTile(TileData tileData, Vector2Int position, int layer, Orientation orientation)
    {
        tilemap[position.x, position.y, layer]?.Destroy();
        Tile tile = tileData.NewTile(this, tileData, new Vector2Int(position.x, position.y), layer, orientation);
        tilemap[position.x, position.y, layer] = tile;
        return tile;
    }

    public void DestroyTile(Tile tile)
    {
        DestroyTile(tile.Position, tile.Layer);
    }

    public void DestroyTile(Vector2Int position, int layer)
    {
        tilemap[position.x, position.y, layer].Destroy();
        tilemap[position.x, position.y, layer] = null;
    }
}
