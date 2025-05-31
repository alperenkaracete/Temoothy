using UnityEngine;

public class CatAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _catAnimator;

    private CatStateController _catStateController;
    private CatController _catController;

    void Awake()
    {
        _catStateController = GetComponent<CatStateController>();
        _catController = GetComponent<CatController>();
    }

    void Update()
    {
        SetCatAnimations();
    }

    private void SetCatAnimations()
    {
        CatState catState = _catStateController.GetCatState();
        switch (catState)
        {

            case CatState.Idle:
                _catAnimator.SetBool(CatActionTypes.IDLE, true);
                _catAnimator.SetBool(CatActionTypes.RUN, false);
                _catAnimator.SetBool(CatActionTypes.WALK, false);
                break;

            case CatState.Walking:
                _catAnimator.SetBool(CatActionTypes.WALK, true);
                _catAnimator.SetBool(CatActionTypes.RUN, false);
                _catAnimator.SetBool(CatActionTypes.IDLE, false);
                break;                

            case CatState.Running:
                _catAnimator.SetBool(CatActionTypes.RUN, true);
                _catAnimator.SetBool(CatActionTypes.ATTACK, false);
                break;

            case CatState.Attacking:
                _catAnimator.SetBool(CatActionTypes.ATTACK, true);
                break;

        }
    }
}
