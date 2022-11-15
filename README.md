# Dungeons and Dragons Online
## Overview
Dungeons and Dragons Online brings the popular tabletop game to the computer and the computer is the dungeon master. It is a two-dimensional, top down, multiplayer video game made with the Unity game engine. The focus of the game is on the combat between the players and the enemies they encounter. Each player will control their own character and as a team they will have to work together to make it through a dungeon by defeating enemies and avoiding traps. Once the final boss is defeated the players win. Each player will have a class they can choose that will give them special attributes and will determine how they will deal damage to enemies. The classes will be a warrior that attacks with a sword, an archer that can attack enemies from afar with their bow, and a mage that can use their healing abilities to heal other players. Dungeons will have the option to be procedurally generated so the layout, traps and enemies are always different. The game also has a player versus player combat arena, where users can battle it out to become the last one standing.
## Testing Document

Check out the QA_Acceptance_Testing_Document.xlsx to see the full document. You can also click the link below if you dont want to download the entire project.

[Link to Download The QA Testing Document Excel File](https://github.com/Capstone-Projects-2022-Fall/capstone-project-dungeons-and-dragons-online/files/10008901/QA_Acceptance_Testing_Document.xlsx)

<img width="707" alt="image" src="https://user-images.githubusercontent.com/78548481/201815674-03a08a56-9181-4e3d-a801-6d7e0cd5e423.png">
<img width="683" alt="image" src="https://user-images.githubusercontent.com/78548481/201815711-80ffff8d-5f80-43fc-91df-7027ed76bac7.png">

## GitHub Release
A link to your tagged release on GitHub. The release should have this information attached:

####  New features
- Players can now enter a randomly generated dungeon and the PVP arena
- Both the dungeon and the pvp arena have music
- ESC key will open the pause menu

#####  All features
- Players can join games using room codes
- Users can join ongoing games
- The host can leave a game and a new player will be given the host role
- The dungeon randomly generates
- Players can attack with a basic sword slash
- Users can lose their health and die

####  Known bugs/limitations
- Issues with blank prefabs in randomly generated dungeons prevalent.
- Photon still giving issues with custom character synchronization.
- Chat box needs to be implemented into the three scenes and removed from player prefab to deal with rotation
- Item and Enemy spawning in dungeon must be implemented and PVP Win Condition needs to be set
- Players cannot currently leave the dungeon or PVP arena once they enter, they need to restart the game to go to the main hub again
- Pause menu only works on main hub map

####  How to build and run the project
- Step 1: Download the project
- Step 2: Click the folder that is for your operating system
- Step 3: Start the "Dungeons and Dragons" executable
