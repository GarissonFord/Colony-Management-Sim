using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class TileSelector : MonoBehaviour
{
    InputAction lookAction;
    InputAction selectAction;

    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase selectedTile;
    [SerializeField] private Vector2 rawPointerPosition;
    [SerializeField] private Vector3 pointerPosition;
    [SerializeField] private Vector3Int pointerCellPosition;
    private Vector3Int previousSelectedCellPosition;
    [SerializeField] private bool cellIsSelected;

    GridLayout gridLayout;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        previousSelectedCellPosition = new Vector3Int(0, 0, 0);
        gridLayout = transform.parent.GetComponentInParent<GridLayout>();
        lookAction = InputSystem.actions.FindAction("Look");
        selectAction = InputSystem.actions.FindAction("Select");
        CheckIfCellIsSelected();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPointerPosition();
        CheckIfCellIsSelected();
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

            cellIsSelected = true;
        }
        else
        {
            cellIsSelected = false;

            tilemap.SetColor(previousSelectedCellPosition, Color.white);
            previousSelectedCellPosition = pointerCellPosition;
        }
    }
}
