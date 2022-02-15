﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Logging;
using BepInEx.Unity;
using BepInEx.Unity.Bootstrap;
using Characters.Controllers;
using Data;
using HarmonyLib;
using InControl;
using Level;
using MonoMod.RuntimeDetour;
using Services;
using Singletons;
using Steamworks;
using UI.TestingTool;
using UnityEngine;
using Action = Characters.Actions.Action;
using Random = System.Random;

namespace Skul.Mod
{
    [BepInPlugin("Tobi.Mob.Skul.Mod", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public Harmony _harmony = null;
        
        private void Awake()
        {
            Helper.Logger = Logger;
            
            // Plugin startup logic
            Logger.LogInfo("Plugin " + PluginInfo.PLUGIN_GUID + " is loaded!");
            
            // Execute all patches
            _harmony = new Harmony("Skul.Mod");
            _harmony.PatchAll(typeof(DropRatePatch));
            _harmony.PatchAll(typeof(PathPatch));
            
            // Active Turbo-Button-Worker
            TurboButtonMode.StartSetTurboCoroutine(this);
        }
        
        private LevelManager levelManager => Singleton<Service>.Instance.levelManager;
        
        private void Update()
        {
            // Only run, if a player is running around
            if (!Helper.IsInGame)
                return;

            if(Input.GetKeyDown(KeyCode.F1))
            {
                Helper.TextSpawner.SpawnBuff("Mod running!", levelManager.player.transform.position);
            }

            if (Input.GetKeyDown(KeyCode.F2))
            {
                TurboButtonMode.ToggleTurbo();
            }

            // Lock Quartz high enough to unlock everything
            if(GameData.Currency.darkQuartz != null)
                GameData.Currency.darkQuartz.balance = 100000;
        }


    }
}
