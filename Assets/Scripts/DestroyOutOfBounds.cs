using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    [SerializeField] private float topBound = 30.0f;
    [SerializeField] private float lowerBound = -10.0f;
    [SerializeField] private float leftBound = -30.0f;
    [SerializeField] private float rightBound = 30.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound || transform.position.z < lowerBound ||
            transform.position.x < leftBound || transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
    }
}
