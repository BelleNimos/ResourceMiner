public class Gold : Resource
{
    private void Awake()
    {
        Name = "Gold";
        JumpPower = ResourceSettings.JumpPowerGold;
        Duration = ResourceSettings.DurationJumpGold;
    }
}
