using UnityEngine;

public class PositionCamera : MonoBehaviour
{
    [SerializeField] private Transform headPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = headPos.position;
    }
}
