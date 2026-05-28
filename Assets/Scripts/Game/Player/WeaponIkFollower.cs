using UnityEngine;

[RequireComponent (typeof(Animator))]

public class WeaponIkFollower : MonoBehaviour
{
    [SerializeField] private CustomIkController[] _ikController;
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        AnimateIK();
    }

    private void AnimateIK()
    {
        if (_anim)
        {
            foreach (CustomIkController ik in _ikController)
            {
                _anim.SetIKPositionWeight(ik.goal, ik.weight);
                _anim.SetIKRotationWeight(ik.goal, ik.weight);

                _anim.SetIKPosition(ik.goal, ik.target.position);
                _anim.SetIKRotation(ik.goal, ik.target.rotation);
            }
        }
    }
}