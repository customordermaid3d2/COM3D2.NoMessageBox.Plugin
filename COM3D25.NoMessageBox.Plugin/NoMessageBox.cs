using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace COM3D2.NoMessageBox.Plugin
{
    class MyAttribute
    {
        public const string PLAGIN_NAME = "NoMessageBox";
        public const string PLAGIN_VERSION = "22.2.23";
        public const string PLAGIN_FULL_NAME = "COM3D2.NoMessageBox.Plugin";
    }

    [BepInPlugin(MyAttribute.PLAGIN_FULL_NAME, MyAttribute.PLAGIN_FULL_NAME, MyAttribute.PLAGIN_VERSION)]// 버전 규칙 잇음. 반드시 2~4개의 숫자구성으로 해야함. 미준수시 못읽어들임

    public class NoMessageBox : BaseUnityPlugin
    {

        Harmony harmony;
        public static ManualLogSource Log;

        public void Awake()
        {
            Log = Logger;
            Logger.LogMessage("Awake");
        }

        public void OnEnable()
        {
            harmony = Harmony.CreateAndPatchAll(typeof(NDebugPatch));
        }

        public void OnDisable()
        {
            harmony?.UnpatchSelf();
        }
    }
}
