

namespace CycloneOut;

public class CycloneOutMod : ModBase<CycloneOutMod>, ITogglableMod
{
    public CycloneOutMod() : base("Cyclone Throws")
    {

    }
    public static GameObject cycloneSlash = null;
    public static bool isEnable = false;
    public override void Initialize()
    {
        isEnable = true;
    }
    public void Unload()
    {
        isEnable = false;
    }
}
