# Report

Course: C# Development SS2025 (4 ECTS, 3 SWS)

Student ID: CC241023    

BCC Group: A

Name: Miloš Karapandžić

## Methodology: 
First, I created 3 stacks to represent three towers where disks will be stacked. Each stack is represented by an integer value, where smaller disks are represented by smaller numbers. All disks are initially pushed to the left tower in order so that disks are stacked from largest to smallest.

For iterative solution I used the known fact and that is that number of moves that are needed to solve the Tower of Hanoi is 2^n-1, where n represents the number of disks that we have. Based on this value, the algorithm performs set of legal moves between the towers. If the number of disks is even, the roles of the helper (Middle) and destination (Right) towers are swapped. Then I used loop to perform moves in the correct order until the puzzle is solved. 

For the recursive solution, I implemented the classic recursive algorithm. The recursive function solves the problem by moving n−1 disks from the source tower to the helper tower, then moving the largest disk to the destination tower, and finally moving the n−1 disks from the helper tower to the destination tower. Each move is performed using a helper function that ensures the move follows the Tower of Hanoi rules.

Both solutions are using the same function for moving disks, which checks if a move is valid or not before performing it.
## Additional Features
I've implemented ASCII animation that visually represents the towers and disks during execution.

## Discussion/Conclusion
One of the main challenges in this project was implementing the recursive version while making the visual animation of the towers work. Since recursive functions repeatedly call themselves, it was important to ensure that the tower states were updated and displayed correctly after every move. If I would work on this project once again, I would finish both recursive and iterative solutions and the implement the animation. Which makes total sense but it is what it is.
## Work with: 
This project was completed individually.
## Reference: 
Stack Class:
https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1?view=net-10.0
https://www.geeksforgeeks.org/c-sharp/stack-class-in-c-sharp/
YouTube tutorials:
https://www.youtube.com/watch?v=rf6uf3jNjbo