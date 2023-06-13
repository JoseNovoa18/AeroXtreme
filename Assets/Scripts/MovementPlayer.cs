using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public string inputID;
    public KeyCode fireKey;
    public float speedMovement = 5.0f;
    public float speedRotation = 250.0f;
    public GameObject bulletPrefab;
    public Transform[] firePoints;
    private float x, y;
    private Rigidbody rb;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal" + inputID);
        y = Input.GetAxis("Vertical" + inputID);

        transform.Translate(0, 0, y * Time.deltaTime * speedMovement);
        transform.Rotate(0, x * Time.deltaTime * speedRotation, 0);

        if (Input.GetKeyDown(fireKey)) // Ejemplo con la tecla Espacio
        {
            foreach (Transform firePoint in firePoints)
            {
                // Instancia la bala utilizando el prefab y la posición/rotación de cada punto de disparo
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

                // Aquí puedes aplicar cualquier lógica adicional a la bala (como aplicar fuerzas, establecer velocidad, etc.)
                // Obtén el componente Rigidbody de la bala
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

                // Asigna una velocidad constante hacia adelante a la bala
                bulletRb.velocity = bullet.transform.forward * 20f;
            }
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        rb.isKinematic = false;
    }    
}
