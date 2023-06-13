using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionController : MonoBehaviour
{
    public string enemyPlayerID;
    public GameObject enemyPlayer;

    private LifeBar lifeBarScript;

    void Start()
    {
        lifeBarScript = enemyPlayer.GetComponent<LifeBar>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (enemyPlayer == null)
        {
            Debug.Log("Jugador enemigo eliminado");
            return;
        }

        if (collision.gameObject.CompareTag("Player" + enemyPlayerID))
        {
            Debug.Log(enemyPlayer.GetComponent<LifeBar>().actualLife);
            //Debug.Log("Choco con el enemigo " + collision.gameObject.name);
            /*
            enemyPlayer.GetComponent<LifeBar>().actualLife -= enemyPlayer.GetComponent<LifeBar>().damage;
            // Destruir el enemigo
            if (enemyPlayer.GetComponent<LifeBar>().actualLife == 0)
            {
                Debug.Log("Se muere");
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
            */
            lifeBarScript.actualLife -= lifeBarScript.damage;

            // Actualizar fillAmount en el script LifeBar
            lifeBarScript.UpdateLifeBar();

            // Destruir el enemigo si está muerto
            if (lifeBarScript.actualLife <= 0)
            {
                Debug.Log("Se muere");
                Destroy(enemyPlayer);
            }
            Destroy(gameObject);            
        }
        if (collision.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }
}
