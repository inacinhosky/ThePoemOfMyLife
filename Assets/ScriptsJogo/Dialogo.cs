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
    public GameObject quarto;
    public GameObject background;
    private bool introducaoFeita = false;
    private bool transicaoAcontecendo;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
        fadeOutAnimacao.SetActive(false);
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
        if (textComponent.text == lines[index])
        {
            if (!introducaoFeita && index == 0)
            {
                introducaoFeita = true;
                StartCoroutine(Introdução());
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

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    IEnumerator Introdução()
    {
        transicaoAcontecendo = true;
        quarto.SetActive(true);
        background.SetActive(false);
        fadeOutAnimacao.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        NextLine();
        transicaoAcontecendo = false;
    }

    void NextLine()
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
}