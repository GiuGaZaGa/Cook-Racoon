using UnityEngine;

public class MovPlayer : MonoBehaviour
{

    public float veloPlayer = 5f;

    private Rigidbody rb;

    private float horizontalAxis;

    private float verticalAxis;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        if (horizontalAxis != 0 || verticalAxis != 0)
        {
            rb.linearVelocity = new Vector3(veloPlayer * horizontalAxis, 0f, veloPlayer * verticalAxis);
        }
        
    }
}
