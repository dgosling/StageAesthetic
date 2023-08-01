﻿using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering.PostProcessing;
using Object = UnityEngine.Object;

namespace StageAesthetic.Variants.Stage4
{
    internal class SirensCall
    {
        public static void ShipNight(RampFog fog, ColorGrading cgrade)
        {
            fog.fogColorStart.value = new Color32(39, 107, 92, 0);
            fog.fogColorMid.value = new Color32(15, 62, 50, 99);
            fog.fogColorEnd.value = new Color32(4, 25, 22, 255);
            cgrade.colorFilter.value = new Color32(171, 223, 227, 255);
            cgrade.colorFilter.overrideState = true;
            fog.skyboxStrength.value = 0.8f;
            fog.fogOne.value = 0.085f;
            var lightBase = GameObject.Find("Weather, Shipgraveyard").transform;
            var sunTransform = lightBase.Find("Directional Light (SUN)");
            Light sunLight = sunTransform.gameObject.GetComponent<Light>();
            sunLight.color = new Color32(155, 163, 227, 255);
            sunLight.intensity = 2f;
            sunLight.shadowStrength = 0.5f;
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

        public static void ShipSkies(RampFog fog)
        {
            fog.fogColorStart.value = new Color32(53, 66, 82, 18);
            fog.fogColorMid.value = new Color32(64, 67, 103, 154);
            fog.fogColorEnd.value = new Color32(126, 156, 166, 255);
            var lightBase = GameObject.Find("Weather, Shipgraveyard").transform;
            var sunTransform = lightBase.Find("Directional Light (SUN)");
            Light sunLight = sunTransform.gameObject.GetComponent<Light>();
            sunLight.color = new Color32(255, 239, 223, 255);
            sunLight.intensity = 2f;
            sunLight.shadowStrength = 0.7f;
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

        public static void ShipDeluge(RampFog fog)
        {
            fog.fogColorStart.value = new Color32(58, 62, 68, 0);
            fog.fogColorMid.value = new Color32(46, 67, 76, 130);
            fog.fogColorEnd.value = new Color32(78, 94, 87, 255);
            fog.fogZero.value = -0.02f;
            fog.fogOne.value = 0.057f;

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

        public static void ShipAphelian(RampFog fog, ColorGrading cgrade)
        {
            try { ApplyAphelianMaterials(); } catch { SwapVariants.SALogger.LogError("Sirens Sanctuary: Failed to change materials, trying again..."); } finally { ApplyAphelianMaterials(); }
            fog.fogColorStart.value = new Color32(122, 69, 56, 5);
            fog.fogColorMid.value = new Color32(122, 69, 56, 35);
            fog.fogColorEnd.value = new Color32(91, 52, 42, 255);
            // cgrade.colorFilter.value = new Color32(7, 0, 140, 10);
            // cgrade.colorFilter.overrideState = true;
            fog.skyboxStrength.value = 0f;
            fog.fogOne.value = 0.085f;
            var sunLight = GameObject.Find("Directional Light (SUN)").GetComponent<Light>();
            sunLight.intensity = 1.4f;
            sunLight.shadowStrength = 0.8f;
            sunLight.color = new Color32(221, 174, 167, 255);
            sunLight.transform.eulerAngles = new Vector3(20f, 79.13635f, 97.21165f);
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
        }

        public static void ApplyAphelianMaterials()
        {
            var terrainMat = Object.Instantiate(Addressables.LoadAssetAsync<Material>("RoR2/DLC1/ancientloft/matAncientLoft_Terrain.mat").WaitForCompletion());
            terrainMat.color = new Color32(138, 176, 167, 255);
            var terrainMat2 = Object.Instantiate(Addressables.LoadAssetAsync<Material>("RoR2/DLC1/ancientloft/matAncientLoft_Temple.mat").WaitForCompletion());
            terrainMat2.color = new Color32(138, 176, 167, 255);
            var detailMat = Object.Instantiate(Addressables.LoadAssetAsync<Material>("RoR2/Base/Common/TrimSheets/matTrimSheetAlien1BossEmissionDirty.mat").WaitForCompletion());
            detailMat.color = new Color32(252, 154, 72, 235);
            var detailMat2 = Object.Instantiate(Addressables.LoadAssetAsync<Material>("RoR2/DLC1/ancientloft/matAncientLoft_StoneSurface.mat").WaitForCompletion());
            detailMat2.color = new Color32(178, 127, 68, 159);
            var detailMat3 = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/MajorAndMinorConstruct/matMajorConstructDefenseMatrixEdges.mat").WaitForCompletion();
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