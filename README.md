# Mod for Skul: The Hero Slayer

Some Modifications to make the game even more enjoyable for me.

Using [BepInEx](https://github.com/BepInEx/BepInEx) as modding framework

---

Features
===

- TurboButtonMode for basic attacks.
   - Holding down the attack button attacks as fast as possible.
   - Activate/Deactivate with F2.
- Skull drops scale with current chapter.
   - Later chapters always drop higher rarity skulls.
   - Awakened versions of skulls can drop.
- Item drops configurable to drop a higher quality item every N drops.
- Always spawn a Skull-Reward and a Item-Reward gate, if possible.
- No broken gates will be spawned, if avoidable.
- Infinite DarkQuartz to unlock upgrades. 

Compability
===
- BepInEx Version 6.0.0.549
- Skul Version 1.4.1
- Skul Unity Version 2020.1.17

Installation
===

### Install BepInEx in your Skul Root folder
Long general installation guide for BepInEx can be found [here](https://docs.bepinex.dev/master/articles/user_guide/installation/index.html).  
Shorter description for Skul below:

At the time of writing, BepInEx 6 has no stable release.  
The current builds can be found here: [BepisBuilds](https://builds.bepis.io/projects/bepinex_be).  

For Windows use: BepInEx_UnityMono_x64  
For Linux use: BepInEx_UnityMono_unix  

Extract the content of the archive into the Root folder of your Skul Installation. So that the Root folder of the game contains a "BepInEx" folder

For Windows usually: C:\Program Files\Steam\steamapps\common\Skul\
For Linux usually: /home/MyUserName/.steam/debian-installation/steamapps/common/Skul/

Linux Only:  
- modify `run_bepinex.sh` to set the `executable_name` on line 15 like this:  `executable_name="Skul.x86_64"`
- make `run_bepinex.sh` executable. To do that, run in terminal: `chmod u+x run_bepinex.sh`
- In Steam, under properties for Skul, set the Launch Options to `./run_bepinex.sh %command%`

### Install the Mod/PlugIn

Open the `Skul.Mod.csproj` and modify `SkulDirectory` to point to your Skul folder.  
Building the .net project will then build the .dll to `$(SkulDirectory)\BepInEx\plugins` where it will be automatically loaded by BepInEx

### Unstrip Unity dlls
Skul ships with stripped assemblies. ([for further reading](https://github.com/NeighTools/UnityDoorstop/issues/10#issuecomment-776921796))  
Downloading the unstripped assemblies and dropping them into `$(SkulDirectory)\Skul_Data\Managed\` fixes that (overwriting existing files as needed).  
The `Managed` folder can be backed up in case something goes wrong. Alternatively Steams "Verify integrity of game files" can be used to restore the modified files.

Long Description: [Guide by ghorsington](https://hackmd.io/@ghorsington/rJuLdZTzK)

Short Description:
- download https://unity.bepinex.dev/libraries/2020.1.17.zip and extract the content into `$(SkulDirectory)\Skul_Data\Managed\`
- go to the [Unity Download Archives](https://unity3d.com/get-unity/download/archive) and download the Unity [Editor Version 2020.1.17](https://download.unity3d.com/download_unity/9957aee8edc2/Windows64EditorInstaller/UnitySetup64-2020.1.17f1.exe) (Linux users should download the Windows Version)
- open the downloaded exe file with [7-zip](https://www.7-zip.org/) and extract `Editor/Data/MonoBleedingEdge/lib/mono/4.5` into `$(SkulDirectory)\Skul_Data\Managed\`. To extract without the 7-Zip GUI: `7z x UnitySetup64-2020.1.17f1.exe` 

### Run the game

If the mod is running correclty, pressing F1 while in the game will display a message above the player character.

Future Ideas
===

- Start in a later chapter
   - Skip lower Chapters and jump right into higher action.
   - Give some start equipment matching the new start chapter.
- Configurable random seed
   - It should be possible to give a fixed seed to the used System.Random to replay a given seed.
- Configurable starting gear
- Configurable drops for a run
- Boss rush
   - Is could be enough to postfix `StageInfo.GeneratePath` and just remove all non boss segments.   
