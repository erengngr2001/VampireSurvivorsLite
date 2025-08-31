using Unity.VisualScripting;
using UnityEngine;

//[CreateAssetMenu(fileName = "Chunk", menuName = "Scriptable Objects/Chunk")]
public class Chunk : MonoBehaviour
{
    private Vector2Int coord;
    private int size;
    private float cellSize;
    private GameObject chunkPrefab; // Prefab for the chunk

    public void Init(Vector2Int coord, int size, float cellSize, GameObject chunkPrefab)
    {
        this.coord = coord;
        this.size = size;
        this.cellSize = cellSize;
        this.chunkPrefab = chunkPrefab;
        DrawSprite();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Vector3 center = transform.position + new Vector3(size * cellSize / 2f, size * cellSize / 2f, 0f);
        Gizmos.DrawWireCube(center, new Vector3(size * cellSize, size * cellSize, 0f));
    }

    void DrawSprite()
    {
        //var sprite = this.AddComponent<SpriteRenderer>();
        //var prefSprite = chunkPrefab.GetComponent<SpriteRenderer>();

        //Vector3 center = transform.position + new Vector3(size * cellSize / 2f, size * cellSize / 2f, 0f);
        //sprite.transform.position = center;
        ////sprite.transform.localScale = new Vector3(size * cellSize / prefSprite.sprite.bounds.size.x, size * cellSize / prefSprite.sprite.bounds.size.y, 1f);
        //sprite.transform.localScale = prefSprite.transform.localScale;

        //sprite.sprite = prefSprite.sprite;
        //sprite.color = prefSprite.color;
    }
}
