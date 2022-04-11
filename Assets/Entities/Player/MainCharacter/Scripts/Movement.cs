using UnityEngine;

public class Movement : MonoBehaviour
{ 
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float gravity = -0.981f;
    [SerializeField] private float jumpStrength = 10f;
    
    private CharacterController _controller;
    
    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");
        var jumpInput = Input.GetAxisRaw("Jump") * jumpStrength;

        var moveVector = new Vector3(horizontalInput, jumpInput + gravity, verticalInput) * Time.deltaTime * moveSpeed;
        _controller.Move(moveVector);
    }
}
