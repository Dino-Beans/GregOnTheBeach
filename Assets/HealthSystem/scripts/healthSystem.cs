using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthSystem : MonoBehaviour
{
    [Serializable]
    public struct HealthValues
    {
        public string TagName;
        public int Value;
    }

    [Header("Health")]
    public int maxHealth = 8;
    private int health = 8;
    public Transform Pizza;

    [Header("Obstacles")]
    public HealthValues[] healthValues;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    private void damage(int amount) {
        if (health < amount)
        {
            amount = health;
        }
        health -= amount;
        for (int i = 0; i < amount; i++)
        {
            Destroy(Pizza.GetChild(i).gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        for(int i = 0; i < healthValues.Length; i++) {
            if (other.tag == healthValues[i].TagName)
            {
                damage(healthValues[i].Value);
            }
        }
    }
}
