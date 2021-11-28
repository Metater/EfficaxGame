using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapLayerRenderer : MonoBehaviour
{
    [SerializeField] private TilemapManager tilemapManager;
    [Range(1, QuadArrayMaxSize)] [SerializeField] private int quadArrayInitalSize;
    [Range(1.1f, 10f)] [SerializeField] private float quadArrayExpansionFactor;

    private const int QuadArrayMaxSize = 16383;

    private Mesh mesh;

    private Vector3[] vertices;
    private Vector2[] uv;
    private int[] triangles;

    private readonly List<TilemapQuad> quads = new List<TilemapQuad>();
    public int quadArraySize = 0;
    private readonly Queue<TilemapQuad> retiredQuads = new Queue<TilemapQuad>();
    private int nextQuadIndex = 0;
    private readonly Queue<TilemapQuad> renderQueue = new Queue<TilemapQuad>();

    // maybe retiring a quad may collide with new alloc, watch out?

    private void Awake()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        quadArraySize = quadArrayInitalSize;
        MeshUtils.CreateEmptyMeshArrays(quadArraySize, out vertices, out uv, out triangles);
    }

    private void Start()
    {

    }

    public TilemapQuad GetTilemapQuad()
    {
        if (retiredQuads.Count > 0) return retiredQuads.Dequeue();
        if (nextQuadIndex >= QuadArrayMaxSize) throw new Exception($"Cannot allocate more than {QuadArrayMaxSize} quads from mesh!");
        if (nextQuadIndex < quadArraySize)
        {
            TilemapQuad quad = new TilemapQuad(this, nextQuadIndex);
            nextQuadIndex++;
            quads.Add(quad);
            return quad;
        }
        else
        {
            quadArraySize = (int)(quadArraySize * quadArrayExpansionFactor);
            if (quadArraySize > QuadArrayMaxSize) quadArraySize = QuadArrayMaxSize;
            MeshUtils.CreateEmptyMeshArrays(quadArraySize, out vertices, out uv, out triangles);
            quads.ForEach(AddQuadToMesh);
            return GetTilemapQuad();
        }
    }

    public void Render()
    {
        if (renderQueue.Count == 0) return;
        while (renderQueue.Count > 0)
        {
            TilemapQuad quad = renderQueue.Dequeue();
            AddQuadToMesh(quad);
            if (quad.MarkedToRetire)
            {
                quad.Retired();
                RetireTilemapQuad(quad);
            }
        }
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    public void RenderTilemapQuad(TilemapQuad quad)
    {
        renderQueue.Enqueue(quad);
    }

    public void RetireTilemapQuad(TilemapQuad quad)
    {
        retiredQuads.Enqueue(quad);
    }
    private void AddQuadToMesh(TilemapQuad quad)
    {
        MeshUtils.AddToMeshArrays(vertices, uv, triangles, quad.index, quad.Position, quad.Rotation, quad.QuadSize, quad.TileSprite.uv00, quad.TileSprite.uv11);
    }
}
