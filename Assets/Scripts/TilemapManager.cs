using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase growthTile;

    public Dictionary<Vector3Int, GrassTile> grassTiles;

    private void Awake()
    {
        GridLayout gridLayout = tilemap.GetComponent<GridLayout>();
        grassTiles = new Dictionary<Vector3Int, GrassTile>();  

        BoundsInt bounds = tilemap.cellBounds;
        Debug.Log("bounds: " + bounds);

        foreach (Vector3Int location in tilemap.cellBounds.allPositionsWithin)
        {
            GrassTile tile = (GrassTile) tilemap.GetTile(location);
            
            if (tile != null)
            {
                // Debug.Log("tile " + tile.name + " at " + location.ToString());
                // Make this dynamic later
                tile.m_currentIndex = 0;

                grassTiles.Add(location, tile);
            }
        }
    }

    public void PlantSeed(Vector3Int position)
    {
        StartCoroutine(SetTimerForGrowth(position));
    }

    IEnumerator SetTimerForGrowth(Vector3Int location)
    {
        GrassTile tile = (GrassTile) tilemap.GetTile(location);
        yield return new WaitForSeconds(2.0f);
        tilemap.SetTile(location, growthTile);
    }
}