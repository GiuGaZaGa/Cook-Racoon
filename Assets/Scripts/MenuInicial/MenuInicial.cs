using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{

    public void CarregarCena(string MenuInicial)
    {
        SceneManager.LoadScene(MenuInicial);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
