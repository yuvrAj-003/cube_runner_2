using UnityEngine;

public class obstacle : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
