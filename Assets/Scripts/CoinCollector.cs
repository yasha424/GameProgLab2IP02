using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinCollector : MonoBehaviour
{
    private int coinsNum = 0;
    [SerializeField] GameObject door;

    private void Start()
    {
        door.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            coinsNum++;
            Destroy(other.gameObject);
            if (coinsNum == 5)
            {
                door.SetActive(true);
            }
        }
        else if (other.tag == "Door")
        {
            SceneManager.LoadScene("SecondScene");
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 50, 250, 30), "Coins collected: " + coinsNum.ToString() + " (Objective: 5)");
    }

}
