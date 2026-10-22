using UnityEngine;

public class PlayerMovemet : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float horizontal = 0;
        float vertical = 0;

    if (Input.GetKey(KeyCode.A))
    {
        horizontal = -1;
    }

    if (Input.GetKey(KeyCode.D))
    {
        horizontal = 1;
    }

    if (Input.GetKey(KeyCode.W))
    {
        vertical = 1;
    }

    if (Input.GetKey(KeyCode.S))
    {
        vertical = -1;
    }


    Vector3 movement = new Vector3(horizontal, vertical, 0);

    transform.position += movement.normalized * speed * Time.deltaTime;

    }

}
