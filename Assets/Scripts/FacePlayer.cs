using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDirection = player.position - transform.position;
        playerDirection.y = 0; // Keep the sprite upright
        transform.forward = playerDirection;
    }
}
