public class Lumber : Resource
{
    private void Awake()
    {
        Name = "Lumber";
        JumpPower = ResourceSettings.JumpPowerLumber;
        Duration = ResourceSettings.DurationJumpLumber;
    }
}
