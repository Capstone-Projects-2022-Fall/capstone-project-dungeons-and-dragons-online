using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
/// <summary>
/// Stores the different characters that can be selected
/// </summary>
public class CharacterDatabase : ScriptableObject
{
    /// <summary>
    /// Stores the selectable characters
    /// </summary>
    public Character[] character;

    /// <summary>
    /// Gets the number of characters
    /// </summary>
    public int CharacterCount
    {
        get
        {
            return character.Length;
        }
    }

    /// <summary>
    /// Gets the select character based off the passed index
    /// </summary>
    public Character GetCharacter(int index)
    {
        return character[index];
    }
}
