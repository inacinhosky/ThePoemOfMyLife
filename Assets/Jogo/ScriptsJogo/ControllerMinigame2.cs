using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ControllerMinigame2 : MonoBehaviour
{
     [Header("Interface")]
    public GameObject escolhasMinigame2;
    public TextMeshProUGUI textoPensamento;
    public Button botaoEsquerda;
    public Button botaoDireita;

    [Header("Textos dos botoes")]
    public TextMeshProUGUI textoBotaoEsquerda;
    public TextMeshProUGUI textoBotaoDireita;

    [Header("Tentativas")]
    [SerializeField]private int errosMaximos = 2;
    private int erros = 0;

    private int perguntaAtual = 0;

    private string[] perguntas =
    {
        "Como posso ajudar a Aurora?",
        "Além disso....",
        "E se a julgarem?"
        
    };

    private string[] resposta1 =
    {
        "As pessoas vivem errando, e sempre aprendem com os erros, eu sinto que você deveria ir e pelo menos tentar.",
        "É uma ótima oportunidade, seus poemas são tão lindos, sério.",
        "Se você se importa tanto com as opiniões dos outros, não vai a lugar nenhum desse jeito"
    };

    private string[] resposta2 =
    {
        "Bem se você tem tanto medo assim, talvez não se forçar seja uma boa.",
        "Se sua casa é mais confortável... você deveria ficar então.",
        "E mesmo que você for julgada, a maioria desse julgamento vão ser críticas que te fazem melhorar, e se você se sentir mal ou triste, você sempre com as pessoas que te amam."
    };

    private int[] respostaCorreta = { 0, 0, 1};

    void Start()
    {
        escolhasMinigame2.SetActive(false);

        botaoEsquerda.onClick.AddListener(() => EscolherResposta(0));
        botaoDireita.onClick.AddListener(() => EscolherResposta(1));
    }

    public void IniciarMinigame()
    {
        Object.FindFirstObjectByType<Dialogo>().marisa.enabled = false;
        erros = 0;
        perguntaAtual = 0;

        escolhasMinigame2.SetActive(true);
        MostrarPergunta();
    }

    void MostrarPergunta()
    {
        textoPensamento.text = perguntas[perguntaAtual];

        textoBotaoEsquerda.text = resposta1[perguntaAtual];
        textoBotaoDireita.text = resposta2[perguntaAtual];
    }

    void EscolherResposta(int escolha)
    {
        if (escolha != respostaCorreta[perguntaAtual])
        {
            erros++;

            if (erros >= errosMaximos)
            {
                GameOverMinigame();
                return;
            }
        }

        perguntaAtual++;

        if (perguntaAtual >= perguntas.Length)
        {
            Vitoria();
            return;
        }

        MostrarPergunta();
    }

    void GameOverMinigame()
    {
        escolhasMinigame2.SetActive(false);
        
        Debug.Log("Game Over");
        Timer.GameOver();
    }

    void Vitoria()
    {
        escolhasMinigame2.SetActive(false);
        Debug.Log("GG");
        Object.FindFirstObjectByType<Dialogo>().continuarDialogo();
    }
}
