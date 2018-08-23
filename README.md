## COMP313 ASSIGNMENT 2 - WASEEM KOYA

### Setup

* To export the game into Unity3D, simply clone the repository, open Unity3D and open the cloned repository.
* To play the game on Windows, extract the Demo.zip file and run the unity exe file.
* To play on Mac extract the GameDemoExecutable.zip in the blackboard submission and run the Mac app.
* The windows exe file to play the game is also in GameDemoExecutable.zip in the blackboard submission.

### How to play

Control the characters movement with WASD keys. Hold Left Shift to sprint and press Space Bar to jump. Press C to shrink and enlarge character.

### Achitecture

The game is a basic 3D platformer. The idea is to get from the the start to the goal while navigating through different obstacles. These obstacles include moving platforms, jump pads, hiding from AI and triggering scripted events. 

The AI will follow the player once they are within a certain radius and stop following the player when they are hiding in the red bushes. If the AI reaches the player, the player will respawn at the nearest respawn point. Also if the player falls of the map, they will restart at the nearest spawn point. This makes the game less frustrating as you don't need to restart the whole game every time you die.

The most difficult part of the game design was creating game mechanics that was both fun and not extremely tedious to play. For 3D platformers, you do not want to be unforgiving if players make a small mistake. This makes the game too hard and too frustrating to play. But on the other end, if it is too easy, it is simply a boring game. It is hard to get the right balance. 

I tried to create the game mechanics so that it got a balance so that it is fun and not too easy. This meant that the mechanics of the game was kept rather simple. I felt this was a good design decision as it leaves room for more advanced mechanics to be implemented in further levels when the player has become more accustomed to the controls.

## COMP313 ASSIGNMENT 1 - WASEEM KOYA

### NavMesh and NavMeshAgents

Demonstration Video: https://www.youtube.com/watch?v=qUKFnCMWaek

Contents of the demonstration video are found inside of the SampleScene.

Scripts Used (found inside Assets/Scripts/Old Scripts):
* CameraController.cs
* EnemyController.cs
* NPCPatrolPath.cs
* PlayerController.cs
* Waypoint.cs

#### Background

Before the use of NavMeshs, developers would need to manually create and determine inputs and areas of how AI can navigate through a scene and manually need to create obstacle avoidance. Now with NavMeshs, this is all done for the developer. It is only a matter of tweaking settings to change how AI navigates and pathfinds in different circumstances.  

#### Details of Approach

NavMesh is an inbuilt Unity tool where AI pathfinding is made easy. It is simple in the fact that mostly everything is set up to work internally and only a few settings need to be tweaked to get it to work with specifc scenarios. 

#### Optional variations

Developers still have the option to create custom AI pathfinding and navigation, however it is seen as a very inefficient use of time. Unless you want to create an enitrely custom AI pathfinding, then it is not a good idea to do so.  

There are other developers who have created pathfinding implementations and uploaded them to the Unity store. A popular one is the A* Pathfinding Project Pro. However, it costs $100, so unless there is a specific need for that asset, the NavMesh would be a better choice.

### Sources

* Search terms: NavMesh, NavMeshAgent, Unity3D AI following, Unity3D AI patrolling
* Unity docs: https://docs.unity3d.com/Manual/nav-BuildingNavMesh.html
* Character controller: https://www.youtube.com/watch?v=h2d9Wc3Hhi0&list=PLiyfvmtjWC_V_H-VMGGAZi7n5E0gyhc37
* AI following: https://www.youtube.com/watch?v=xppompv1DBg
* AI patrolling: https://www.youtube.com/watch?v=8_zTQsYFwf0
