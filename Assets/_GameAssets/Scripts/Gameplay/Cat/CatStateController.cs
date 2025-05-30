using UnityEngine;

public class CatStateController : MonoBehaviour
{
    private CatState _currentCatState;
    void Start()
    {
        _currentCatState = CatState.Walking;
    }

    public void SetCatState(CatState newCatState)
    {
        if (newCatState != _currentCatState)
        {
            _currentCatState = newCatState;
        }
    }

    public CatState GetCatState()
    {
        return _currentCatState;
    }
}
