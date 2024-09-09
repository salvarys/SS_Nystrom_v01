using System;

namespace PlayerPattern
{

    public interface IPlayerState
    {
        void HandleInput(Player player, ConsoleKey input);
        void Update(Player player);
    }
}
