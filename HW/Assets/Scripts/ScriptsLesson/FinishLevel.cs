using UnityEngine;


public class FinishLevel : MonoBehaviour
{
    #region Fields

    [SerializeField] InformationPanel informationPanel;

    #endregion


    #region UnityMethod

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            informationPanel.Information("YOU WIN");
        }
    }

    #endregion
}
