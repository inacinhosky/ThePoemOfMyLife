using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI personagemFalandoComponent;
    public string[] lines;
    public string[] personagemFalando;
    public float textSpeed;
    private int index;
    private int indexPersonagem;
    public GameObject fadeOutAnimacao;
    public GameObject fadeInAnimacao;
    public GameObject quarto;
    public GameObject cozinha;
    public GameObject corredor;
    public GameObject salaAtras;
    public GameObject salaFrente;
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
        personagemFalandoComponent.text = string.Empty;
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
                StartCoroutine(TransicaoCena(quarto, cozinha, true));

            }
            else if (index == 10)
            {
                StartCoroutine(TransicaoCena(cozinha, corredor, true));

            }
            else if (index == 28)
            {
                StartCoroutine(TransicaoCena(corredor, salaAtras, true));

            }
            else if (index == 41) 
            {
                StartCoroutine(TransicaoCena(salaAtras, salaFrente, false));
                
                enabled = false;
            }
            else if (index == 43) // lembrar de botar o som de palmas nesses 3 pontinhos. 
            {
                enabled = true;
                StartCoroutine(TransicaoCena(salaFrente, salaAtras, true));
            }
            else
            {
                NextLine();
                NextLinePersonagemFalando();
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
        indexPersonagem = 0;
        StartCoroutine(TypeLine());
        StartCoroutine(TypeLine2());
    }
    IEnumerator TypeLine() // transforma as frases em caracteres para que tenha o efeito de ir de letra por letra dentro do dialogo.
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
        IEnumerator TypeLine2() // transforma as frases em caracteres para que tenha o efeito de ir de letra por letra dentro do dialogo.
    {
        foreach (char c in personagemFalando[indexPersonagem].ToCharArray())
        {
            personagemFalandoComponent.text += c;
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
        NextLinePersonagemFalando();
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
        void NextLinePersonagemFalando() // função feita para ir para a próxima linha
    {
        if (indexPersonagem < personagemFalando.Length - 1)
        {
            indexPersonagem++;
            personagemFalandoComponent.text = string.Empty;
            StartCoroutine(TypeLine2());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
IEnumerator TransicaoCena(GameObject cenarioAtual, GameObject novoCenario, bool mostrarDialogoDepois)
{
    caixaDialogo.SetActive(false);

    transicaoAcontecendo = true;
    fadeInAnimacao.SetActive(true);

    yield return new WaitForSeconds(2.5f);

    cenarioAtual.SetActive(false);
    novoCenario.SetActive(true);

    fadeOutAnimacao.SetActive(true);
    fadeInAnimacao.SetActive(false);

    yield return new WaitForSeconds(2.5f);

    NextLine();
    NextLinePersonagemFalando();

    transicaoAcontecendo = false;
    fadeInAnimacao.SetActive(false);
    fadeOutAnimacao.SetActive(false);

    if (mostrarDialogoDepois)
    {
        caixaDialogo.SetActive(true);
    }
}
    public void continuarDialogo()
    {
        caixaDialogo.SetActive(true);
        enabled = true;
        NextLine();
    }
}