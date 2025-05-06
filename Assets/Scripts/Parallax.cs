using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform Target;
    public float MoveSpeed;

    private Vector3 _parallaxStartPosition;
    private float _targetStartX;

    void Start()
    {
        _parallaxStartPosition = transform.position;
        _targetStartX = Target.position.x;
    }

    void Update()
    {
        float offsetX = (Target.position.x - _targetStartX) * MoveSpeed;
        
        transform.position = new Vector3(
            _parallaxStartPosition.x + offsetX,
            _parallaxStartPosition.y,
            _parallaxStartPosition.z
        );
    }
}