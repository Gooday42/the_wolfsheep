//using UnityEngine;

 using UnityEngine;

public class DaysManager : MonoBehaviour {
   
   public static DaysManager instance;

   public static int Days = 0;
   public static int Nights = 0;
   public static int Deaths =0;
   
   public delegate void OnDayChange();

   public static OnDayChange NewDay;
   /// <summary>
   /// Awake is called when the script instance is being loaded.
   /// </summary>
   void Awake()
   {
       if(instance == null) instance = null;
   }


}
