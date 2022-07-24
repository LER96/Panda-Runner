using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    //write a code that deletes sections we've passed
    public GameObject[] section;
    public List<GameObject> section2;
    private GameObject[] coins;
    public bool creatSection = false;
    public int zPos = 80;
    int secNumb;
    int copynum;
    public float CreateSec = 5;
    private float size;
    private float num;
    // Start is called before the first frame update
    void Start()
    {
        //put all the game object with tag Section to both array and list
        section = GameObject.FindGameObjectsWithTag("Section");
        foreach(GameObject obj in section)
        {
            section2.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //check if the list is not empty otherwise refill
        if(section2.Count==0)
        {
            foreach (GameObject obj in section)
            {
                section2.Add(obj);
            }
        }
        //section = GameObject.FindGameObjectsWithTag("Section");
        //array of coins
        coins = GameObject.FindGameObjectsWithTag("Coin");

        //calls the generate section
        if (creatSection == false)
        {
            creatSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        //random obj in the list
        secNumb = Random.Range(0, section2.Count);

        //set active all the coins that are being collected 
        foreach(GameObject coin in coins)
        {
            coin.SetActive(true);
        }
        Instantiate(section2[secNumb], new Vector3(0, -0.5f, zPos), Quaternion.identity);
        section2.Remove(section2[secNumb]);
        zPos +=160;
        yield return new WaitForSeconds(CreateSec);
        creatSection = false;
    }
}
