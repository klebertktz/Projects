
using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour
{
    public float duracao = 0.25f;

    private bool destruindo = false;

    public void DestruirInimigo()
    {
        if (destruindo)
        {
            return;
        }

        destruindo = true;

        // Desativa a colisão
        Collider2D colisao = GetComponent<Collider2D>();

        if (colisao != null)
        {
            colisao.enabled = false;
        }

        // Impede o inimigo de continuar perseguindo
        EnemyFollow inimigo = GetComponent<EnemyFollow>();

        if (inimigo != null)
        {
            inimigo.enabled = false;
        }

        StartCoroutine(AnimacaoMorte());
    }

    IEnumerator AnimacaoMorte()
    {
        Vector3 tamanhoOriginal = transform.localScale;
        float tempo = 0f;

        while (tempo < duracao)
        {
            tempo += Time.unscaledDeltaTime;

            float progresso = tempo / duracao;

            transform.localScale = Vector3.Lerp(
                tamanhoOriginal,
                Vector3.zero,
                progresso
            );

            yield return null;
        }

        Destroy(gameObject);
    }
}
