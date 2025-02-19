
# Chess Path Finder

Chess Path Finder is a C# .NET application that simulates a chess board with pieces randomly assigned to positions. The user can input coordinates to select a piece and a target location, and the app will calculate and display a valid path for the piece to reach the destination, following traditional chess movement rules.

This app uses a backtracking algorithm to explore and find paths for different chess pieces from their starting to target positions.

## Features

- **Randomized Board Setup**: Pieces are randomly placed on the board each time the app starts.
- **Coordinate Input**: Users can input coordinates for the piece and target locations.
- **Path Calculation**: Shows a valid path for the selected piece to reach the target using chess rules.
- **Backtracking Algorithm**: Finds valid moves while adhering to movement rules for each piece.

## Getting Started

### Prerequisites

- .NET SDK 5.0 or later
- Visual Studio or any preferred C# IDE


## Usage

1. Run the application, and the board will display with pieces randomly positioned.
2. Enter the coordinates of the piece you want to move.
3. Enter the target coordinates where you want the piece to go.
4. The program will output a possible path to move the piece to the target location, if a valid path exists.

## Movement Rules

Each piece follows traditional chess movement rules:

- **Pawn**: Moves one square forward (or two if it's the pawn's first move).
- **Knight**: Moves in an "L" shape.
- **Bishop**: Moves diagonally any number of squares.
- **Rook**: Moves horizontally or vertically any number of squares.
- **Queen**: Combines the movement abilities of both the rook and the bishop.
- **King**: Moves one square in any direction.

## Algorithm Details

The backtracking algorithm operates as follows:

1. **Initialization**: The algorithm begins from the selected starting piece coordinates.
2. **Path Exploration**: At each step, it explores all possible moves based on the piece’s movement rules.
3. **Backtracking**: If a move leads to a dead-end, it backtracks and tries a different path.
4. **Solution**: When a path is found, the sequence of moves is displayed.
