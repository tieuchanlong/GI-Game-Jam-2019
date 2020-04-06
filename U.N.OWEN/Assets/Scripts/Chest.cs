using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chest : MonoBehaviour
{
    public GameObject Tag;
    public GameObject Health;
    public GameObject RangeEnemy;

    private float spawnChance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Tag.activeSelf == true)
        {
            if (Input.GetButtonDown("Interact"))
            {
                Debug.Log("Yes");

                spawnChance = Random.RandomRange(0, 100);

                if (spawnChance < 10)
                {
                    Instantiate(RangeEnemy, transform.position, Quaternion.identity);
                    Tag.SetActive(false);
                }
                else
                {
                    Instantiate(Health, transform.position, Quaternion.identity);
                    Tag.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Activate the option for open
            Tag.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Tag.SetActive(false);
    }
}
