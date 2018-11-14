using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;

    private void Update()
    {
        if (player.position.x > transform.position.x) {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        if (player.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
