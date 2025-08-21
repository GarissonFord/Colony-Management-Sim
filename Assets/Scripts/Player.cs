using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    InputAction moveAction;

    [SerializeField] private float moveSpeed;
    [SerializeField] Tilemap groundTileMap;
    Tile targetTile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);
        Debug.DrawRay(transform.position, moveVector, Color.green, 1.0f);
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, moveVector, 1.0f);
        Debug.Log("raycastHit2D: " + raycastHit2D.centroid);
        // targetTile = groundTileMap.GetTile(raycastHit2D.centroid);
    }
}
