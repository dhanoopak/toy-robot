# ToyRobotTest

## Description 

A simulation application of a toy robot moving in a 5 x 5 square tabletop. The toy robot must not fall from the table top and any such commands must be ignored.
Further valid commands should be processed. Toy robot will start its movement only after a PLACE command is issued with position and direction. Prior to this, all commands will be ignored.
The toy robot can move by one unit and can also turn left or right.

## Installation
Run the command line application placed in ToyRobotTest\ToyRobot\bin\ToyRobot.exe. 

## Approach
Development Language - Microsoft C# .Net 
Design and Architecture - OOPS
IDE used for development is Visual Studio 2019. 
Testing - TDD is followed for development. Please refer 'ToyRobotUnitTests' project to see all unit and integration test cases. 
Microsoft Test(MSTest Test Project)  is used for writing unit tests.
Unit test can be executed by opening the project in Visual studio and run the tests in ToyRobotTests.cs using Visual Studio Test Explorer.

## Usage
Use the following commands to test the toy robot application.
This application is designed to use standard input in command line. Each command should be entered and processed one by oner. 

    PLACE X,Y,F (NOTE: X and Y are positions in the range of 0 to 4. F is the direction with cardinals NORTH/SOUTH/EAST/WEST)
    MOVE
    LEFT
    RIGHT
    REPORT

    NOTE: After REPORT command, current position and direction is displayed and application will prompt to continue or exit. To continue, input 'N' and press ENTER. Otherwise press 'Y' to exit. If continued, further commands will be processed based on previous position.
