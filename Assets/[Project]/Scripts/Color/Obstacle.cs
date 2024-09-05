using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    private ColorState _colorState;

    void Start()
    {
        _colorState = GetComponent<ColorState>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        ColorState otherColor = other.collider.GetComponent<ColorState>();
        if (!otherColor) return;
        if (other.collider.tag == "Player" && !_colorState.IsSameColor(otherColor.CurrentColor))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        ColorState otherColor = other.GetComponent<ColorState>();
        if (!otherColor) return;
        if (other.tag == "Player" && !_colorState.IsSameColor(otherColor.CurrentColor))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
