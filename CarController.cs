using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 100f;
    public float fixedHeight = 0.5f; // Stała wysokość pojazdu nad płaszczyzną, dostosuj do wysokości bloku

    private Vector2 moveInput;
    private float rotateInput;

    private CarInputActions carInputActions;
    private Rigidbody rb;

    void Awake()
    {
        carInputActions = new CarInputActions();
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        carInputActions.CarControls.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        carInputActions.CarControls.Move.canceled += ctx => moveInput = Vector2.zero;

        carInputActions.CarControls.Rotate.performed += ctx => rotateInput = ctx.ReadValue<float>();
        carInputActions.CarControls.Rotate.canceled += ctx => rotateInput = 0f;

        carInputActions.Enable();
    }

    void OnDisable()
    {
        carInputActions.Disable();
    }

    void FixedUpdate()
    {
        // Oblicz ruch
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed * Time.fixedDeltaTime;
        Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);
        newPosition.y = fixedHeight; // Ustaw stałą wysokość

        // Zaktualizuj pozycję
        rb.MovePosition(newPosition);

        // Oblicz rotację
        float rotation = rotateInput * rotateSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, rotation, 0f);

        // Zaktualizuj rotację
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
        }
    }
}