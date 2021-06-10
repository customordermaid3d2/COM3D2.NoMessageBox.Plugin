using COM3D2.Lilly.Plugin;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BepInPluginSample
{
    class NDebugPatch
    {
        [HarmonyPatch(typeof(NDebug), "MessageBox"), HarmonyPrefix]
        private static bool MessageBox(string f_strTitle, string f_strMsg) // string __m_BGMName 못가져옴
        {
            MyLog.LogFatal(f_strTitle, f_strMsg);
            return false;
        }
    }
}
