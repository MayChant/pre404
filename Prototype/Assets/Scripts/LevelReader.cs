using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelReader{
    /// <summary>
    /// This class is used to parse data of a level from a json file.
    /// </summary>

    // Initial board parameters
    public int board_x, board_y;
    // Player initial position
    public int player_x, player_y;
    // Door initial position
    public int door_x, door_y;
    // Lurker initial position
    public int lurker_x, lurker_y;
    // TODO: After more objects are added, store the positions of the items as private
    // int[], as duplicates are allowed e.g. private int[] spikes = [0,7,9].

    public static LevelReader CreateFromJSON(string filepath)
    {
        // Load the Json string from given filepath
        string levelJson = Resources.Load<TextAsset>(filepath).text;
        return JsonUtility.FromJson<LevelReader>(levelJson);
    }

}
