using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modding;
using UnityEngine;
using ModCommon;
using ModCommon.Util;
using HutongGames.PlayMaker.Actions;

namespace CycloneOut
{
    public class HeroScript : MonoBehaviour
    {
        PlayMakerFSM nailArt = null;
        void Start()
        {
            nailArt = gameObject.LocateMyFSM("Nail Arts");
            if (CycloneOutMod.cycloneSlash == null)
            {
                CycloneOutMod.cycloneSlash = Instantiate(nailArt.FsmVariables.FindFsmGameObject("Cyclone Slash").Value);
                CycloneOutMod.cycloneSlash.SetActive(false);
                DontDestroyOnLoad(CycloneOutMod.cycloneSlash);
            }
            nailArt.InsertCoroutine("Flash", 0, Shoot);
            Debug.Log("[!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!Add Flash ");
            nailArt.ChangeTransition("Flash", "FINISHED", "Regain Control");
            Debug.Log("[!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!ChangeTransition ");
        }

        public IEnumerator Shoot()
        {
            Debug.Log("[Shoot Fire!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            yield return GetComponent<tk2dSpriteAnimator>().PlayAnimWait("NA Cyclone Start");
            GameObject slash = Instantiate(CycloneOutMod.cycloneSlash);
            slash.SetActive(true);
            slash.transform.position = gameObject.transform.position;
            slash.AddComponent<CycloneSlash>();
            yield return GetComponent<tk2dSpriteAnimator>().PlayAnimWait("NA Cyclone End");
            nailArt.SetState("Regain Control");
        }
    }
}