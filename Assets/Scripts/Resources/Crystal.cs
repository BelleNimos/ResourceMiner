public class Crystal : Resource
{
    private void Awake()
    {
        Name = "Crystal";
        JumpPower = ResourceSettings.JumpPowerCrystal;
        Duration = ResourceSettings.DurationJumpCrystal;
    }
}
