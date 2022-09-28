public enum TColor {WHITE, BLACK};
public class Square
{
    public TColor Color { set; get; } // Either WHITE or BLACK
public int Number { set; get; } // Either a clue number or -1 (Note: A BLACK square is always -1)
// Initialize a square to WHITE and its clue number to -1 (2 marks)
 public Square(){
    this.Color = TColor.WHITE;
    this.Number = -1;
 }

public class Puzzle
{
private Square[ , ] grid;
private int N;
// Create an NxN crossword grid of WHITE squares (4 marks)

public Puzzle (int N) { 

    grid.Equals(N);
    
 }
// Randomly initialize a crossword grid with M black squares (5 marks)
public void Initialize (int M) { 
    
 }
// Number the crossword grid (6 marks)
// public void Number ( ) { … }
// Print out the numbers for the Across and Down clues (in order) (4 marks)
public void PrintClues ( ) {  }
// Print out the crossword grid including the BLACK squares and clue numbers (5 marks)
public void PrintGrid ( ) {  }
// Return true if the grid is  (à la New York Times); false otherwise (4 marks)

}

// test

 }

