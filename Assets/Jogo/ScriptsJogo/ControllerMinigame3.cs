using TMPro;
using UnityEngine;

public class ControllerMinigame3 : MonoBehaviour
{
    public string[] frases;
    private string[] palavrasEmbaralhadas;

    private string[] palavrasCorreta;
    private int indexFraseAtual = 0;
    public GameObject botaoPalavraPrefab;
    public Transform areaPalavras;
    public Transform areaFrase;
    void Start()
    {
        palavrasCorreta = frases[indexFraseAtual].Split(' ');
        palavrasEmbaralhadas = (string[])palavrasCorreta.Clone();
        for (int i = 0; i < palavrasEmbaralhadas.Length; i++)
        {
            string temporaria;
            temporaria = palavrasEmbaralhadas[i];
            int posicaoAleatoria = Random.Range(0, palavrasEmbaralhadas.Length);
            palavrasEmbaralhadas[i] = palavrasEmbaralhadas[posicaoAleatoria];
            palavrasEmbaralhadas[posicaoAleatoria] = temporaria;
        }
        for (int i = 0; i < palavrasEmbaralhadas.Length; i++)
        {
            GameObject botoes = Instantiate(botaoPalavraPrefab, areaPalavras, false);
            botoes.GetComponentInChildren<TextMeshProUGUI>().text = palavrasEmbaralhadas[i];
        }
    }
    void Update()
    {
        
    }
}
