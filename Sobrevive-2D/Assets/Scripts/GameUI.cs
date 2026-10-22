using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public PlayerHealth  playerHealth;

    public TMP_Text TextLife;
    public TMP_Text TextTime;
    public TMP_Text TextPoints;
    public TMP_Text TextGameOver;

    private float time = 0f;
    private int points = 0;

    void Start()
    {
        TextGameOver.gameObject.SetActive(false);
    }

    void Update()
    {
        TextLife.text = "Vidas: " + playerHealth.life;

        if (playerHealth.life > 0)
        {
            time += Time.deltaTime;

            points = Mathf.FloorToInt(time * 10f);
        }
        else
        {
            TextGameOver.gameObject.SetActive(true);
        }

        TextTime.text = "Tempo: " + time.ToString("F1") + "s";
        TextPoints.text = "Pontos: " + points;
    }

}
