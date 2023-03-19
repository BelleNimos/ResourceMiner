public class Iron : Resource
{
    private void Awake()
    {
        Name = "Iron";
        JumpPower = ResourceSettings.JumpPowerIron;
        Duration = ResourceSettings.DurationJumpIron;
    }
}
