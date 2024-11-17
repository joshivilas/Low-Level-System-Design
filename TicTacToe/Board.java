package LowLevelDesign.TicTacToe;

import java.util.List;
import java.util.Scanner;

public class Board {
    int size;
    int[][] board;
    List<Player> players;
    int currentTurn;
    Scanner scanner;

    public Board(int size, List<Player> players, Scanner scanner) {
        this.size = size;
        this.board = new int[size][size];
        this.players = players;
        this.currentTurn = 1;
        this.scanner = scanner;
    }

    public void playGame() {
        while (!isComplete()) {
            printBoard();
            System.out.println("Move of player : " + this.currentTurn + "... Please Enter cell numbers");
            int x = scanner.nextInt();
            int y = scanner.nextInt();
            this.board[x][y] = this.currentTurn;

            // change the turn after players turn
            if (this.currentTurn == 1) {
                this.currentTurn = 2;
            } else {
                this.currentTurn = 1;
            }

        }
        if (isComplete() == true) {
            int winner = anyWinner();
            if (winner == 3) {
                // draw
                System.out.println("Match is Draw. Nice Fight!");
            } else {
                System.out.println("Winner is player: " + players.get(anyWinner()) + "...");
            }
        }
    }

    public void printBoard() {

        System.out.println("--------------------------------");

        for (int i = 0; i < this.size; i++) {
            for (int j = 0; j < this.size; j++) {
                if (board[i][j] == 0) {
                    System.out.print("__\t");
                } else if (board[i][j] == 1) {
                    System.out.print("X \t");
                } else if (board[i][j] == 2) {
                    System.out.print("Y \t");
                }
            }
            System.out.println(" \t");

        }
    }

    private boolean isComplete() {
        // check if any cell is 0
        // for (int i = 0; i < this.size; i++)
        // for (int j = 0; j < this.size; j++)
        // if (this.board[i][j] == 0)
        // return false;

        if (anyWinner() != 0) {
            return true;
        } else
            return false;
    }

    private int anyWinner() {

        // check for row
        boolean isRowComplete = true;
        for (int i = 0; i < this.size; i++) {
            isRowComplete = true;
            for (int j = 1; j < this.size; j++) {
                if (this.board[i][j] != this.board[i][0]) {
                    isRowComplete = false;
                    break;
                }
            }
            if (isRowComplete) {
                return this.board[i][0];
            }
        }

        // check for col
        boolean isColComplete = true;
        for (int i = 0; i < this.size; i++) {
            isColComplete = true;
            for (int j = 1; j < this.size; j++) {
                if (this.board[j][i] != this.board[0][i]) {
                    isColComplete = false;
                    break;
                }
            }
            if (isColComplete) {
                return this.board[0][i];
            }
        }

        // rightto left diagonal
        boolean isLeftToRighDiagonalComplete = true;
        for (int i = 0; i < this.size; i++) {
            if (this.board[i][i] != this.board[0][0])
                isLeftToRighDiagonalComplete = false;
        }
        if (isLeftToRighDiagonalComplete) {
            return this.board[0][0];
        }

        // left to right diagonal
        boolean isRighLeftDiagonalComplete = true;
        for (int i = this.size - 1; i >= 0; i--) {
            if (this.board[0][2] != this.board[2 - i][i])
                isRighLeftDiagonalComplete = false;
        }
        if (isRighLeftDiagonalComplete) {
            return this.board[0][2];
        }
        // check if draw
        boolean isDraw = true;
        for (int i = 0; i < this.size; i++) {
            for (int j = 0; j < this.size; j++) {
                if (this.board[i][j] == 0) {
                    isDraw = false;
                    break;
                }
            }
        }
        if (isDraw)
            return 3;

        return 0;
    }

}
