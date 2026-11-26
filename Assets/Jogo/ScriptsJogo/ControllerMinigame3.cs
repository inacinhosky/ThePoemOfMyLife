using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ControllerMinigame3 : MonoBehaviour
{
    public string[] frases;
    public Dialogo dialogo;
    public GameObject controllerMinigame3Objeto;

    public GameObject botaoPalavraPrefab;
    public Transform areaPalavras;
    public Transform areaFrase;

    private string[] palavrasEmbaralhadas;
    private string[] palavrasCorreta;

    private int indexFraseAtual = 0;
    private int indexPalavraAtual = 0;

    public void IniciarMinigame()
    {
    indexFraseAtual = 0;
    indexPalavraAtual = 0;
    CarregarFrase();
    }

    void CarregarFrase()
    {
        palavrasCorreta = frases[indexFraseAtual].Split(' ');
        palavrasEmbaralhadas = (string[])palavrasCorreta.Clone();

        for (int i = palavrasEmbaralhadas.Length - 1; i > 0; i--)
        {
            int posicaoAleatoria = Random.Range(0, i + 1);

            string temporaria = palavrasEmbaralhadas[i];
            palavrasEmbaralhadas[i] = palavrasEmbaralhadas[posicaoAleatoria];
            palavrasEmbaralhadas[posicaoAleatoria] = temporaria;
        }

        CriarBotoes();
    }

    void CriarBotoes()
    {
        for (int i = 0; i < palavrasEmbaralhadas.Length; i++)
        {
            GameObject botao = Instantiate(botaoPalavraPrefab, areaPalavras, false);

            botao.GetComponentInChildren<TextMeshProUGUI>().text = palavrasEmbaralhadas[i];

            botao.GetComponent<BotaoPalavraController>().Configurar(
                palavrasEmbaralhadas[i], this
            );
        }
    }

    public void VerificarPalavra(string palavra, GameObject botao)
    {
        if (palavra == palavrasCorreta[indexPalavraAtual])
        {
    GameObject novoBotao = Instantiate(botaoPalavraPrefab, areaFrase, false);

    TextMeshProUGUI texto = novoBotao.GetComponentInChildren<TextMeshProUGUI>();
    texto.text = palavra;

    LayoutElement layout = novoBotao.GetComponent<LayoutElement>();

    if (layout == null)
    {
        layout = novoBotao.AddComponent<LayoutElement>();
    }

    layout.preferredWidth = texto.preferredWidth + 30;
    layout.preferredHeight = 50;

            Destroy(botao);

            indexPalavraAtual++;

            if (indexPalavraAtual >= palavrasCorreta.Length)
            {
                ProximaFrase();
            }
        }
        else
        {
            ReiniciarFrase();
        }
    }

    void ReiniciarFrase()
    {
        indexPalavraAtual = 0;

        foreach (Transform filho in areaPalavras)
        {
            Destroy(filho.gameObject);
        }

        foreach (Transform filho in areaFrase)
        {
            Destroy(filho.gameObject);
        }

        CriarBotoes();
    }

    void ProximaFrase()
    {
        indexFraseAtual++;

        if (indexFraseAtual >= frases.Length)
        {
            Debug.Log("Minigame concluído!");
            dialogo.continuarDialogo();
            controllerMinigame3Objeto.SetActive(false);
            return;
        }

        indexPalavraAtual = 0;

        foreach (Transform filho in areaPalavras)
        {
            Destroy(filho.gameObject);
        }

        foreach (Transform filho in areaFrase)
        {
            Destroy(filho.gameObject);
        }

        CarregarFrase();
    }
}