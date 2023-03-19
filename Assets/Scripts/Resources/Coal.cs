public class Coal : Resource
{
    private void Awake()
    {
        Name = "Coal";
        JumpPower = ResourceSettings.JumpPowerCoal;
        Duration = ResourceSettings.DurationJumpCoal;
    }
}
