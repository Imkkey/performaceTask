using UnityEngine;

public class BgParalax : MonoBehaviour
{
    public float fallSpeed = 2f;


    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }
}
