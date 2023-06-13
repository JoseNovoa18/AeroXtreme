using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCollisionController : MonoBehaviour
{
    public string enemyPlayerID;
    public GameObject enemyPlayer;

    private LifeBar lifeBarScript;

    public Image background;

    [SerializeField] private AudioClip explosion;

    public ParticleSystem collisionParticles;

    public GameObject restartButton;
    public GameObject winPlayer;

    void Start()
    {
        lifeBarScript = enemyPlayer.GetComponent<LifeBar>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (enemyPlayer == null)
        {
            Debug.Log("Jugador enemigo eliminado");
        }

        if (collision.gameObject.CompareTag("Player" + enemyPlayerID))
        {
            AudioSource soundSource = SoundController.Instance.GetComponent<AudioSource>();
            soundSource.volume = 0.2f;
            soundSource.PlayOneShot(explosion);
            PlayCollisionEffect(collision);
            Debug.Log(enemyPlayer.GetComponent<LifeBar>().actualLife);
            lifeBarScript.actualLife -= lifeBarScript.damage;

            // Actualizar fillAmount en el script LifeBar
            lifeBarScript.UpdateLifeBar();

            // Destruir el enemigo si está muerto
            if (lifeBarScript.actualLife <= 0)
            {
                Debug.Log("Se muere");
                Destroy(enemyPlayer);
                background.gameObject.SetActive(false);
                restartButton.SetActive(true);
                winPlayer.gameObject.SetActive(true);                
            }
            Destroy(gameObject);            
        }

        if (collision.gameObject.CompareTag("Walls") || collision.gameObject.CompareTag("Obstacles"))
        {
            AudioSource soundSource = SoundController.Instance.GetComponent<AudioSource>();
            soundSource.volume = 0.15f;
            soundSource.PlayOneShot(explosion);
            //SoundController.Instance.PlaySound(explosion);
            PlayCollisionEffect(collision);
            Destroy(gameObject);
        }

        void PlayCollisionEffect(Collision collision)
        {
            // Obtén el punto de colisión para activar el efecto en esa posición
            Vector3 collisionPoint = collision.contacts[0].point;

            // Instancia y reproduce el sistema de partículas en el punto de colisión
            ParticleSystem effect = Instantiate(collisionParticles, collisionPoint, Quaternion.identity);
            effect.Play();

            // Destruye el sistema de partículas después de un tiempo
            Destroy(effect.gameObject, effect.main.duration);
        }
    }
}