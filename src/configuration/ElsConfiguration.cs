﻿/*
    ELS FiveM - A ELS implementation for FiveM
    Copyright (C) 2017  E.J. Bevenour

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ELS.configuration
{
    internal delegate void ControlsUpdatedhandler(ElsConfiguration.ELSControls elsControls);
    internal class ElsConfiguration
    {

        public static event ControlsUpdatedhandler ControlsUpdated;
        public static ELSControls KeyBindings = new ELSControls();
        internal ElsConfiguration()
        {
            FileLoader.OnSettingsLoaded += FileLoader_OnSettingsLoaded;
        }

        private void FileLoader_OnSettingsLoaded(SettingsType.Type type, string Data)
        {
            if (type == SettingsType.Type.GLOBAL)
            {
                var u = SharpConfig.Configuration.LoadFromString(Data);
                var t = u["CONTROL"]["Sound_Ahorn"].IntValue;
                KeyBindings.Sound_Ahorn = (Control)t;

                t = u["CONTROL"]["Snd_SrnTon1"].IntValue;
                KeyBindings.Snd_SrnTon1 = (Control)t;

                t = u["CONTROL"]["Snd_SrnTon2"].IntValue;
                KeyBindings.Snd_SrnTon2 = (Control)t;

                t = u["CONTROL"]["Snd_SrnTon3"].IntValue;
                KeyBindings.Snd_SrnTon3 = (Control)t;

                t = u["CONTROL"]["Snd_SrnTon4"].IntValue;
                KeyBindings.Snd_SrnTon4 = (Control)t;

                t = u["CONTROL"]["Sound_Manul"].IntValue;
                KeyBindings.Sound_Manul = (Control)t;

                t = u["CONTROL"]["Toggle_SIRN"].IntValue;
                KeyBindings.Toggle_SIRN = (Control)t;

                t = u["CONTROL"]["Toggle_DSRN"].IntValue;
                KeyBindings.Toggle_DSRN = (Control)t;

                t = u["CONTROL"]["TogInfoPanl"].IntValue;
                KeyBindings.TogInfoPanl = (Control)t;

                t = u["CONTROL"]["Snd_SrnPnic"].IntValue;
                KeyBindings.Snd_SrnPnic = (Control)t;

                t = u["CONTROL"]["Toggle_SECL"].IntValue;
                KeyBindings.ToggleSecL = (Control)t;

                t = u["CONTROL"]["Toggle_WRNL"].IntValue;
                KeyBindings.ToggleWrnL = (Control)t;

                t = u["CONTROL"]["Toggle_CRSL"].IntValue;
                KeyBindings.ToggleCrsL = (Control)t;

                t = u["CONTROL"]["ChgPat_PRML"].IntValue;
                KeyBindings.ChgPattPrmL = (Control)t;

                t = u["CONTROL"]["ChgPat_SECL"].IntValue;
                KeyBindings.ChgPattSecL = (Control)t;

                t = u["CONTROL"]["ChgPat_WRNL"].IntValue;
                KeyBindings.ChgPattWrnL = (Control)t;

                t = u["CONTROL"]["Toggle_LSTG"].IntValue;
                KeyBindings.ToggleLstg = (Control)t;

                t = u["CONTROL"]["Toggle_TKDL"].IntValue;
                KeyBindings.ToggleTdl = (Control)t;

                t = u["CONTROL"]["Toggle_BRD"].IntValue;
                KeyBindings.ToggleBoard = (Control)t;

                t = u["CONTROL"]["Toggle_LIND"].IntValue;
                KeyBindings.ToggleLIND = (Control)t;

                t = u["CONTROL"]["Toggle_RIND"].IntValue;
                KeyBindings.ToggleRIND = (Control)t;

                t = u["CONTROL"]["Toggle_HAZ"].IntValue;
                KeyBindings.ToggleHAZ = (Control)t;


                ControlsUpdated?.Invoke(KeyBindings);
                Global.EnabeTrafficControl = u["GENERAL"]["ElsTrafCtrlOn"].BoolValue;
                Global.PrimDelay = u["LIGHTING"]["LightFlashDelayMainLts"].IntValue;
                Global.DeleteInterval = u["Admin"]["VehicleDeleteInterval"].FloatValue * 60 * 1000;
                Global.EnvLightRng = u["LIGHTING"]["EnvLtMultExtraLts_Rng"].FloatValue * 25f;
                Global.EnvLightInt = u["LIGHTING"]["EnvLtMultExtraLts_Int"].FloatValue * .02f;
                Global.TkdnRng = u["LIGHTING"]["EnvLtMultTakedwns_Rng"].FloatValue * 25f;
                Global.TkdnInt = u["LIGHTING"]["EnvLtMultTakedwns_Int"].FloatValue * 1f;
                Global.AllowController = u["CONTROL"]["AllowController"].BoolValue;
                Utils.DebugWrite($"Configuration ran \n ---------------------- \n Traffic Control: {Global.EnabeTrafficControl} \n Delay: {Global.PrimDelay} \n Delete Interval: {Global.DeleteInterval} \n Env Lighting Range: {Global.EnvLightRng}");
            }
        }
        internal class ELSControls
        {
            internal Control ToggleTdl { get; set; }
            internal Control Toggle_SIRN { get; set; }
            internal Control Sound_Ahorn { get; set; }
            internal Control Snd_SrnTon1 { get; set; }
            internal Control Snd_SrnTon2 { get; set; }
            internal Control Snd_SrnTon3 { get; set; }
            internal Control Snd_SrnTon4 { get; set; }
            internal Control Snd_SrnPnic { get; set; }
            internal Control Sound_Manul { get; set; }
            internal Control Toggle_DSRN { get; set; }
            internal Control TogInfoPanl { get; set; }
            internal Control ToggleBoard { get; set; }
            internal Control ToggleSecL { get; set; }
            internal Control ToggleWrnL { get; set; }
            internal Control ToggleCrsL { get; set; }
            internal Control ChgPattPrmL { get; set; }
            internal Control ChgPattSecL { get; set; }
            internal Control ChgPattWrnL { get; set; }
            internal Control ToggleLstg { get; set; }
            internal Control ToggleLIND { get; set; }
            internal Control ToggleRIND { get; set; }
            internal Control ToggleHAZ { get; set; }
        }

        internal static bool isValidData(string data)
        {
            return SharpConfig.Configuration.LoadFromString(data).Contains("CONTROL", "Toggle_WRNL");
        }

        
    }
}