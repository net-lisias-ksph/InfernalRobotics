using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Diagnostics;


namespace MuMech
{
    public class MechJebModuleVesselInfo : ComputerModule
    {
        static MechJebModuleVesselInfo buildSceneDrawer = null;

        bool _buildSceneShow = true;
        bool buildSceneShow
        {
            get { return _buildSceneShow; }
            set
            {
                if (value != _buildSceneShow) core.settingsChanged = true;
                _buildSceneShow = value;
            }
        }

        bool _buildSceneMinimized = false;
        bool buildSceneMinimized
        {
            get { return _buildSceneMinimized; }
            set
            {
                if (value != _buildSceneMinimized) core.settingsChanged = true;
                _buildSceneMinimized = value;
            }
        }

        public override void onLoadGlobalSettings(SettingsManager settings)
        {
            base.onLoadGlobalSettings(settings);

            buildSceneShow = settings["VI_buildSceneShow"].valueBool(true);
            buildSceneMinimized = settings["VI_buildSceneMinimized"].valueBool(false);
        }

        public override void onSaveGlobalSettings(SettingsManager settings)
        {
            base.onSaveGlobalSettings(settings);

            settings["VI_buildSceneShow"].value_bool = buildSceneShow;
            settings["VI_buildSceneMinimized"].value_bool = buildSceneMinimized;
        }


        FuelFlowAnalyzer ffa = new FuelFlowAnalyzer();

        public MechJebModuleVesselInfo(MechJebCore core) : base(core) { }

        float[] timePerStageAtmo = new float[0];
        float[] deltaVPerStageAtmo = new float[0];
        float[] timePerStageVac = new float[0];
        float[] deltaVPerStageVac = new float[0];
        float[] twrPerStage = new float[0];

        Stopwatch nextSimulationTimer = new Stopwatch();
        double nextSimulationDelayMs = 0;
        public override void onPartFixedUpdate()
        {
            if (!this.enabled || !part.vessel.isActiveVessel) return;

            runSimulations();
        }

        void runSimulations()
        {
            if (((TimeWarp.WarpMode == TimeWarp.Modes.LOW) || (TimeWarp.CurrentRate <= TimeWarp.MaxPhysicsRate)) &&
                (nextSimulationDelayMs == 0 || nextSimulationTimer.ElapsedMilliseconds > nextSimulationDelayMs))
            {
                Stopwatch s = Stopwatch.StartNew();
                double surfaceGravity;
                List<Part> parts;
                if (part.vessel == null)
                {
                    parts = EditorLogic.SortedShipList;
                    surfaceGravity = 9.81;
                }
                else
                {
                    parts = part.vessel.parts;
                    surfaceGravity = part.vessel.mainBody.GeeASL * 9.81;
                }
                ffa.analyze(parts, (float)surfaceGravity, 1.0F, out timePerStageAtmo, out deltaVPerStageAtmo, out twrPerStage);
                ffa.analyze(parts, (float)surfaceGravity, 0.0F, out timePerStageVac, out deltaVPerStageVac, out twrPerStage);
                s.Stop();

                nextSimulationDelayMs = 10 * s.ElapsedMilliseconds;
                nextSimulationTimer.Reset();
                nextSimulationTimer.Start();
            }
        }

        public override string getName()
        {
            return "Vessel Information";
        }


        public override void onPartStart()
        {
            //a bit of a hack to detect when we start up attached to a rocket
            //that just got loaded into the VAB:
            if (part.vessel == null && (part.parent != null || part is CommandPod))
            {
                RenderingManager.AddToPostDrawQueue(0, drawBuildSceneGUI);
            }
        }

        public override void onPartAttach(Part parent)
        {
            RenderingManager.AddToPostDrawQueue(0, drawBuildSceneGUI);
        }

        public override void onPartDetach()
        {
            if (buildSceneDrawer == this) buildSceneDrawer = null;
            RenderingManager.RemoveFromPostDrawQueue(0, drawBuildSceneGUI);
        }

        public override void onPartDestroy()
        {
            if (buildSceneDrawer == this) buildSceneDrawer = null;
            RenderingManager.RemoveFromPostDrawQueue(0, drawBuildSceneGUI);
        }

        public override void onPartDelete()
        {
            if (buildSceneDrawer == this) buildSceneDrawer = null;
            RenderingManager.RemoveFromPostDrawQueue(0, drawBuildSceneGUI);
        }


        public override GUILayoutOption[] windowOptions()
        {
            return new GUILayoutOption[] { GUILayout.Width(300), GUILayout.Height(100) };
        }

        GUILayoutOption[] minimizedWindowOptions()
        {
            return new GUILayoutOption[] { GUILayout.Width(100), GUILayout.Height(30) };
        }

        protected override void WindowGUI(int windowID)
        {
            GUIStyle txtR = new GUIStyle(GUI.skin.label);
            txtR.alignment = TextAnchor.UpperRight;

            GUILayout.BeginVertical();

            buildSceneShow = GUILayout.Toggle(buildSceneShow, "Show in VAB");

            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            GUILayout.Label("Total mass", GUILayout.ExpandWidth(true));
            GUILayout.Label(vesselState.mass.ToString("F2") + " tons", txtR);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            GUILayout.Label("Total thrust", GUILayout.ExpandWidth(true));
            GUILayout.Label(vesselState.thrustAvailable.ToString("F0") + " kN", txtR);
            GUILayout.EndHorizontal();

            double gravity = part.vessel.mainBody.gravParameter / Math.Pow(part.vessel.mainBody.Radius, 2);
            double TWR = vesselState.thrustAvailable / (vesselState.mass * gravity);
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            GUILayout.Label("Surface TWR", GUILayout.ExpandWidth(true));
            GUILayout.Label(TWR.ToString("F2"), txtR);
            GUILayout.EndHorizontal();

            gravity = part.vessel.mainBody.gravParameter / Math.Pow(part.vessel.mainBody.Radius + vesselState.altitudeASL, 2);
            TWR = vesselState.thrustAvailable / (vesselState.mass * gravity);

            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            GUILayout.Label("Current TWR", GUILayout.ExpandWidth(true));
            GUILayout.Label(TWR.ToString("F2"), txtR);
            GUILayout.EndHorizontal();

            doStagingAnalysisGUI();

            GUILayout.EndVertical();

            base.WindowGUI(windowID);
        }

        void drawBuildSceneGUI()
        {
            //in the VAB, onPartFixedUpdate doesn't get called, so
            //settings changes don't get saved unless we do this:
            if (core.settingsChanged) core.saveSettings();

            if (buildSceneDrawer == null)
            {
                buildSceneDrawer = this;
            }

            if (buildSceneDrawer == this && buildSceneShow)
            {
                runSimulations();

                GUI.skin = MuUtils.DefaultSkin;
                if (buildSceneMinimized)
                {
                    windowPos = GUILayout.Window(872035, windowPos, buildSceneWindowGUI, "Vessel Info", minimizedWindowOptions());
                }
                else
                {
                    windowPos = GUILayout.Window(872035, windowPos, buildSceneWindowGUI, getName(), windowOptions());
                }
            }
        }

        protected void buildSceneWindowGUI(int windowID)
        {
            if (buildSceneMinimized)
            {
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Max")) buildSceneMinimized = false;
                if (GUILayout.Button("X", ARUtils.buttonStyle(Color.red))) buildSceneShow = false;
                GUILayout.EndHorizontal();
                base.WindowGUI(windowID);
                return;
            }


            double mass = 0;
            foreach (Part part in EditorLogic.SortedShipList)
            {
                if (part.physicalSignificance != Part.PhysicalSignificance.NONE)
                {
                    mass += part.mass;
                    foreach (PartResource r in part.Resources) mass += r.amount * ARUtils.resourceDensity(r.info.id);
                }

                //In the VAB, ModuleJettison (which adds fairings) forgets to subtract the fairing mass from
                //the part mass if the engine does have a fairing, so we have to do this manually
                if (part.vessel == null //hacky way to tell whether we're in the VAB
                    && (part.Modules.OfType<ModuleJettison>().Count() > 0))
                {
                    ModuleJettison jettison = part.Modules.OfType<ModuleJettison>().First();
                    if (part.findAttachNode(jettison.bottomNodeName).attachedPart == null)
                    {
                        mass -= jettison.jettisonedObjectMass;
                    }
                }

            }

            double TWR = 0;
            if (twrPerStage.Length > 0) TWR = twrPerStage[twrPerStage.Length - 1];

            int partCount = EditorLogic.SortedShipList.Count;

            GUIStyle txtR = new GUIStyle(GUI.skin.label);
            txtR.alignment = TextAnchor.UpperRight;



            GUILayout.BeginVertical();


            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Minimize"))
            {
                buildSceneMinimized = true;
            }
            if (GUILayout.Button("Close", ARUtils.buttonStyle(Color.red)))
            {
                buildSceneShow = false;
            }
            GUILayout.EndHorizontal();


            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            GUILayout.Label("Total mass", GUILayout.ExpandWidth(true));
            GUILayout.Label(mass.ToString("F2") + " tons", txtR);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            GUILayout.Label("Surface TWR", GUILayout.ExpandWidth(true));
            GUILayout.Label(TWR.ToString("F2"), txtR);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            GUILayout.Label("Part count", GUILayout.ExpandWidth(true));
            GUILayout.Label(partCount.ToString(), txtR);
            GUILayout.EndHorizontal();

            doStagingAnalysisGUI();

            GUILayout.EndVertical();

            base.WindowGUI(windowID);
        }


        protected void doStagingAnalysisGUI()
        {
            GUIStyle txtR = new GUIStyle(GUI.skin.label);
            txtR.alignment = TextAnchor.UpperRight;

            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            GUILayout.Label("Staging analysis:", GUILayout.ExpandWidth(true));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("Stage");
            GUILayout.EndHorizontal();
            for (int stage = timePerStageAtmo.Length - 1; stage >= 0; stage--)
            {
                if (timePerStageAtmo[stage] > 0)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    GUILayout.Label(String.Format("{0:0}", stage), txtR);
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("TWR");
            GUILayout.EndHorizontal();
            for (int stage = timePerStageAtmo.Length - 1; stage >= 0; stage--)
            {
                if (timePerStageAtmo[stage] > 0)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    GUILayout.Label(String.Format("{0:0.00}", twrPerStage[stage]), txtR);
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("Atmo. Δv");
            GUILayout.EndHorizontal();
            for (int stage = timePerStageAtmo.Length - 1; stage >= 0; stage--)
            {
                if (timePerStageAtmo[stage] > 0)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    GUILayout.Label(String.Format("{0:0} m/s", deltaVPerStageAtmo[stage]), txtR);
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("T");
            GUILayout.EndHorizontal();
            for (int stage = timePerStageAtmo.Length - 1; stage >= 0; stage--)
            {
                if (timePerStageAtmo[stage] > 0)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    GUILayout.Label(formatTime(timePerStageAtmo[stage]), txtR);
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("Vac. Δv");
            GUILayout.EndHorizontal();
            for (int stage = timePerStageAtmo.Length - 1; stage >= 0; stage--)
            {
                if (timePerStageAtmo[stage] > 0)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    GUILayout.Label(String.Format("{0:0} m/s", deltaVPerStageVac[stage]), txtR);
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("T");
            GUILayout.EndHorizontal();
            for (int stage = timePerStageAtmo.Length - 1; stage >= 0; stage--)
            {
                if (timePerStageAtmo[stage] > 0)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    GUILayout.Label(formatTime(timePerStageVac[stage]), txtR);
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndVertical();

            GUILayout.EndHorizontal();
        }


        static String formatTime(float seconds)
        {
            if (seconds < 300)
            {
                return String.Format("{0:0} s", seconds);
            }
            else if (seconds < 3600)
            {
                int minutes = (int)(seconds / 60);
                float remainingSeconds = seconds - 60 * minutes;
                return String.Format("{0:0}:{1:00}", minutes, remainingSeconds);
            }
            else if (seconds < 3600 * 24)
            {
                int hours = (int)(seconds / 3600);
                int minutes = (int)((seconds - 3600 * hours) / 60);
                float remainingSeconds = seconds - 3600 * hours - 60 * minutes;
                return String.Format("{0:0}:{1:00}:{2:00}", hours, minutes, remainingSeconds);
            }
            else
            {
                int days = (int)(seconds / (3600 * 24));
                int hours = (int)((seconds - days*3600*24) / 3600);
                int minutes = (int)((seconds - days*3600*24 - 3600 * hours) / 60);
                float remainingSeconds = seconds - days*3600*24 - 3600 * hours - 60 * minutes;
                return String.Format("{0:0}:{1:00}:{2:00}:{3:00}", days, hours, minutes, remainingSeconds);
            }
        }
    }
}
