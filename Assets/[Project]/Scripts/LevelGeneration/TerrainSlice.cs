using UnityEngine;

public class TerrainSlice : MonoBehaviour
{
    private float _startY;

    private void Start()
    {
        _startY = transform.position.y;
    }

    public void UpdatePosition(float time)
    {
        transform.position = new Vector3(transform.position.x
                                        , Mathf.Lerp(_startY, 0, time)
                                        , transform.position.z);
    }
}