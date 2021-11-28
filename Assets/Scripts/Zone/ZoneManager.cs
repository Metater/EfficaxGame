using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    [SerializeField] private TilemapManager tilemapManager;

    [SerializeField] private bool add = false;
    [SerializeField] private bool remove = false;

    private List<Tile> tiles = new List<Tile>();

    // Tile groups, SOs for diff tiles, data that goes on tiles, contains references to sprites that will be the same for
    // each item type, allows for easily making new tiers

    private void Start()
    {

    }

    private void Update()
    {
        if (add)
        {
            add = false;
            Add();
        }
        if (remove)
        {
            remove = false;
            Remove();
        }
    }

    private void Add()
    {
        if (tiles.Count > 0) Remove();
        TileData tileData = tilemapManager.tileRegistry.GetTileData("Grass");
        for (int y = 0; y < 64; y++)
        {
            for (int x = 0; x < 64; x++)
            {
                tiles.Add(tilemapManager.SetTile(tileData, new Vector2Int(x, y), 0, Orientation.Right));
            }
        }
    }

    private void Remove()
    {
        foreach (Tile tile in tiles)
        {
            tilemapManager.DestroyTile(tile);
        }
        tiles.Clear();
    }
}
