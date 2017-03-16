﻿using CitizenFX.Core;
using CitizenFX.Core.Native;
using ELS.Sirens.Tones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELS
{
    class RemoteEventManager
    {
        public RemoteEventManager()
        {
             
        }
        public enum MessageTypes
        {
            SirenUpdate,
            SirenAdded,
            SirenRemoved
        }
        public delegate void RemoteMessageRecievedHandler();
        public static event RemoteMessageRecievedHandler RemoteMessageRecieved;
        public static void SendEvent(MessageTypes type,Vehicle vehicle)
        {
            var netID = Function.Call<int>(Hash.VEH_TO_NET, vehicle);

            BaseScript.TriggerServerEvent("ELS",type,netID);
        }
    }
}