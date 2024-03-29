# Inventory to Base

Allows the user to move items from a container directly to the base.
This is similar to the "Take out all items" button, but the user can chose single items.

To use, hold the Shift key while moving cards from a container or the character's equipped items.  

A container is a satchel, bag, basket, etc.

# Installation 
This section describes how to manually install the mod.

If using the Vortex mod manager from NexusMods, these steps are not needed.  

## Overview
This mod requires the BepInEx mod loader.

## BepInEx Setup
If BepInEx has already been installed, skip this section.

Download BepInEx from https://github.com/BepInEx/BepInEx/releases/download/v5.4.21/BepInEx_x64_5.4.21.0.zip

* Extract the contents of the BepInEx zip file into the game's directory:
```<Steam Directory>\steamapps\common\Card Survival Tropical Island```

    __Important__:  The .zip file *must* be extracted to the root folder of the game.  If BepInEx was extracted correctly, the following directory will exist: ```<Steam Directory>\steamapps\common\Card Survival Tropical Island\BepInEx```.  This is a common install issue.

* Run the game.  Once the main menu is shown, exit the game.
    
* In the BepInEx folder, there will now be a "plugins" directory.

## Mod Setup
* Download the InventoryToBase.zip.  
    * If on Nexumods.com, download from the Files tab.
    * Otherwise, download from https://github.com/NBKRedSpy/CardSurvival-InventoryToBase/releases/

* Extract the contents of the zip file into the ```BepInEx/plugins``` folder.

* Run the Game.  The mod will now be enabled.

# Uninstalling

## Uninstall
This resets the game to an unmodded state.

Delete the BepInEx folder from the game's directory
```<Steam Directory>\steamapps\common\Card Survival Tropical Island\BepInEx```

## Uninstalling This Mod Only

This method removes this mod, but keeps the BepInEx mod loader and any other mods.

Delete the ```InventoryToBase.dll``` from the ```<Steam Directory>\steamapps\common\Card Survival Tropical Island\BepInEx\plugins``` directory.
# Compatibility
Safe to add and remove from existing saves.

# Acknowledgements
Icons from:

[Sack icons created by Freepik - Flaticon](https://www.flaticon.com/free-icons/sack)

[Pile icons created by Ahmad Roaayala - Flaticon</a>](https://www.flaticon.com/free-icons/pile)

# Change Log
## 1.1.0
* v1.04 compatibility.
* Fixed compatibility issue with v1.04.
* Internal: Simplified code to only run when shift is pressed, otherwise use game's origional.
* Internal: Patched code is now identical to game's version minus slot target.

## 1.0.1
Changed the mod's move to match the game's Remove All calls.
