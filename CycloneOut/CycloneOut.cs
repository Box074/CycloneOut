using System;
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
    public class CycloneOutMod : Mod
    {
        public static GameObject cycloneSlash = null;
        public override void Initialize()
        {
            ModHooks.HeroUpdateHook += ModHooks_HeroUpdateHook;
        }

        private void ModHooks_HeroUpdateHook()
        {
            if (HeroController.instance.GetComponent<HeroScript>() == null) HeroController.instance.gameObject.AddComponent<HeroScript>();
        }
    }
}
