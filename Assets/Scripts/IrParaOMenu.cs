using UnityEngine;
using UnityEngine.SceneManagement;
public class IrParaOMenu : MonoBehaviour
{

    public void menu()
    {
        SceneManager.LoadSceneAsync("menu");
    }

}
