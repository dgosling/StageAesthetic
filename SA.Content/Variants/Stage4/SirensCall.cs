﻿using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering.PostProcessing;
using Object = UnityEngine.Object;

namespace StageAesthetic.Variants.Stage4
{
    internal class SirensCall
    {
        public static void Night(RampFog fog, ColorGrading cgrade)
        {
            Skybox.NightSky();

            var lightBase = GameObject.Find("Weather, Shipgraveyard");
            if (lightBase)
            {
                lightBase.SetActive(false);
            }
            var meshList = Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
            foreach (MeshRenderer mr in meshList)
            {
                var meshBase = mr.gameObject;
                if (meshBase != null)
                {
                    if (meshBase.name.Contains("Grass"))
                    {
                        if (mr.sharedMaterial != null)
                        {
                            mr.sharedMaterial.color = new Color32(99, 97, 63, 255);
                            if (mr.sharedMaterials.Length >= 2)
                            {
                                mr.sharedMaterials[1].color = new Color32(99, 97, 63, 255);
                            }
                        }
                    }
                    if (meshBase.name.Contains("DanglingMoss"))
                    {
                        if (mr.sharedMaterial != null)
                        {
                            mr.sharedMaterial.color = new Color32(255, 255, 255, 255);
                        }
                    }
                }
            }
        }

        public static void Sunny(RampFog fog)
        {
            fog.fogColorStart.value = new Color32(53, 66, 82, 18);
            fog.fogColorMid.value = new Color32(103, 67, 64, 154);
            fog.fogColorEnd.value = new Color32(146, 176, 255, 255);
            fog.fogOne.value = 0.2f;
            fog.fogZero.value = -0.05f;
            fog.skyboxStrength.value = 0.25f;
            var lightBase = GameObject.Find("Weather, Shipgraveyard").transform;
            var sunTransform = lightBase.Find("Directional Light (SUN)");
            Light sunLight = sunTransform.gameObject.GetComponent<Light>();
            sunLight.color = new Color32(255, 239, 223, 255);
            sunLight.intensity = 2f;
            sunLight.shadowStrength = 0.75f;
            sunTransform.localEulerAngles = new Vector3(33, 0, 0);
            var meshList = Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
            foreach (MeshRenderer mr in meshList)
            {
                var meshBase = mr.gameObject;
                if (meshBase != null)
                {
                    if (meshBase.name.Contains("Grass"))
                    {
                        if (mr.sharedMaterial != null)
                        {
                            mr.sharedMaterial.color = new Color32(99, 97, 63, 255);
                            if (mr.sharedMaterials.Length >= 2)
                            {
                                mr.sharedMaterials[1].color = new Color32(99, 97, 63, 255);
                            }
                        }
                    }
                    if (meshBase.name.Contains("DanglingMoss"))
                    {
                        if (mr.sharedMaterial != null)
                        {
                            mr.sharedMaterial.color = new Color32(255, 255, 255, 255);
                        }
                    }
                }
            }
        }

        public static void Overcast(RampFog fog)
        {
            fog.fogColorStart.value = new Color32(47, 52, 62, 75);
            fog.fogColorMid.value = new Color32(72, 80, 98, 200);
            fog.fogColorEnd.value = new Color32(90, 101, 119, 255);
            fog.skyboxStrength.value = 0.02f;
            fog.fogPower.value = 0.75f;
            fog.fogIntensity.value = 1f;
            fog.fogZero.value = -0.05f;
            fog.fogOne.value = 0.169f;

            var sunLight = GameObject.Find("Directional Light (SUN)").GetComponent<Light>();
            sunLight.color = new Color32(191, 191, 191, 255);
            sunLight.intensity = 2f;
            sunLight.shadowStrength = 0.5f;

            AddRain(RainType.Typhoon);
            var meshList = Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
            foreach (MeshRenderer mr in meshList)
            {
                var meshBase = mr.gameObject;
                if (meshBase != null)
                {
                    if (meshBase.name.Contains("Grass"))
                    {
                        if (mr.sharedMaterial != null)
                        {
                            mr.sharedMaterial.color = new Color32(99, 97, 63, 255);
                            if (mr.sharedMaterials.Length >= 2)
                            {
                                mr.sharedMaterials[1].color = new Color32(99, 97, 63, 255);
                            }
                        }
                    }
                    if (meshBase.name.Contains("DanglingMoss"))
                    {
                        if (mr.sharedMaterial != null)
                        {
                            mr.sharedMaterial.color = new Color32(255, 255, 255, 255);
                        }
                    }
                }
            }
        }

        public static void Aphelian(RampFog fog, ColorGrading cgrade)
        {
            GameObject.Find("Directional Light (SUN)").SetActive(false);

            Skybox.SunsetSky();
            fog.fogColorStart.value = new Color32(122, 69, 56, 5);
            fog.fogColorMid.value = new Color32(122, 69, 56, 35);
            fog.fogColorEnd.value = new Color32(91, 52, 42, 230);
            fog.fogIntensity.value = 1f;
            fog.fogPower.value = 0.25f;
            // cgrade.colorFilter.value = new Color32(7, 0, 140, 10);
            // cgrade.colorFilter.overrideState = true;
            fog.skyboxStrength.value = 0f;
            fog.fogOne.value = 0.085f;

            var meshList = Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
            foreach (MeshRenderer mr in meshList)
            {
                var meshBase = mr.gameObject;
                if (meshBase != null)
                {
                    if (meshBase.name.Contains("Ship"))
                    {
                        var light = meshBase.AddComponent<Light>();
                        light.color = new Color32(255, 235, 223, 255);
                        light.range = 40f;
                        light.intensity = 2.7f;
                    }
                    if (meshBase.name.Contains("Grass"))
                    {
                        if (mr.sharedMaterial != null)
                        {
                            mr.sharedMaterial.color = new Color32(83, 99, 103, 220);
                            if (mr.sharedMaterials.Length >= 2)
                            {
                                mr.sharedMaterials[1].color = new Color32(176, 124, 59, 106);
                            }
                        }
                    }
                    if (meshBase.name.Contains("DanglingMoss"))
                    {
                        if (mr.sharedMaterial != null)
                        {
                            mr.sharedMaterial.color = new Color32(232, 193, 75, 139);
                        }
                    }

                    if (meshBase.name.Contains("Hologram"))
                    {
                        if (mr.sharedMaterial != null)
                        {
                            var light = meshBase.AddComponent<Light>();
                            light.color = new Color32(251, 181, 56, 255);
                            light.range = 40f;
                            light.intensity = 15f;
                        }
                    }
                }
            }
            AphelianMaterials();
        }

        public static void AphelianMaterials()
        {
            var terrainMat = Main.sirensAphelianTerrainMat;
            var terrainMat2 = Main.sirensAphelianTerrainMat2;
            var detailMat = Main.sirensAphelianDetailMat;
            var detailMat2 = Main.sirensAphelianDetailMat2;
            var detailMat3 = Main.sirensAphelianDetailMat3;

            if (terrainMat && terrainMat2 && detailMat && detailMat2 && detailMat3)
            {
                var meshList = Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
                foreach (MeshRenderer mr in meshList)
                {
                    var meshBase = mr.gameObject;
                    var meshParent = meshBase.transform.parent;
                    if (meshBase != null)
                    {
                        if (meshParent != null)
                        {
                            if ((meshBase.name.Contains("Spikes") || meshBase.name.Contains("Stalactite") || meshBase.name.Contains("Stalagmite") || meshBase.name.Contains("Level Wall") || meshBase.name.Contains("Mesh")) && (meshParent.name.Contains("Cave") || meshParent.name.Contains("Terrain") || meshParent.name.Contains("Stalagmite")))
                            {
                                if (mr.sharedMaterial)
                                {
                                    mr.sharedMaterial = terrainMat2;
                                }
                            }
                        }
                        if (meshBase.name.Contains("Terrain") || meshBase.name.Contains("Cave") || meshBase.name.Contains("Floor"))
                        {
                            if (mr.sharedMaterial)
                            {
                                mr.sharedMaterial = terrainMat;
                            }
                        }
                        if (meshBase.name.Contains("Spikes") || meshBase.name.Contains("Stalactite") || meshBase.name.Contains("Stalagmite") || meshBase.name.Contains("Level Wall") || meshBase.name.Contains("mdlGeyser"))
                        {
                            if (mr.sharedMaterial)
                            {
                                mr.sharedMaterial = terrainMat2;
                            }
                        }
                        if (meshBase.name.Contains("Ship"))
                        {
                            if (mr.sharedMaterial)
                            {
                                mr.sharedMaterial = detailMat;
                            }
                        }
                        if (meshBase.name.Contains("Rock") || meshBase.name.Contains("Boulder"))
                        {
                            if (mr.sharedMaterial)
                            {
                                mr.sharedMaterial = detailMat2;
                            }
                        }

                        if (meshBase.name.Contains("Hologram"))
                        {
                            if (mr.sharedMaterial)
                            {
                                mr.sharedMaterial = detailMat3;
                            }
                        }
                    }
                }
            }
        }
    }
}