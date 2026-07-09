using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; // Arrasta o Character Controller aqui
    public float speed = 12f; // Velocidade do movimento

    void Update()
    {
        // Pega as teclas de movimento (W, A, S, D ou Setas)
        float x = Input.GetAxis("Horizontal"); // A/D
        float z = Input.GetAxis("Vertical");   // W/S

        // CRUCIAL: Cria o vetor de movimento baseado para onde o Player está olhando
        // transform.right é a "direita" do jogador, transform.forward é a "frente" do jogador
        Vector3 move = transform.right * x + transform.forward * z;

        // Move o personagem usando o Character Controller
        controller.Move(move * speed * Time.deltaTime);
    }
}
