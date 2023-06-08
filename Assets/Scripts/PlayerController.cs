using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocidad de movimiento del carro
    public float rotateSpeed = 5f; // Velocidad de rotación del cuerpo del carro
    public float hoverHeight = 1f; // Altura a la que el carro flota
    public float hoverForceMagnitude = 10f; // Fuerza que empuja el carro hacia arriba
    public LayerMask groundLayer; // Capa del suelo    

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Desactivar la gravedad del Rigidbody para permitir el vuelo
    }

    private void FixedUpdate()
    {
        // Obtener la entrada de movimiento horizontal y vertical
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcular la dirección de movimiento
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        movement = transform.TransformDirection(movement); // Convertir a la dirección local del carro
        movement *= moveSpeed; // Multiplicar por la velocidad de movimiento

        // Aplicar la fuerza al Rigidbody para mover el carro
        rb.AddForce(movement);

        // Calcular la rotación del cuerpo del carro
        Quaternion targetRotation = Quaternion.Euler(0f, moveHorizontal * rotateSpeed, 0f);
        rb.MoveRotation(rb.rotation * targetRotation);

        // Realizar el raycast hacia abajo para determinar la posición del suelo
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, hoverHeight, groundLayer))
        {
            // Calcular la fuerza necesaria para mantener la altura del carro
            float distance = hoverHeight - hit.distance;
            

            Vector3 hoverForce = Vector3.Cross(Vector3.up, hit.normal) * distance * hoverForceMagnitude;


            // Aplicar la fuerza al Rigidbody para mantener el carro flotando
            rb.AddForce(hoverForce, ForceMode.Acceleration);
        }
    }
}
