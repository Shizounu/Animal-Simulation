using UnityEngine;

using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveGameManager
{
    public static void SaveGame(){
        BinaryFormatter formatter = new BinaryFormatter();
        string Path = Application.persistentDataPath + "/Game.save";
        FileStream stream = new FileStream(Path,FileMode.Create);

        List<AnimalSave> AS = new();
        int position = 0;
        foreach (var tile in GameManager.Instance.Tiles){
            foreach (var Animal in tile.Animals)
                AS.Add(new AnimalSave(Animal.type, Animal.Count, position));
            position += 1;
        }
        formatter.Serialize(stream, AS);
        stream.Close();
    }

    public static List<AnimalSave> LoadGame(){
        string Path = Application.persistentDataPath + "/Game.save";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(Path,FileMode.Open);

        return (List<AnimalSave>)formatter.Deserialize(stream);
    }
}

[System.Serializable]
public class AnimalSave{
    public AnimalSave(int _id, int _count, int _position){
        ID = _id;
        Count = _count;
        Position = _position;
    }
    public int ID;
    public int Count;
    public int Position;
}