using UnityEngine;

public class StateCrouchShoot : PlayerStates
{
    public override void Initialize(Animator animator, Rigidbody rigidbody, PlayerController controller)
    {
        base.Initialize(animator, rigidbody, controller);
        state = StateTypePlayer.CrouchShoot;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _anim.SetInteger(_state, (int)state);
    }

    public override void OnUpdate()
    {
        if (!_controller.WantsShoot)
            _controller.SwitchState(_controller.FindState(StateTypePlayer.CrouchIdle));
    }
}