using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject backgroundPrefab; // Prefab for the background
    private int chunkSize;
    private float cellSize;
    private int loadRadius;

    public void Init(int chunkSize, float cellSize, int loadRadius)
    {
        this.chunkSize = chunkSize;
        this.cellSize = cellSize;
        this.loadRadius = loadRadius;
    }

    public void DrawBackground()
    {
        if (backgroundPrefab == null)
        {
            Debug.LogError("Background prefab not assigned.");
            return;
        }
        float bgSize = chunkSize * cellSize * (loadRadius * 2 + 1);
        Vector3 center = new Vector3(0f, 0f, 10f); // Position it behind the player and chunks
        var bg = Instantiate(backgroundPrefab, center, Quaternion.identity, transform);
        var spriteRenderer = bg.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            bg.transform.localScale = new Vector3(bgSize / spriteRenderer.sprite.bounds.size.x, bgSize / spriteRenderer.sprite.bounds.size.y, 1f);
        }
        else
        {
            Debug.LogError("Background prefab does not have a SpriteRenderer component.");
        }
    }
}
