using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections;

//my items
public enum CARDTYPE
{
    MonsterCard = 0,
    MonsterSpawned = 1,
    DefenseCard = 2,
    DefenseSpawned = 3,
    SpellCard = 4,
    SpellSpawn = 5,
}


public class CardCreator : EditorWindow {

    static string cardName = "What is the Cards Name?";
    //bool groupEnabled;
    //bool myBool = true;
    //float myFloat = 1.23f;

    //Card Creator Game Objects to access from array

    public CARDTYPE selectedCardType;

    //need to fix as it cannot be accessed through the CreateNewCard Method.
    protected InteractionMode HowToSave = InteractionMode.UserAction;

    //Add Menu item name "Card Creator: to window menu in unity
    [MenuItem ("Window/Card Creator")]

    //this is the code to store the window
    public static void ShowWindow()
    {
	   //Show existing window, if it doesn't exist create it
	   EditorWindow.GetWindow(typeof(CardCreator));

    }


    //this holds the code for the window
    void OnGUI()
    {
	   GUILayout.Label("Base Settings", EditorStyles.boldLabel);
	   cardName = EditorGUILayout.TextField("Card Name", cardName);

	   //dropDown selector for card type
	   selectedCardType = (CARDTYPE)EditorGUILayout.EnumPopup("Primitive to create:", selectedCardType);
	   if (GUILayout.Button("Create"))
		  InstantiateCardType(selectedCardType);

	   /*
	   currently not used
	   //unity code, keep for now
	   groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
	   myBool = EditorGUILayout.Toggle("Toggle", myBool);
	   myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
	   */

    }

    void InstantiateCardType(CARDTYPE selectedCardType)
    {
	   switch (selectedCardType)
	   {
		  case CARDTYPE.MonsterCard:
			 //runsfunctiontocreate the card
			 CreateCardPrefab();
			 break;
		  case CARDTYPE.MonsterSpawned:
			 CreateMonsterPrefab();
			 break;
		  case CARDTYPE.DefenseCard:
			 GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			 sphere.transform.position = Vector3.zero;
			 break;
		  case CARDTYPE.DefenseSpawned:
			 //dosomething;

			 break;
		  case CARDTYPE.SpellCard:
			 GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
			 plane.transform.position = Vector3.zero;
			 break;
		  case CARDTYPE.SpellSpawn:
			 //doSomething

			 break;
		  default:
			 Debug.LogError("Unrecognized Option");
			 break;
	   }
    }

    static void CreateCardPrefab()
    {
	   GameObject[] selectedObjects = Selection.gameObjects;

	   foreach (GameObject go in selectedObjects)
	   {
		  string localPath = "Assets/Prefabs/" + cardName + ".prefab";
		  if (AssetDatabase.LoadAssetAtPath(localPath, typeof(GameObject)))
		  {
			 if (EditorUtility.DisplayDialog("Are you sure?",
				    "The prefab already exists. Do you want to overwrite it?",
				    "Yes",
				    "No"))
			 {
				Debug.Log("Creating Prefab Now");
				CreateNewCard(go, localPath);
				CleanupGameObject(go);
			 }
		  }
		  else
		  {
			 Debug.Log(cardName + " is not a prefab, will convert");
			 CreateNewCard(go, localPath);
			 CleanupGameObject(go);
		  }
	   }
    }


    static void CreateMonsterPrefab()
    {
	   GameObject[] selectedObjects = Selection.gameObjects;

	   foreach (GameObject go in selectedObjects)
	   {
		  string localPath = "Assets/Prefabs/" + cardName + ".prefab";
		  if (AssetDatabase.LoadAssetAtPath(localPath, typeof(GameObject)))
		  {
			 if (EditorUtility.DisplayDialog("Are you sure?",
				    "The prefab already exists. Do you want to overwrite it?",
				    "Yes",
				    "No"))
			 {
				Debug.Log("Creating Prefab Now");
				CreateMonster(go, localPath);
				//CleanupGameObject(go);
			 }
		  }
		  else
		  {
			 Debug.Log(cardName + " is not a prefab, will convert");
			 CreateMonster(go, localPath);
			 //CleanupGameObject(go);
		  }
	   }
    }

    /*
    static bool ValidateCreatePrefab()
    {
	   return Selection.activeGameObject != null;
    }
    */

    static void CreateNewCard(GameObject obj, string localPath)
    {
        
       //Object prefab = PrefabUtility.SaveAsPrefabAsset(obj, localPath);
	   //set tag and components
	   obj.gameObject.tag = "Monster Card";
	   obj.AddComponent<SpriteRenderer>();
	   obj.AddComponent<BoxCollider2D>();
	   obj.AddComponent<Rigidbody2D>();
	   obj.AddComponent<SummonInfo>();

       PrefabUtility.SaveAsPrefabAssetAndConnect(obj, localPath, InteractionMode.UserAction);
	   //PrefabUtility.ReplacePrefab(obj, prefab, ReplacePrefabOptions.ConnectToPrefab);
    }

    static void CleanupGameObject(GameObject obj)
    {
	   Destroy(obj);
	   obj = new GameObject("Card Creator Object");
    }

    static void CreateMonster(GameObject obj, string localPath)
    {
	   //Object prefab = PrefabUtility.CreateEmptyPrefab(localPath);
	   //set object components such as scripts and rigidbody
	   obj.gameObject.tag = "Monster";
	   obj.AddComponent<SpriteRenderer>();
	   obj.AddComponent<BoxCollider2D>();
	   obj.AddComponent<Rigidbody2D>();
	   obj.AddComponent<SpawnCost>();
	   obj.AddComponent<MoveAndAttack>();
	   obj.AddComponent<Health>();
	   //remove tag and components from the game object in the world
	   obj.gameObject.tag = null;
	   Destroy(obj.GetComponent<SpriteRenderer>());
	   Destroy(obj.GetComponent<BoxCollider2D>());
	   Destroy(obj.GetComponent<Rigidbody2D>());
	   Destroy(obj.GetComponent<SpawnCost>());
	   Destroy(obj.GetComponent<MoveAndAttack>());
	   Destroy(obj.GetComponent<Health>());

       PrefabUtility.SaveAsPrefabAssetAndConnect(obj, localPath, InteractionMode.UserAction);
    }
}
