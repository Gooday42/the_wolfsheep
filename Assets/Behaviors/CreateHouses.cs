// using System;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEngine;

// public class CreateHouses : MonoBehaviour
// {
//     [SerializeField] public int Citizents;
//     [SerializeField] public float radius = 3.0f;
//     [SerializeField] public List<GameObject> citizents;
//     [SerializeField] public GameObject Roles;
//     public List<GameObject> AllCitizens = new();
//     public List<string> Names = new();
//     private void Awake()
//     {
//         // Instantiate citizens in a circular arrangement
//         for (int i = 0; i < Citizents; i++)
//         {
//             Vector3 position = new Vector3(
//                 Mathf.Cos(2 * Mathf.PI * i / Citizents) * radius,
//                 1,  
//                 Mathf.Sin(2 * Mathf.PI * i / Citizents) * radius
//                 );
           
//             GameObject danielTheTigger = Instantiate(getRandomCitizen(citizents));
//             danielTheTigger.transform.position = position;
//             danielTheTigger.name = Names[UnityEngine.Random.Range(0,Names.Count)];
//             AllCitizens.Add(danielTheTigger);
//         }
//         AssignRoles();
//         AssigNeighbors();
//         FindAnyObjectByType<VirginaWolf>().AssignWolves();

//     }

//   private void AssignRoles()
// {
//     int attempts = 0;
//     int maxAttempts = AllCitizens.Count * 2; // Safety limit to prevent infinite loops

//     while (Roles.transform.childCount > 0 && attempts < maxAttempts)
//     {
//         GameObject citizen = AllCitizens[UnityEngine.Random.Range(0, AllCitizens.Count)];
        
//         if (!citizen.GetComponent<Citizen>().IsWolf && citizen.transform.childCount < 2)
//         {
//             GameObject role = Roles.transform.GetChild(0).gameObject;
//             role.transform.SetParent(citizen.transform); // Assign role as child
//         }

//         attempts++;
//     }
// }




//     private void AssigNeighbors()
//     {
//         // Assign neighbors after all citizens are instantiated
//         for (int i = 0; i < AllCitizens.Count; i++)
//         {
//             Citizen currentCitizen = AllCitizens[i].GetComponent<Citizen>();

//             switch (currentCitizen.thisCitizenPersonality)
//             {
//                 case Citizen.personality.Indiferent:
//                 case Citizen.personality.Nervous:
//                 case Citizen.personality.Unpredictable:
//                     AddNeighborSafely(currentCitizen, i + 1);
//                     AddNeighborSafely(currentCitizen, i - 1);
//                     break;

//                 case Citizen.personality.Sharp:
//                     AddNeighborSafely(currentCitizen, i + 1);
//                     AddNeighborSafely(currentCitizen, i + 2);
//                     AddNeighborSafely(currentCitizen, i - 1);
//                     AddNeighborSafely(currentCitizen, i - 2);
//                     break;
//             }
//         }
//     }

//     private void AddNeighborSafely(Citizen citizen, int index)
//     {
//         // Handle wrapping around the list
//         if (index < 0)
//         {
//             index = AllCitizens.Count + index;  // Wrap to the end
//         }
//         else if (index >= AllCitizens.Count)
//         {
//             index %= AllCitizens.Count;  // Wrap to the beginning
//         }

//         citizen.Neigbours.Add(AllCitizens[index]);
//     }
    
//     private GameObject getRandomCitizen(List<GameObject> objs)
//     {
//         return objs[UnityEngine.Random.Range(0,objs.Count)];
//     }
// }
