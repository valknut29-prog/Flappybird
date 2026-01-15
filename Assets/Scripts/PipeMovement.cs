using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 1f;
    public float destroyX = -50f;
    public float minY = -1.5f;
    public float maxY = 1.5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomY = Random.Range(minY, maxY);
        transform.position = new Vector3(
            transform.position.x,
            randomY,
            transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
