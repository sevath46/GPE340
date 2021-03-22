using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class itemDrop 
{
    public GameObject itemToDrop;
    public int weight;
}
public class Drops : MonoBehaviour
{
    public List<itemDrop> drops;
    private List<int> CDFArray;

    public void DropRandomItem()
    {
        //Rnadom number between 0 and total drop weight.
        int randomNumber = Random.Range(0, CDFArray[CDFArray.Count - 1]);

        /*
         METHOD ONE FOR RANDOM DROP NON- BINARY.
        
        for (int i = 0; i < CDFArray.Count; i++) 
        {
            if (randomNumber < CDFArray[i]) 
            {
                Instantiate(drops[i].itemToDrop, transform.position, transform.rotation);
                return;
            }
        }
        */

        //Binary Drop.
        int selectedIndex = System.Array.BinarySearch(CDFArray.ToArray(), randomNumber);
        //If binary number is negative
        if (selectedIndex < 0)
        {
            //grab positive value.
            selectedIndex = ~selectedIndex;
        }

        Instantiate(drops[selectedIndex].itemToDrop, transform.position, Quaternion.identity);
    }
    void Start() 
    {
        CDFArray = new List<int>();
        //Going through every item in drop list to set the CDF value
        for (int i = 0; i < drops.Count; i++)
        {
            if (i == 0)
            {
                CDFArray.Add(drops[i].weight);
            }
            else
            {
                CDFArray.Add(drops[i].weight + CDFArray[i - 1]);
            }
        }
    }
}
