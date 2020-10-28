using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveDataRepository
{
    private readonly IData<SerializableGameObject> _data;

    private const string _folderName = "dataSave";
    private const string _fileName = "data.bat";
    private readonly string _path;

    public SaveDataRepository()
    {
        if (WalletManager.instance.GetTypeSave() == TypeSave.Pref)
        {
            _data = new PlayerPrefsData();
        }
        else if (WalletManager.instance.GetTypeSave() == TypeSave.File)
        {
            _data = new JsonData<SerializableGameObject>();
        }
        else if (WalletManager.instance.GetTypeSave() == TypeSave.Binary)
        {
            _data = new BinarySerializationData<SerializableGameObject>();
        }

        _path = Path.Combine(Application.dataPath, _folderName);

    }

    public void Save()
    {
        if (!Directory.Exists(Path.Combine(_path)))
        {
            Directory.CreateDirectory(_path);
        }
        var balans = new SerializableGameObject
        {
            Money = WalletManager.instance.GetBalans(TypeBalans.Money),
            Crystal = WalletManager.instance.GetBalans(TypeBalans.Crystal)
        };

        _data.Save(balans, Path.Combine(_path, _fileName));
    }

    public void LoadAll()
    {
        var file = Path.Combine(_path, _fileName);
        if (!File.Exists(file)) return;
        var newBalans = _data.Load(file);
        WalletManager.instance.SetBalans(TypeBalans.Money, newBalans.Money);
        WalletManager.instance.SetBalans(TypeBalans.Crystal, newBalans.Crystal);
    }

   
}