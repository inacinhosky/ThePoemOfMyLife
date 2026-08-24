using System.Collections;
using UnityEngine;
using TMPro;
using System;
using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting;
using UnityEngine.UI;
using Unity.UI;

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
    [SerializeField]private AudioClip vozAtual;
    public AudioSource audioSource;
    public AudioClip vozMae;
    public AudioClip vozAurora;
    public AudioClip vozMarisa;
    public Image aurora;

    
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
    switch (personagemFalando[indexPersonagem])
    {
        case "AURORA":
            vozAtual = vozAurora;
            break;
        case "MÃE":
            vozAtual = vozMae;
            break;
        case "MARISA":
            vozAtual = vozMarisa;
            break;
    }
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
                

            }
            else if (index == 44) // lembrar de botar o som de palmas nesses 3 pontinhos. 
            {

                StartCoroutine(TransicaoCena(salaFrente, salaAtras, true));
            }
            else if (index == 51)
            {
                StartCoroutine(TransicaoCena(salaAtras, cozinha, true));
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
        DestacarPersonagem(personagemFalando[indexPersonagem]);
        StartCoroutine(TypeLine());
        StartCoroutine(TypeLine2());
    }
    void DestacarPersonagem(string personagem)
{
    aurora.color = Color.gray;

    if (personagem == "AURORA")
    {
        aurora.color = Color.white;
    }
}
    IEnumerator TypeLine() // transforma as frases em caracteres para que tenha o efeito de ir de letra por letra dentro do dialogo.
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            if (char.IsLetter(c))
            {
            audioSource.PlayOneShot(vozAtual);
            }
            yield return new WaitForSeconds(textSpeed);
            
        }
    }
        IEnumerator TypeLine2()
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
            DestacarPersonagem(personagemFalando[indexPersonagem]);
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