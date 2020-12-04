using UnityEngine;


public class FinishLevel : MonoBehaviour
{
    #region Fields    

    [SerializeField] private AudioSource winMusic;
    [SerializeField] private AudioSource stopMusic;

    #endregion


    #region UnityMethod

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            winMusic.Play();
            stopMusic.Stop();
            MyUIController.instance.GameStatus("YOU WIN");
        }
    }

    #endregion
}
