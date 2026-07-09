using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    [Header("Configurações de Grab")]
    public Transform grabPoint;   // Arraste o objeto GrabPoint aqui
    public float grabDistance = 4f; // Distância máxima para alcançar um item
    public LayerMask grabLayer;   // Camada dos objetos que podem ser pegos

    private GameObject grabbedObject; // Guarda o objeto que está segurando
    private Rigidbody grabbedRb;       // Guarda o Rigidbody do objeto

    void Update()
    {
        // Se apertar o botão esquerdo do mouse (ou E, se preferir mudar para KeyCode.E)
        if (Input.GetMouseButtonDown(0))
        {
            if (grabbedObject == null)
            {
                TryGrabObject();
            }
            else
            {
                DropObject();
            }
        }

        // Se estiver segurando algo, mantém o objeto na posição do GrabPoint
        if (grabbedObject != null)
        {
            MoveObject();
        }
    }

    void TryGrabObject()
    {
        RaycastHit hit;
        // Lança um raio invisível bem no centro da câmera para frente
        if (Physics.Raycast(transform.position, transform.forward, out hit, grabDistance, grabLayer))
        {
            // Verifica se o objeto tem física (Rigidbody)
            if (hit.collider.GetComponent<Rigidbody>() != null)
            {
                grabbedObject = hit.collider.gameObject;
                grabbedRb = grabbedObject.GetComponent<Rigidbody>();

                // Desativa a gravidade temporariamente para o item não cair enquanto segura
                grabbedRb.useGravity = false;
                // Aumenta o arrasto para o item não ficar balançando descontroladamente
                grabbedRb.linearDamping = 10f;
                grabbedRb.angularDamping = 10f;
            }
        }
    }

    void DropObject()
    {
        if (grabbedObject == null) return;

        // Devolve os valores normais da física ao soltar
        grabbedRb.useGravity = true;
        grabbedRb.linearDamping = 1f;
        grabbedRb.angularDamping = 0.05f;

        grabbedObject = null;
        grabbedRb = null;
    }

    void MoveObject()
    {
        // Move o objeto suavemente até o GrabPoint usando forças físicas
        if (Vector3.Distance(grabbedObject.transform.position, grabPoint.position) > 0.1f)
        {
            Vector3 moveDirection = (grabPoint.position - grabbedObject.transform.position);
            grabbedRb.AddForce(moveDirection * 300f);
        }
    }
}
