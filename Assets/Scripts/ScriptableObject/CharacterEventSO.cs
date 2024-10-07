using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/CharacterEventSO")]
public class CharacterEventSO : ScriptableObject
{
   public UnityAction<Character>OnEventRaised;

   public void RaiseEvent(Character character)
   {
           OnEventRaised?.Invoke(character);
   }

   public UnityAction<Character_Player>OnEventRaised_Player;

   public void RaiseEvent(Character_Player character)
   {
           OnEventRaised_Player?.Invoke(character);
   }
}
