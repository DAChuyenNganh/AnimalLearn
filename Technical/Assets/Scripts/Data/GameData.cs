using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;

[System.Serializable]
public class AnimalInfo
{
    public string stt;
    public string nameEng;
    public string nameViet;
    public string loai;
    public string khuVucSong;
    public string kichThuoc;
    public string trongLuong;
    public string tuoiTho;
    public string thongTin;
    public AnimalInfo()
    { }

}

public class GameData : MonoBehaviour {

    public List<AnimalInfo> listAnimal;
	// Use this for initialization

    [ContextMenu("Test Load Animal")]
	public void LoadListAnimail()
    {
        LoadData(listAnimal, "Data/Animal");

    }
     [ContextMenu("Get Animal")]
    public void GetDataLion()
    {
        AnimalInfo lion = GetAnimalInfo("Lion");
        if (lion != null)
            Debug.Log("info = " + lion.thongTin);
    }
    public AnimalInfo GetAnimalInfo(string nameAnimal)
    {
        for (int i = 0; i < listAnimal.Count; i++)
        {
            if(listAnimal[i].nameEng == nameAnimal || listAnimal[i].nameViet == nameAnimal)
            {
                return listAnimal[i];
            }
        }
        return null;
    }

    public void LoadData<T>(List<T> listName, string assetPath)
    {
        if (listName != null)
        {
            listName.Clear();
        }

        TextAsset textAsset = Resources.Load<TextAsset>(assetPath);

        if (textAsset)
        {
            Type typeOfT = typeof(T);

            //cat dong
            string[] temp = textAsset.text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            //lay danh sach field cua lop
            Assembly a = Assembly.GetAssembly(typeOfT);
            FieldInfo[] fieldInfo = typeOfT.GetFields(BindingFlags.Public | BindingFlags.Instance);

            //bo dong dau tien, key
            for (int i = 1; i < temp.Length; i++)
            {
                T newObject = (T)a.CreateInstance(typeOfT.FullName);

                Debug.Log("Line " + i + " = " + temp[i]);
                string[] context = temp[i].Split(new char[] { '\t' });
                for (int j = 0; j < fieldInfo.Length; j++)
                {
                    //					try {
                    //
                    //					}catch(Exception ex) {
                    //
                    //					}
                    string collumnValue = context[j];
                    if (fieldInfo[j].FieldType == typeof(String))
                    {
                        fieldInfo[j].SetValue(newObject, collumnValue);//.Substring(1, context[j].Length));
                    }
                    else if (fieldInfo[j].FieldType == typeof(Int32))
                    {
                        int value = 0;
                        if (collumnValue.Length > 0)
                        {
                            value = Int32.Parse(collumnValue);
                        }
                        fieldInfo[j].SetValue(newObject, value);
                    }
                    else if (fieldInfo[j].FieldType == typeof(float))
                    {
                        float value = 0.0f;
                        if (collumnValue.Length > 0)
                        {
                            value = float.Parse(collumnValue);
                        }
                        fieldInfo[j].SetValue(newObject, value);
                    }
                }
                listName.Add(newObject);
            }

        }
    }

}
