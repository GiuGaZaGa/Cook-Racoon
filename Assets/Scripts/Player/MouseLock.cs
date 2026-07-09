using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        // Trava o cursor
        Cursor.lockState = CursorLockMode.Locked;

        // Zera e força o alinhamento inicial absoluto para evitar o bug de olhar para o chão
        transform.localRotation = Quaternion.identity;
        if (playerBody != null)
        {
            playerBody.localRotation = Quaternion.identity;
        }

        xRotation = 0f;
        yRotation = 0f;
    }

    void Update()
    {
        // Se esqueceu de arrastar o Player Body no Inspector, avisa no console
        if (playerBody == null)
        {
            Debug.LogError("Por favor, arraste o objeto PLAYER para o campo Player Body no Inspector da Câmera!");
            return;
        }

        // Captura o input do mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Calcula as rotações acumuladas de forma independente
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f); // Limita o olhar vertical

        yRotation += mouseX; // Acumula o olhar horizontal

        // Aplica diretamente as rotações para evitar que a física da Unity interfira
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Câmera olha para cima/baixo
        playerBody.localRotation = Quaternion.Euler(0f, yRotation, 0f); // Player gira para os lados
    }
}
