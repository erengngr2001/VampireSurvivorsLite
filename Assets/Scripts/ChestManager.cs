using UnityEngine;

public class ChestManager : MonoBehaviour
{
    int cellIndex;
    Chunk parentChunk;

    public void Init(Chunk chunk, int cellIndex)
    {
        this.parentChunk = chunk;
        this.cellIndex = cellIndex;
    }


}
