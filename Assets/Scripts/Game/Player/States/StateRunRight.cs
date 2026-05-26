using UnityEngine;

public class StateRunRight : PlayerStates
{
    public override void Initialize(Animator animator, Rigidbody rigidbody, PlayerController controller)
    {
        base.Initialize(animator, rigidbody, controller);
        state = StateTypePlayer.RunRight;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _anim.SetInteger(_state, (int)state);
    }
}