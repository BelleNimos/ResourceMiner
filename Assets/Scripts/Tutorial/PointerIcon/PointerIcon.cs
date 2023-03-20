using UnityEngine;
using UnityEngine.UI;

public abstract class PointerIcon : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void SetIconPosition(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
    }
}
