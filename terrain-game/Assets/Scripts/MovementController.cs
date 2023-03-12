using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private InputAction baloonMovement;
    [SerializeField] private float baloonSpeed = 10f;
    [SerializeField] private float xRange;
    [SerializeField] private float yRange;
 
    private Vector3 _newPosition;

    private float _horizontalThrow;
    private float _verticalThrow;

    private void OnEnable()
    {
        baloonMovement.Enable();
    }

    private void OnDisable()
    {
        baloonMovement.Disable();
    }

    private void Update()
    {
        ProcessThrow();
    }

    private void ProcessThrow()
    {
        _horizontalThrow = baloonMovement.ReadValue<Vector2>().x;
        _verticalThrow = baloonMovement.ReadValue<Vector2>().y;

        var localPosition = transform.localPosition;
        _newPosition.x = Mathf.Clamp(localPosition.x + _horizontalThrow * Time.deltaTime * baloonSpeed, -xRange, xRange);
        _newPosition.y = Mathf.Clamp(localPosition.y + _verticalThrow * Time.deltaTime * baloonSpeed, -yRange, yRange);

        localPosition = _newPosition;
        transform.localPosition = localPosition;
    }
}
