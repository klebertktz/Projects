
using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int life = 3;

    private bool invuneravel = false;

    private SpriteRenderer sprite;
    private Color corOriginal;

    public AudioClip somDano;
    private AudioSource audioSource;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        corOriginal = sprite.color;

        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Enemy"))
        {
            EnemyDeath enemyDeath = outro.GetComponent<EnemyDeath>();

            if (enemyDeath != null)
            {
                enemyDeath.DestruirInimigo();
            }
            else
            {
                Destroy(outro.gameObject);
            }

            if (invuneravel || life <= 0)
            {
                return;
            }

            life--;

            Debug.Log("Vidas restantes: " + life);

            // Reproduzir o som de dano
            if (somDano != null && audioSource != null)
            {
                audioSource.PlayOneShot(somDano);
                Debug.Log("SOM DE DANO EXECUTADO!");
            }
            else
            {
                Debug.LogWarning("SOM OU AUDIO SOURCE NÃO CONFIGURADO!");
            }

            if (life <= 0)
            {
                Debug.Log("GAME OVER!");

                Time.timeScale = 0f;
            }
            else
            {
                invuneravel = true;

                StartCoroutine(EfeitoDano());
            }
        }
    }

    IEnumerator EfeitoDano()
    {
        for (int i = 0; i < 4; i++)
        {
            sprite.color = Color.red;

            yield return new WaitForSeconds(0.15f);

            sprite.color = corOriginal;

            yield return new WaitForSeconds(0.15f);
        }

        invuneravel = false;
    }
}
