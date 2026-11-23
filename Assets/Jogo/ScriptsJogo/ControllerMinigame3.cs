using UnityEngine;

public class ControllerMinigame3 : MonoBehaviour
{
    public string[] frases;
    private string[] palavrasEmbaralhadas;

    private string[] palavrasCorreta;
    private int indexFraseAtual = 0;
    void Start()
    {
        palavrasEmbaralhadas = frases[indexFraseAtual].Split(' ');
        palavrasCorreta = palavrasEmbaralhadas;
        for (int i = 0; i < palavrasEmbaralhadas.Length; i++)
        {
            string temporaria;
            temporaria = palavrasEmbaralhadas[Random.Range(0, palavrasEmbaralhadas.Length)];
            int posicaoAleatoria = Random.Range(0, palavrasEmbaralhadas.Length);
            palavrasEmbaralhadas[posicaoAleatoria] = temporaria;
        }
    }
    void Update()
    {
        
    }
}
