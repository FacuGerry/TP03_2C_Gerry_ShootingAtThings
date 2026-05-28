using UnityEngine;

public class StateWalk : PlayerStates
{
    public override void Initialize(Animator animator, Rigidbody rigidbody, PlayerController controller)
    {
        base.Initialize(animator, rigidbody, controller);
        state = StateTypePlayer.Walk;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _anim.SetInteger(_state, (int)state);
    }

    public override void OnUpdate()
    {
        _controller.CalculatePlayerSpeed();

        if (_controller.WantsJump)
        {
            _controller.SwitchState(_controller.FindState(StateTypePlayer.Jump));
            return;
        }

        if (_controller.WantsCrouch)
        {
            _controller.SwitchState(_controller.FindState(StateTypePlayer.StandUpToCrouch));
            return;
        }

        if (_controller.WantsShoot)
        {
            _controller.SwitchState(_controller.FindState(StateTypePlayer.Shoot));
            return;
        }

        if (_controller.IsWalking && _anim.GetInteger(_state) != (int)state)
            _anim.SetInteger(_state, (int)state);

        if (!_controller.IsWalking && _anim.GetInteger(_state) != (int)StateTypePlayer.Run)
            _anim.SetInteger(_state, (int)StateTypePlayer.Run);

        _controller.SwitchState(_controller.FindState(StateTypePlayer.Idle));
    }
}