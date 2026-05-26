using UnityEngine;

public class StateWalkRight : PlayerStates
{
    public override void Initialize(Animator animator, Rigidbody rigidbody, PlayerController controller)
    {
        base.Initialize(animator, rigidbody, controller);
        state = StateTypePlayer.WalkRight;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _anim.SetInteger(_state, (int)state);
    }
}