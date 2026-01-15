using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [SerializeField] private GameObject Rainy;
    [SerializeField] private GameObject Light;
    [SerializeField] private GameManager gameManager;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.score >= 5)
        {
            Rainy.SetActive(true);
            Light.SetActive(false);
        }
    }
}
