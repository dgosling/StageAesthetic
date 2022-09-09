﻿using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering.PostProcessing;

namespace StageAesthetic.Variants
{
    internal class AphelianSanctuary
    {
        public static void NearRainSanctuary(RampFog fog, ColorGrading cgrade)
        {
            fog.fogColorStart.value = new Color32(94, 105, 178, 45);
            fog.fogColorMid.value = new Color32(116, 98, 178, 95);
            fog.fogColorEnd.value = new Color32(149, 92, 179, 170);
            cgrade.colorFilter.value = new Color32(133, 148, 178, 40);
            cgrade.colorFilter.overrideState = true;
            fog.skyboxStrength.value = 0.2f;
            var sunLight = GameObject.Find("Directional Light (SUN)").GetComponent<Light>();
            sunLight.color = new Color32(178, 142, 151, 255);
            sunLight.intensity = 1.3f;
            var fog1 = GameObject.Find("HOLDER: Cards");
            fog1.SetActive(false);
            var fog2 = GameObject.Find("DeepFog");
            fog2.SetActive(false);
        }

        public static void SunriseSanctuary(RampFog fog, ColorGrading cgrade)
        {
            fog.fogColorStart.value = new Color32(165, 109, 18, 65);
            fog.fogColorMid.value = new Color32(163, 76, 17, 145);
            fog.fogColorEnd.value = new Color32(163, 96, 115, 235);
            cgrade.colorFilter.value = new Color32(255, 255, 255, 65);
            cgrade.colorFilter.overrideState = true;
            var sun = GameObject.Find("Sun");
            sun.transform.localPosition = new Vector3(743, 500, -127);
            var sunLight = GameObject.Find("Directional Light (SUN)").GetComponent<Light>();
            sunLight.color = new Color32(255, 239, 211, 255);
            sunLight.intensity = 2f;
            sunLight.shadowNormalBias = 0.92f;
            var fog1 = GameObject.Find("HOLDER: Cards");
            fog1.SetActive(false);
            var fog2 = GameObject.Find("DeepFog");
            fog2.SetActive(false);
        }

        public static void NightSanctuary(RampFog fog, ColorGrading cgrade)
        {
            fog.fogColorStart.value = new Color32(36, 89, 146, 45);
            fog.fogColorMid.value = new Color32(21, 58, 131, 125);
            fog.fogColorEnd.value = new Color32(0, 0, 71, 255);
            cgrade.colorFilter.value = new Color32(20, 20, 160, 13);
            cgrade.colorFilter.overrideState = true;
            fog.skyboxStrength.value = 0f;
            var sunLight = GameObject.Find("Directional Light (SUN)").GetComponent<Light>();
            sunLight.color = new Color32(255, 255, 255, 255);
            sunLight.intensity = 3.5f;
            var fog1 = GameObject.Find("HOLDER: Cards");
            fog1.SetActive(false);
            var fog2 = GameObject.Find("DeepFog");
            fog2.SetActive(false);
        }

        public static void AbyssalSanctuary(RampFog fog)
        {
            Debug.Log("fog zero is " + fog.fogZero.value);
            Debug.Log("fog one is " + fog.fogOne.value);
            fog.fogColorStart.value = new Color32(102, 40, 64, 50);
            fog.fogColorMid.value = new Color32(89, 56, 65, 115);
            fog.fogColorEnd.value = new Color32(104, 32, 23, 255);
            fog.skyboxStrength.value = 0f;
            var sunLight = GameObject.Find("Directional Light (SUN)").GetComponent<Light>();
            sunLight.color = new Color32(255, 230, 198, 255);
            sunLight.intensity = 1.4f;
            var fog1 = GameObject.Find("HOLDER: Cards");
            fog1.transform.position = new Vector3(0f, 48f, 0f);
            var fog2 = GameObject.Find("DeepFog");
            // fog2.transform.position = new Vector3(-110.1f, -65f, -150f);
            var sun = GameObject.Find("Sun");
            sun.SetActive(false);
            var meshList = Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
            var stupidList = Object.FindObjectsOfType(typeof(SkinnedMeshRenderer)) as SkinnedMeshRenderer[];
            var terrainMat = Addressables.LoadAssetAsync<Material>("RoR2/Base/dampcave/matDCTerrainWalls.mat").WaitForCompletion();
            var terrainMat2 = Object.Instantiate(Addressables.LoadAssetAsync<Material>("RoR2/Base/dampcavesimple/matDCBoulder.mat").WaitForCompletion());
            terrainMat2.color = new Color32(134, 134, 134, 255);
            var detailMat = Addressables.LoadAssetAsync<Material>("RoR2/Base/Titan/matTitanGold.mat").WaitForCompletion();
            var detailMat2 = Addressables.LoadAssetAsync<Material>("RoR2/Base/dampcave/matDCTerrainGiantColumns.mat").WaitForCompletion();
            var cloud = GameObject.Find("Cloud3");
            cloud.GetComponent<MeshRenderer>().sharedMaterial = terrainMat2;
            cloud.transform.localPosition = new Vector3(-22.8f, -70f, 46.7f);
            foreach (MeshRenderer mr in meshList)
            {
                var meshBase = mr.gameObject;
                var meshParent = meshBase.transform.parent;
                if (meshBase != null)
                {
                    if (meshParent != null)
                    {
                        if (meshParent.name.Contains("TempleTop") && meshBase.name.Contains("RuinBlock"))
                        {
                            mr.sharedMaterial = terrainMat;
                        }
                    }
                    if (meshBase.name.Equals("Terrain"))
                    {
                        var sharedMaterials = mr.sharedMaterials;
                        for (int i = 0; i < mr.sharedMaterials.Length; i++)
                        {
                            sharedMaterials[i] = detailMat2;
                        }
                        mr.sharedMaterials = sharedMaterials;
                    }
                    if (meshBase.name.Contains("Platform") || (meshBase.name.Contains("Terrain") && !meshBase.name.Equals("Terrain")) || meshBase.name.Contains("Temple") || meshBase.name.Contains("Bridge") || meshBase.name.Contains("Dirt"))
                    {
                        var sharedMaterials = mr.sharedMaterials;
                        for (int i = 0; i < mr.sharedMaterials.Length; i++)
                        {
                            sharedMaterials[i] = terrainMat;
                            if (i == 1)
                            {
                                sharedMaterials[i] = terrainMat2;
                            }
                        }
                        mr.sharedMaterials = sharedMaterials;
                    }
                    bool biggerProps = meshBase.name.Contains("CirclePot") || meshBase.name.Contains("BrokenPot") || meshBase.name.Contains("Planter") || meshBase.name.Contains("AW_Cube") || meshBase.name.Contains("Mesh, Cube") || meshBase.name.Contains("AncientLoft_WaterFenceType") || meshBase.name.Contains("Tile") || meshBase.name.Contains("Rock") || meshBase.name.Contains("Pillar") || meshBase.name.Contains("Boulder") || meshBase.name.Contains("Step") || meshBase.name.Equals("LightStatue") || meshBase.name.Equals("LightStatue_Stone") || meshBase.name.Equals("FountainLG") || meshBase.name.Equals("Shrine") || meshBase.name.Equals("Sculpture");
                    if (meshBase.name.Contains("Pebble") || meshBase.name.Contains("Rubble") || biggerProps)
                    {
                        mr.sharedMaterial = detailMat;
                    }
                    if (meshBase.name.Contains("CircleArchwayAnimatedMesh"))
                    {
                        var sharedMaterials = mr.sharedMaterials;
                        for (int i = 0; i < mr.sharedMaterials.Length; i++)
                        {
                            sharedMaterials[i] = terrainMat;
                            if (i == 1)
                            {
                                sharedMaterials[i] = detailMat;
                            }
                        }
                        mr.sharedMaterials = sharedMaterials;
                    }
                    if (biggerProps)
                    {
                        var light = meshBase.AddComponent<Light>();
                        light.color = new Color32(249, 212, 96, 255);
                        light.intensity = 10f;
                        light.range = 30f;
                    }
                    if (meshBase.name.Contains("SunCloud"))
                    {
                        meshBase.SetActive(false);
                    }
                }
            }
            foreach (SkinnedMeshRenderer smr in stupidList)
            {
                var meshBase = smr.gameObject;
                if (meshBase != null)
                {
                    bool biggerProps = meshBase.name.Contains("CirclePot") || meshBase.name.Contains("Planter") || meshBase.name.Contains("AW_Cube") || meshBase.name.Contains("Mesh, Cube") || meshBase.name.Contains("AncientLoft_WaterFenceType") || meshBase.name.Contains("Tile") || meshBase.name.Contains("RuinBlock") || meshBase.name.Contains("Rock") || meshBase.name.Contains("Pillar") || meshBase.name.Contains("Boulder") || meshBase.name.Contains("Step") || meshBase.name.Equals("LightStatue") || meshBase.name.Equals("LightStatue_Stone") || meshBase.name.Equals("FountainLG") || meshBase.name.Equals("Shrine") || meshBase.name.Equals("Sculpture");
                    if (meshBase.name.Contains("Pebble") || meshBase.name.Contains("Rubble") || biggerProps)
                    {
                        smr.sharedMaterial = detailMat;
                    }
                    if (biggerProps)
                    {
                        var light = meshBase.AddComponent<Light>();
                        light.color = new Color32(249, 212, 96, 255);
                        light.intensity = 10f;
                        light.range = 30f;
                    }
                }
            }
        }
    }
}