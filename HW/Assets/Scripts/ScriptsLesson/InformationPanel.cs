using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InformationPanel : MonoBehaviour
{
    #region Fields

    [SerializeField] Text informationText;

    #endregion
    

    #region Methods

    public void Information(string text)
    {
        gameObject.SetActive(true);
        informationText.text = text;
    }

    public void LoadLevelButton(string namelevel)
    {
        SceneManager.LoadScene(namelevel);
    }

    #endregion
}
