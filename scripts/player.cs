using UnityEngine;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour
{
    private Vector3 prevMousePos;
    private bool dragging = false;
    public float sensitivity = 0.01f; // Tune as needed

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            prevMousePos = Input.mousePosition;
            dragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }

        if (dragging)
        {
            Vector3 delta = Input.mousePosition - prevMousePos;
            float moveX = delta.x * sensitivity;
            Vector3 newPosition = transform.position + new Vector3(moveX, 0f, 0f);

            // Clamp X position between -0.80 and 0.80
            newPosition.x = Mathf.Clamp(newPosition.x, -0.80f, 0.80f);

            transform.position = newPosition;
            prevMousePos = Input.mousePosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
