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
