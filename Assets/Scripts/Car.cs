using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CarType
{
    Buggy,
    HeavyCoupe,
    LightCoupe
}

public enum Configurable
{
    CarType,
    TiresetType,
    FrontType,
    WeaponType
}

public enum TiresetType
{
    Standard,
    Spiked
}

public enum FrontType
{
    None,
    Winch,
    Spiked,
    Shunt
}

public enum WeaponType
{
    None,
    SingleBarrel,
    TwinBarrel
}

[CreateAssetMenu]
public class Car : ScriptableObject
{
    // User configurables
    [SerializeField]
    private CarType carType;
    [SerializeField]
    private TiresetType carTiresetType;
    [SerializeField]
    private FrontType carFrontType;
    [SerializeField]
    private WeaponType carWeaponType;
    [SerializeField]
    private string carPrefabStr;

    // User totals
    [SerializeField]
    private int basePriceTotal = 0;
    [SerializeField]
    private int tiresetTotal = 0;
    [SerializeField]
    private int frontTotal = 0;
    [SerializeField]
    private int weaponTotal = 0;
    [SerializeField]
    private int totalPrice = 0;


    /*********************************************************************
     * Class property getters
     *********************************************************************/
    public Object GetCarPrefab()
    {
        return Resources.Load(carPrefabStr);
    }

    public CarType GetCarType()
    {
        return carType;
    }

    public FrontType GetFrontType()
    {
        return carFrontType;
    }

    public WeaponType GetWeaponType()
    {
        return carWeaponType;
    }

    public TiresetType GetTiresetType()
    {
        return carTiresetType;
    }
    
    public int GetTotalSpend()
    {
        SetTotalSpend();
        return totalPrice;
    }

    /*********************************************************************
     * Class property setters
     *********************************************************************/

    public void SetCarBasePriceTotal(CarType carType)
    {
        basePriceTotal = (int) GetCarBasePrice(carType);
    }
    
    public void SetDefaultConfig(CarType theCarType)
    {
        switch (theCarType)
        {
            case CarType.Buggy:
                carType = CarType.Buggy;
                carTiresetType = TiresetType.Standard;
                carFrontType = FrontType.None;
                carWeaponType = WeaponType.None;
                carPrefabStr = "Prefabs/Buggy";
                totalPrice = GetTotalSpend();
                return;

            case CarType.HeavyCoupe:
                carType = CarType.HeavyCoupe;
                carTiresetType = TiresetType.Standard;
                carFrontType = FrontType.None;
                carWeaponType = WeaponType.None;
                carPrefabStr = "Prefabs/HeavyCoupe";
                totalPrice = GetTotalSpend();
                return;

            default:
                return;
        }
    }

    public void SetTireset(TiresetType tiresetType)
    {
        carTiresetType = tiresetType;
    }

    public void SetTiresetPriceTotal(TiresetType tiresetType)
    {
        switch (tiresetType)
        {
            case TiresetType.Standard:
                tiresetTotal = (int)GetCarTiresetPrice(TiresetType.Standard);
                break;

            case TiresetType.Spiked:
                tiresetTotal = (int)GetCarTiresetPrice(TiresetType.Spiked);
                break;

            default:
                break;
        }
    }

    public void SetTotalSpend()
    {
        totalPrice = basePriceTotal + tiresetTotal + frontTotal + weaponTotal;
    }

    /********************************************************************
     * Part name lookups
     ********************************************************************/
    public string GetCarFullNameAsString(CarType carType)
    {
        switch (carType)
        {
            case CarType.Buggy:
                return "Bugs Buggy";

            case CarType.HeavyCoupe:
                return "Heavy Coupe";

            case CarType.LightCoupe:
                return "Light Coupe";

            default:
                return "";
        }
    }

    public string GetTiresetNameAsString(TiresetType tiresetType)
    {
        switch (tiresetType)
        {
            case TiresetType.Standard:
                return "4x Standard Tires";

            case TiresetType.Spiked:
                return "4x Spiked Tires";

            default:
                return "";
        }
    }

    public string GetFrontNameAsString(FrontType frontType)
    {
        switch (frontType)
        {
            case FrontType.None:
                return "None";

            case FrontType.Winch:
                return "Winch";

            case FrontType.Spiked:
                return "Spiked Front";

            case FrontType.Shunt:
                return "Front Shunt";

            default:
                return "";
        }
    }

    public string GetWeaponNameAsString(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.None:
                return "None";

            case WeaponType.SingleBarrel:
                return "Single Barrel Shooter";

            case WeaponType.TwinBarrel:
                return "Twin Barrel Shooter";

            default:
                return "";
        }
    }


    /********************************************************************
     * Pricing lookups
     ********************************************************************/
    public int GetCarBasePrice(CarType carType)
    {
        switch (carType)
        {
            case CarType.Buggy:
                return 10000;

            case CarType.LightCoupe:
                return 20000;

            case CarType.HeavyCoupe:
                return 50000;

            default:
                return 0;
        }
    }

    public int GetCarTiresetPrice(TiresetType tiresetType)
    {
        switch (tiresetType)
        {
            case TiresetType.Standard:
                return 0; // FREE

            case TiresetType.Spiked:
                return (750 * 4);

            default:
                return 0;
        }
    }
}
