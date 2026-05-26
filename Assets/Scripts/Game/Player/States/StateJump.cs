using UnityEngine;

public class StateJump : PlayerStates
{
    public override void Initialize(Animator animator, Rigidbody rigidbody, PlayerController controller)
    {
        base.Initialize(animator, rigidbody, controller);
        state = StateTypePlayer.Jump;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _anim.SetInteger(_state, (int)state);
        _controller.Jump();
    }

    public override void OnUpdate()
    {
        AnimatorStateInfo info = _anim.GetCurrentAnimatorStateInfo(0);

        if (info.normalizedTime >= 1f)
        {
            StateTypePlayer nextState = _controller.GetMovementState();
            _controller.SwitchState(_controller.FindState(nextState));
        }
    }
}