using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletManager : MonoBehaviour
{
    #region Singleton
    public static WalletManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance found!");
            return;
        }
        instance = this;
    }
    #endregion

    [SerializeField] WalletUI _walletUI;
    [SerializeField] TypeSave _typeSave;
 
    public SaveDataRepository SaveDataRepository { get; private set; }

    private int money, crystal;


    public TypeSave GetTypeSave()
    {
        return _typeSave;
    }
    
    public void ResetBalansMoney()
    {
        ResetBalans(TypeBalans.Money);
    }

    public void ResetBalansCrystal()
    {
        ResetBalans(TypeBalans.Crystal);
    }

    public void LoadBalans()
    {
        SaveDataRepository.LoadAll();
    }

    public void SaveBalans()
    {
        SaveDataRepository.Save();
    }

    private void ResetBalans(TypeBalans type)
    {
        switch (type)
        {
            case TypeBalans.Money:
                {
                    _walletUI.ResetBalans(TypeBalans.Money);
                    money = 0;
                    break;
                }
            case TypeBalans.Crystal:
                {
                    _walletUI.ResetBalans(TypeBalans.Crystal);
                    crystal = 0;
                    break;
                }
        }

    }

    public int GetBalans(TypeBalans type)
    {
        switch (type)
        {
            case TypeBalans.Money:
                {
                    return money;
                }
            case TypeBalans.Crystal:
                {
                    return crystal;
                }
            default: return 0;
        }
    }

    public void SetBalans(TypeBalans type, int balans)
    {
        switch (type)
        {
            case TypeBalans.Money:
                {
                    money = balans;
                    _walletUI.SetBalans(type, balans);
                    break;
                }
            case TypeBalans.Crystal:
                {
                    crystal = balans;
                    _walletUI.SetBalans(type, balans);
                    break;
                }
            default: break;
        }
    }

    public void AddBalansMoney(int balans)
    {
        AddBalans(TypeBalans.Money, balans);
    }
    public void AddBalansCrystal(int balans)
    {
        AddBalans(TypeBalans.Crystal, balans);
    }

    private int AddBalans(TypeBalans type, int balans)
    {
        switch (type)
        {
            case TypeBalans.Money:
                {
                    money += balans;
                    _walletUI.SetBalans(TypeBalans.Money,money);
                     return money;
                }
            case TypeBalans.Crystal:
                {
                    crystal += balans;
                    _walletUI.SetBalans(TypeBalans.Crystal,crystal);
                    return crystal;
              }
          default: return 0; 
        }

    }

    public void ResetAllBalans()
    {
        foreach (TypeBalans type in Enum.GetValues(typeof(TypeBalans)))
        {
            ResetBalans(type);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        SaveDataRepository = new SaveDataRepository();

    }

}

public enum TypeBalans
{
    Money = 0,
    Crystal = 1
}

public enum TypeSave
{
    Pref = 0,
    File = 1,
    Binary = 2
}
