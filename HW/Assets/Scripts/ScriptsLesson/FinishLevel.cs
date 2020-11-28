using UnityEngine;


public class FinishLevel : MonoBehaviour
{
    #region Fields    
    #endregion


    #region UnityMethod

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MyUIController.instance.GameStatus("YOU WIN");
        }
    }

    #endregion
}
