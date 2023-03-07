using System.Security.AccessControl;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SavePlayer (Player player, PlayerData playerData)	
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.flap";
        PlayerData data = new PlayerData(player);

        using (FileStream stream = new FileStream(path, FileMode.Create))
        { 
            formatter.Serialize(stream, player);
        }
        
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.flap";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                return data;
            }            
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
