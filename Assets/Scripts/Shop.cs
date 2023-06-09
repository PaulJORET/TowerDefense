using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;

    private void Start() {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret() {
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }
    public void PurchaseMissileLauncher() {
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab);
    }
}
