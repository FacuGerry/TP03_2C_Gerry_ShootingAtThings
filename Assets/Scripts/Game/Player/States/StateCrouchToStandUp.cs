using UnityEngine;

public class StateCrouchToStandUp : PlayerStates
{
    public override void Initialize(Animator animator, Rigidbody rigidbody, PlayerController controller)
    {
        base.Initialize(animator, rigidbody, controller);
        state = StateTypePlayer.CrouchToStandUp;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _anim.SetInteger(_state, (int)state);
    }

    public override void OnUpdate()
    {
        AnimatorStateInfo info = _anim.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime >= 1f)
        {
            _controller.ChangeCrouching(false);
            _controller.SwitchState(_controller.FindState(StateTypePlayer.Idle));
        }
    }
}