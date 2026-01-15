using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
   [SerializeField] public GameObject birdPrefab;

   [SerializeField] public float spawnRate=1f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnBird),1f,spawnRate);
    }
    
    void SpawnBird()
    {
        Vector3 spawnPos = new Vector3(
            transform.position.x + Random.Range(0f,5f),
            Random.Range(-5f, 5f),
            0f
        );

        Instantiate(birdPrefab, spawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}