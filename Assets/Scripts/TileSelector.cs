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
    [SerializeField] private bool cellIsSelected;

    GridLayout gridLayout;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gridLayout = transform.parent.GetComponentInParent<GridLayout>();
        lookAction = InputSystem.actions.FindAction("Look");
        selectAction = InputSystem.actions.FindAction("Select");
        CheckIfCellIsSelected();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPointerPosition();
        // selectedTile = tilemap.GetTile(new Vector3Int(pointerPosition.x, pointerPosition.y, 0.0f));
        CheckIfCellIsSelected();
    }

    private void CheckPointerPosition()
    {
        // rawPointerPosition = lookAction.ReadValue<Vector2>();
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
            selectedTile = tilemap.GetTile(pointerCellPosition);
            tilemap.SetColor(pointerCellPosition, Color.yellow);
            cellIsSelected = true;
        }
        else
        {
            cellIsSelected = false;
        }
    }
}
