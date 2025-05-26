using UnityEngine;

[CreateAssetMenu(fileName = "WheatDesignSO", menuName = "ScriptableObjects/WheatDesignSO")]
public class WheatDesignSO : ScriptableObject
{
    [SerializeField] private float _increaseDecreaseAmount;
    [SerializeField] private float _duration;

    public float IncreaseDecreaseAmount => _increaseDecreaseAmount;
    public float Duration => _duration;
}
