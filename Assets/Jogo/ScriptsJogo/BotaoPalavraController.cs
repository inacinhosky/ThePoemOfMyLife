using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BotaoPalavraController : MonoBehaviour
{
    private string palavra;
    private ControllerMinigame3 controller;

    public void Configurar(string palavraRecebida, ControllerMinigame3 controlador)
    {
        palavra = palavraRecebida;
        controller = controlador;

        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(Clicar);
    }

    void Clicar()
    {
        controller.VerificarPalavra(palavra, gameObject);
    }
}