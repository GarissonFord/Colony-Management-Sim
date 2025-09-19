using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float cameraZPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPlayerPosition = player.transform.position;
        Vector3 newPosition = new Vector3(currentPlayerPosition.x, currentPlayerPosition.y, cameraZPosition);
        transform.position = newPosition;
    }
}
