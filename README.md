# Quartzified / C# Utility DLL



This repository contains the Official open source project for the Quartzified [Universal, Unity] Library, which is brought to you by Quartzi and ToasterBirb.

<hr>

### The Project

This Project was made for the convenience of having functions that we use often in one DLL and not having to write them every time.



## Universal

The Universal DLL is compiled with the .Net 2.0 standalone which is compatible with:

- Windows
- Mac
- Linux
- IOS?
- Android?

What ever .Net 2.0 standalone runs on.



## Unity

Requires UnityEngine.dll & UnityEngine.UI.dll to be in your project.
(The UnityEngine.UI.dll is now seperate from UnityEngine.dll & and is available through the package manager!)


The Unity DLL is compiled with the .Net 4.72 Framework which is compatible with:

- Windows

When using this DLL make sure you set your target .Net to 4.x 
If you use 2.0 your project will require ages to compile script changes... etc.

We currently do not seem to have access to some of the UnityEngine "directories" such as UI and EventSystems, which currently does not allow us to create UI checks & Input and Touch calls for mobile or such.

<hr>

### Production of Universal

Universal gets all the functions and methods from Quartzified-Unity by only taking none unity tagged methods and compiling it into its own library.
