using UnityEngine;

public class StateCrouchIdle : PlayerStates
{
    public override void Initialize(Animator animator, Rigidbody rigidbody, PlayerController controller)
    {
        base.Initialize(animator, rigidbody, controller);
        state = StateTypePlayer.CrouchIdle;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _anim.SetInteger(_state, (int)state);
    }
}
