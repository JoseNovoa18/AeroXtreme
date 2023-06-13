using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
    private float speed = 25.0f;
    private float turnSpeed = 75.0f;

    private float movementInput;
    private float forwardInput;

    private Rigidbody carRigidbody;

    private void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movementInput = Input.GetAxis("Vertical");
        forwardInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * movementInput);

        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * forwardInput);

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Si deseas evitar que la colisión afecte la rotación del objeto, establece isKinematic en true
        carRigidbody.isKinematic = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        // Cuando la colisión ha terminado, puedes restaurar isKinematic a false
        carRigidbody.isKinematic = false;
    }
    */
    /*
    public float acceleration = 10f; // Aceleración del carro
    public float maxSpeed = 20f; // Velocidad máxima del carro
    private float currentSpeed = 0f; // Velocidad actual del carro

    public float moveSpeed = 0f; // Velocidad de movimiento del carro
    public float rotationSpeed = 50f; // Velocidad de rotación del cuerpo del carro

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
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular la aceleración y velocidad del carro
        float accelerationAmount = acceleration * verticalInput * Time.deltaTime;
        moveSpeed = Mathf.Clamp(moveSpeed + accelerationAmount, -maxSpeed, maxSpeed);

        // Calcular el desplazamiento del carro
        float displacement = moveSpeed * Time.deltaTime;

        // Mover el carro en la dirección hacia adelante (eje Z)
        transform.Translate(0f, 0f, displacement);



        float horizontalInput = Input.GetAxis("Horizontal");

        // Calcular el valor de rotación
        float rotationAmount = rotationSpeed * horizontalInput * Time.deltaTime;

        // Girar el objeto sobre el eje Y
        transform.Rotate(Vector3.up, rotationAmount);

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
    */



    public string inputID;

    public float acceleration = 10f;
    public float maxSpeed = 20f;

    public float moveSpeed = 0f;
    public float rotationSpeed = 50f;

    public float hoverHeight = 1f;
    public float hoverForceMagnitude = 10f;

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
        float verticalInput = Input.GetAxis("Vertical" + inputID);

        // Calcular la aceleración y velocidad del carro
        float accelerationAmount = acceleration * verticalInput * Time.deltaTime;
        moveSpeed = Mathf.Clamp(moveSpeed + accelerationAmount, -maxSpeed, maxSpeed);

        // Calcular el desplazamiento del carro
        float displacement = moveSpeed * Time.deltaTime;

        // Mover el carro en la dirección hacia adelante (eje Z)
        transform.Translate(0f, 0f, displacement);

        float horizontalInput = Input.GetAxis("Horizontal" + inputID);

        // Calcular el valor de rotación sin multiplicar por Time.deltaTime
        float rotationAmount = rotationSpeed * horizontalInput;

        // Girar el objeto sobre el eje Y
        transform.Rotate(Vector3.up, rotationAmount * Time.deltaTime);

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
    private void OnCollisionEnter(Collision collision)
    {
        // Si deseas evitar que la colisión afecte la rotación del objeto, establece isKinematic en true
        rb.isKinematic = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        // Cuando la colisión ha terminado, puedes restaurar isKinematic a false
        rb.isKinematic = false;
    }
}
