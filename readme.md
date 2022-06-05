# Backend coding test

You are tasked with building an API to simulate space exploration robots on different planets. Your API must support adding and removing robots and sending commands to them. All robots have an assigned area on a planet (a 2D rectangle) and can receive the following commands:

- Advance: Move forward one space
- Left: Turn left on its axis
- Right: Turn right on its axis

You need to process a string of commands and indicate the final position of the robot or if it has gone out of bounds of its assigned area. These commands need to be processed for all the indicated robots in the simulator.

## Technical requirements

Your API must be implemented using the following tech stack:
-	.Net Core API 6
-	MediatR
-	Swagger

Your solution must work when run from the IDE without manual steps. Unit tests are useful but not required. Show your architecture, design and coding skills but prioritizing clear, efficient code. You are expected to use no more than 3 hours on this test

### Notes

- Simulation (aggregate root)
- Robot (entity)
  - Add and remove
- Planet (entity)
- Area (on planet) (entity)
- Commands:
  - Advance
  - Left
  - Right

Process a string of commands and indicate each robots final position (or out of bounds).

- Show if robot is out of bounds
- Better routing?
- Better design of robot in simulation in domain?
- Return links for commands
- Use MediatR differently?
