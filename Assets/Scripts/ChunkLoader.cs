using System.Collections.Generic;
using UnityEngine;

public class ChunkLoader : MonoBehaviour
{
    [Header("Chunk Loader Settings")]
    public int chunkSize = 16;     // cells per chunk side (conceptual)
    public float cellSize = 1f;    // world units per cell
    public int loadRadius = 2;     // chunks outward to load
    public Transform player;       // assign in inspector or auto-find by tag "Player"
    public GameObject chunkPrefab; // Prefab for the chunk

    private HashSet<Vector2Int> loaded = new HashSet<Vector2Int>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
        }
        UpdateLoadedChunks(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        UpdateLoadedChunks();
    }

    void UpdateLoadedChunks(bool force = false)
    {
        Vector2Int playerChunk = WorldToChunk(player.position);

        // build desired chunk set
        var desired = new HashSet<Vector2Int>();
        for (int dx = -loadRadius; dx <= loadRadius; dx++)
        {
            for (int dy = -loadRadius; dy <= loadRadius; dy++)
            {
                desired.Add(new Vector2Int(playerChunk.x + dx, playerChunk.y + dy));
            }
        }

        // unload those not desired
        var toUnload = new List<Vector2Int>();
        foreach (var c in loaded)
            if (!desired.Contains(c)) toUnload.Add(c);

        foreach (var c in toUnload)
        {
            UnloadChunk(c);
            loaded.Remove(c);
        }

        // load missing ones
        foreach (var c in desired)
            if (!loaded.Contains(c) || force)
            {
                LoadChunk(c);
                loaded.Add(c);
            }
    }

    Vector2Int WorldToChunk(Vector2 worldPos)
    {
        int cx = Mathf.FloorToInt(worldPos.x / (chunkSize * cellSize));
        int cy = Mathf.FloorToInt(worldPos.y / (chunkSize * cellSize));
        return new Vector2Int(cx, cy);
    }

    void UnloadChunk(Vector2Int c)
    {
        string objName = $"Chunk_{c.x}_{c.y}";
        var obj = GameObject.Find(objName);
        if (obj != null)
        {
            Destroy(obj);
        }
    }

    void LoadChunk(Vector2Int c)
    {
        var go = new GameObject($"Chunk_{c.x}_{c.y}");
        go.transform.position = new Vector3(c.x * chunkSize * cellSize, c.y * chunkSize * cellSize, 0f);

        //var go = (GameObject) Instantiate(chunkPrefab, 
        //    new Vector3(c.x * chunkSize * cellSize, c.y * chunkSize * cellSize, 0f), 
        //    Quaternion.identity);
        //go.name = $"Chunk_{c.x}_{c.y}";

        var chunk = go.AddComponent<Chunk>();
        chunk.Init(c, chunkSize, cellSize, chunkPrefab);
    }
}
