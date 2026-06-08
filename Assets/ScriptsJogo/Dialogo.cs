using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    public GameObject fadeOutAnimacao;
    public GameObject fadeInAnimacao;
    public GameObject quarto;
    public GameObject cozinha;
    public GameObject corredor;
    public GameObject caixaDialogo;
    public GameObject background;
    private bool introducaoFeita = false;
    private bool transicaoAcontecendo;
    void Start()
    {
        caixaDialogo.SetActive(false);
        textComponent.text = string.Empty;
        fadeOutAnimacao.SetActive(false);
        fadeInAnimacao.SetActive(false);
        quarto.SetActive(false);
    }

void Update()
{
    if (transicaoAcontecendo == true)
    {
        return;
    }
    if (Input.GetMouseButtonDown(0))
    {
        if (!caixaDialogo.activeSelf)
        {
            caixaDialogo.SetActive(true);
            StartDialogue();
            return;
        }
        if (textComponent.text == lines[index])
        {
            if (!introducaoFeita && index == 0)
            {
                introducaoFeita = true;
                StartCoroutine(Introdução());
            }
            else if (index == 3)
            {
                StartCoroutine(TransicaoCena(quarto, cozinha));
            }
            else if (index == 10)
            {
                StartCoroutine(TransicaoCena(cozinha, corredor));
            }
            else
            {
                NextLine();
            }
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }
}
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine() // transforma as frases em caracteres para que tenha o efeito de ir de letra por letra dentro do dialogo.
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    IEnumerator Introdução() // Corrotina para o inicio de tela preta.
    {
        transicaoAcontecendo = true;
        quarto.SetActive(true);
        background.SetActive(false);
        fadeOutAnimacao.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        NextLine();
        transicaoAcontecendo = false;
        fadeOutAnimacao.SetActive(false);
    }

    void NextLine() // função feita para ir para a próxima linha
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    IEnumerator TransicaoCena(GameObject cenarioAtual, GameObject novoCenario) // corrotina usada sempre que for mudar de um cenário para o outro
    {
    caixaDialogo.SetActive(false);
    transicaoAcontecendo = true;
    fadeInAnimacao.SetActive(true);
    yield return new WaitForSeconds(2.5f);
    Debug.Log("Cenário ta mudando");
    cenarioAtual.SetActive(false);
    novoCenario.SetActive(true);
    fadeOutAnimacao.SetActive(true);
    fadeInAnimacao.SetActive(false);
    yield return new WaitForSeconds(2.5f);
    NextLine();
    transicaoAcontecendo = false;
    fadeInAnimacao.SetActive(false);
    fadeOutAnimacao.SetActive(false);
    caixaDialogo.SetActive(true);
    }
}