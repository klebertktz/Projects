
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float intervalo = 3f;
    public float intervaloMinimo = 1f;

    public float velocidadeInicial = 2f;
    public float aumentoVelocidade = 0.4f;

    public float tempoParaAumentar = 15f;

    private float contador = 0f;
    private float tempoDecorrido = 0f;

    private int nivelDificuldade = 0;

    void Update()
    {
        tempoDecorrido += Time.deltaTime;
        contador += Time.deltaTime;

        nivelDificuldade = Mathf.FloorToInt(
            tempoDecorrido / tempoParaAumentar
        );

        float intervaloAtual = Mathf.Max(
            intervaloMinimo,
            intervalo - nivelDificuldade * 0.3f
        );

        if (contador >= intervaloAtual)
        {
            SpawnEnemy();

            contador = 0f;
        }
    }

    void SpawnEnemy()
    {
        float x = 0f;
        float y = 0f;

        int lado = Random.Range(0, 4);

        if (lado == 0)
        {
            x = -7f;
            y = Random.Range(-4f, 4f);
        }
        else if (lado == 1)
        {
            x = 7f;
            y = Random.Range(-4f, 4f);
        }
        else if (lado == 2)
        {
            x = Random.Range(-7f, 7f);
            y = 4f;
        }
        else
        {
            x = Random.Range(-7f, 7f);
            y = -4f;
        }

        Vector3 posicao = new Vector3(x, y, 0f);

        GameObject novoInimigo = Instantiate(
            enemyPrefab,
            posicao,
            Quaternion.identity
        );

        EnemyFollow inimigo = novoInimigo.GetComponent<EnemyFollow>();

        if (inimigo != null)
        {
            inimigo.speed = velocidadeInicial +
                nivelDificuldade * aumentoVelocidade;
        }
    }
}
