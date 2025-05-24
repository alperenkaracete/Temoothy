using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(WheatTypes.BROWN_WHEAT))
        {
            Debug.Log("BrownWheat");
        }
        else if (other.CompareTag(WheatTypes.GREEN_WHEAT))
        {
            Debug.Log("GreenWheat");
        }
        else if (other.CompareTag(WheatTypes.GOLD_WHEAT))
        {
            Debug.Log("GoldWheat");
        }        
    }
}
