using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeBar : MonoBehaviour
{
    public Image lifeBar;
    public float actualLife = 100;
    public float maximumLife = 100;
    public float damage = 10;

    private float initialActualLife;
    private float initialMaximumLife;

    private void Start()
    {
        initialActualLife = actualLife;
        initialMaximumLife = maximumLife;
    }
    public void UpdateLifeBar()
    {
        lifeBar.fillAmount = actualLife / maximumLife;
    }
    private void OnDisable()
    {
        actualLife = initialActualLife;
        maximumLife = initialMaximumLife;
        lifeBar.fillAmount = actualLife / maximumLife;
    }
}
