
namespace PlayerPattern
{
    public class PlayerStateContext 
    {
        public IPlayerState _currentState
        {
            get;  set;
        }

        public void SetState(IPlayerState newState)
        {
            _currentState = newState;
        }

        public void HandleInput(ConsoleKey input)
        {
            _currentState.HandleInput(this, input);
        }

        public void Update()
        {
            _currentState.Update(this);
        }
    }
}
