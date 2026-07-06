using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TMP_Text _timerTxt;
    public float timer = 10;

    void Start()
    {
         _timerTxt = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
                    timer -= Time.deltaTime;
            _timerTxt.text = timer.ToString("N0");

            if (timer <= 0)
            {
                timer = 0;
                print("Tempo esgotado!");
                GameOver();
            }
    }
    public static void GameOver() // mudar para a cena de game over depois.
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}
