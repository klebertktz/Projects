using UnityEngine;
public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    void Start()
    {
        GameObject jogador = GameObject.FindGameObjectWithTag("Player");

        if (jogador != null)
        {
            player = jogador.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
        }
    }

}