using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float fallSpeed = 2f;

    public float destroyTime = 5f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }
}
