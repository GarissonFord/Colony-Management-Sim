using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class TileSelector : MonoBehaviour
{
    TilemapManager tilemapManager;

    InputAction lookAction;
    // Technically not an "attack" yet, but it's already mapped to left-click so this is out of convenience
    InputAction attackAction;
    InputAction selectAction;

    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase selectedTile;
    [SerializeField] private TileBase newSeedTile;
    [SerializeField] private Vector2 rawPointerPosition;
    [SerializeField] private Vector3 pointerPosition;
    [SerializeField] private Vector3Int pointerCellPosition;
    private Vector3Int previousSelectedCellPosition;
    // [SerializeField] private bool cellIsSelected;

    GridLayout gridLayout;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tilemapManager = GameObject.Find("Tilemap Manager").GetComponent<TilemapManager>();
        previousSelectedCellPosition = new Vector3Int(0, 0, 0);
        gridLayout = tilemap.GetComponent<GridLayout>();
        lookAction = InputSystem.actions.FindAction("Look");
        attackAction = InputSystem.actions.FindAction("Attack");
        selectAction = InputSystem.actions.FindAction("Select");
        CheckIfCellIsSelected();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPointerPosition();
        CheckIfCellIsSelected();

        if (attackAction.WasPerformedThisFrame())
        {
            // Debug.Log("attackAction.WasPerformedThisFrame()");
            GrassTile grassTile = (GrassTile) tilemap.GetTile(pointerCellPosition);
            
            if (grassTile != null)
            {
                // grassTile.PlantSeed();
                // Debug.Log("Planting seeds at cell " + pointerCellPosition.ToString());
                tilemapManager.PlantSeed(pointerCellPosition);
            }

            tilemap.SetTile(pointerCellPosition, newSeedTile);
        }
    }

    private void CheckPointerPosition()
    {
        rawPointerPosition = selectAction.ReadValue<Vector2>();
        pointerPosition = Camera.main.ScreenToWorldPoint(rawPointerPosition);
        pointerCellPosition = gridLayout.WorldToCell(pointerPosition);
        Vector3Int cameraOffset = new Vector3Int(0, 0, (int) Camera.main.transform.position.z);
        pointerCellPosition -= cameraOffset;
    }

    private void CheckIfCellIsSelected()
    {
        if (tilemap.HasTile(pointerCellPosition))
        {
            if (pointerCellPosition != previousSelectedCellPosition)
            {
                selectedTile = tilemap.GetTile(pointerCellPosition);
                tilemap.SetTileFlags(pointerCellPosition, TileFlags.None);
                tilemap.SetColor(pointerCellPosition, Color.red);
                tilemap.SetColor(previousSelectedCellPosition, Color.white);
                previousSelectedCellPosition = pointerCellPosition;
            }

            // cellIsSelected = true;
        }
        else
        {
            // cellIsSelected = false;

            tilemap.SetColor(previousSelectedCellPosition, Color.white);
            previousSelectedCellPosition = pointerCellPosition;
        }
    }


}
