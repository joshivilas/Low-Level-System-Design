package LowLevelDesign.TicTacToe;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class StartGame {
    public static void main(String[] args) {
        //initialize board
        Scanner sc = new Scanner(System.in);

        System.out.println("Initializing the Game :TICTACTOE.....");

        System.out.println("1st User: X. Enter username: ");
        String userName1 = sc.nextLine();
        Player player1 = new Player(userName1, 1);

        System.out.println("2st User: O. Enter username: ");
        String userName2 = sc.nextLine();
        Player player2 = new Player(userName2, 2);

        List<Player> players= new ArrayList<>();
        players.add(player1);
        players.add(player2);

        Board board = new Board(3, players, sc);
        board.playGame();
    }
}
