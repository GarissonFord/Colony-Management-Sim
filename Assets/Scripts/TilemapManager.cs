using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    /* Referring to the following vid by Shack Man to start out
     * https://www.youtube.com/watch?v=XIqtZnqutGg&t=50s
     */

    [SerializeField] private Tilemap map;

    [SerializeField] private List<WorldTile> worldTiles;

    private Dictionary<TileBase, WorldTile> dataFromTiles;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, WorldTile>();

        foreach (var tileData in worldTiles)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }
}
