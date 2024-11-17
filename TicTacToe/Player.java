package LowLevelDesign.TicTacToe;

public class Player {
    String userName;
    int markType;

    public Player(String userName, int markType) {
        this.userName = userName;
        this.markType = markType;
    }

    @Override
    public String toString() {
        return userName;
    }
}
