using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(WheatTypes.BROWN_WHEAT))
        {
            other.gameObject?.GetComponent<BrownWheatCollectible>().Collect();
        }
        else if (other.CompareTag(WheatTypes.GREEN_WHEAT))
        {
           other.gameObject?.GetComponent<GreenWheatCollectible>().Collect();
        }
        else if (other.CompareTag(WheatTypes.GOLD_WHEAT))
        {
            other.gameObject?.GetComponent<GoldWheatCollectible>().Collect();
        }        
    }
}
