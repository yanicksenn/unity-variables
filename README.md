# Unity Variables
This variables package is based on the idea of Ryan Hipple.

## Add package
1. Open "Package Manager"
2. Choose "Add package from git URL..."
3. Use the HTTPS URL of this repository
   `https://github.com/yanicksenn/unity-variables.git`
4. Click "Add"

## Usage

### Variable references in script
There is a variety of prepared variable references that you can individually reference in your scripts.

- `FloatReference`
- `IntReference`
- `BoolReference`
- `StringReference`
- `Vector2Reference`
- `Vector3Reference`
- `QuaternionReference`

The underlying value can be accessed through getter and setter.

```c#
using CraipaiGames.Variables.Bools;
using CraipaiGames.Variables.Floats;
using UnityEngine;

public class MyBehaviour : MonoBehaviour
{
    [SerializeField]
    private FloatReference myFloat;
    
    [SerializeField]
    private BoolReference myBoolWithDefaultValue = new BoolReference(true);

    void Update()
    {
        if (myBoolWithDefaultValue.Value)
        {
            Debug.Log(myFloat.Value);
        }
    }
}
```
There is a specific property drawer for each of those variable references. Each of those drawers provides input fields for the constant and the variable value and it is possible to choose freely which of those inputs should currently be accessible.

![Using variable references](./Documentation/using-variable-references.gif)

### Variables in editor
For each variable reference it is possible to create a variable (`ScriptableObject`) that can be assigned through the asset menu.

![Create and assign variables](./Documentation/create-assign-variables.gif)

### Create custom variable

#### Data
Start by defining a data class. It is important that this `class` or `struct` is annotated with `Serializable`.
```c#

// Arbitrary data object 
[Serializable]
 public struct Character
 {
     public string name;
     public int age;
     public float height;
     public BoolReference alive;
     public Pet pet;
 }
 
 // Arbitrary example of a nested object
 [Serializable]
 public class Pet
 {
     public string name;
     public int age;
     public BoolReference alive;
 }
```

#### Variable
Create a variable class by extending from `AbstractVariable` (inherits from `ScriptableObject`). This is just boilerplate code.
```c#
[CreateAssetMenu(
     menuName = Variables.RootMenu + "/Create Character variable ...",
     fileName = "Character")]
 public class CharacterVariable : AbstractVariable<Character> { }
```

#### Reference
Create a reference class by extending from `AbstractReference`. This is just boilerplate code. It is possible to provide a default constant value inside of the constructor.
```c#
[Serializable]
public class CharacterReference : AbstractReference<Character, CharacterVariable>
{
    public CharacterReference(Character defaultConstantValue) : base(defaultConstantValue) { }
}
```

#### Drawer
Create a drawer class by extending from `AbstractSimpleReferenceDrawer`. This is just boilerplate code.
```c#
[CustomPropertyDrawer(typeof(CharacterReference))]
public class CharacterReferenceDrawer : AbstractSimpleReferenceDrawer { }
```

#### Example in inspector

Editing the variable in the inspector
![Editing the variable](./Documentation/custom-variable.png)

Editing the constant in the inspector
![Editing the constant](./Documentation/custom-constant.png)
