
namespace CycloneOut;

[AttachHeroController]
public class HeroScript : MonoBehaviour
{
    PlayMakerFSM nailArt = null;
    HeroController hc;
    
    void Start()
    {
        hc = GetComponent<HeroController>();
        nailArt = gameObject.LocateMyFSM("Nail Arts");
        if (CycloneOutMod.cycloneSlash == null)
        {
            CycloneOutMod.cycloneSlash = Instantiate(nailArt.FsmVariables.FindFsmGameObject("Cyclone Slash").Value, 
                Vector3.zero, Quaternion.identity, null);
            CycloneOutMod.cycloneSlash.SetActive(false);
            DontDestroyOnLoad(CycloneOutMod.cycloneSlash);
        }
        using(var patch = nailArt.Fsm.CreatePatch())
        {
            patch.AddState("Temp 0")
                .EditState("Flash")
                .AppendAction(
                    FSMHelper.CreateMethodAction((a) =>
                    {
                        if(!CycloneOutMod.isEnable)
                        {
                            a.Finish();
                            return;
                        }
                        a.Fsm.SetState("Temp 0");
                        StartCoroutine(Shoot());
                    })
                );
        }
    }

    public IEnumerator Shoot()
    {
        hc.StopAnimationControl();
        yield return GetComponent<tk2dSpriteAnimator>().PlayAnimWait("NA Cyclone Start");
        GameObject slash = Instantiate(CycloneOutMod.cycloneSlash);
        slash.SetActive(true);
        slash.transform.position = gameObject.transform.position;
        slash.AddComponent<CycloneSlash>();
        yield return GetComponent<tk2dSpriteAnimator>().PlayAnimWait("NA Cyclone End");
        hc.StartAnimationControl();
        nailArt.SetState("Regain Control");
    }
}
