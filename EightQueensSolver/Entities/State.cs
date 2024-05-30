namespace EightQueensSolver.Entities
{
    public class State
    {
        static int N = 8; 
        public int[] queenPositions; 
        public int cost; 

        public State(int[] queenPositions, int cost)
        {
            this.queenPositions = new int[N];
            Array.Copy(queenPositions, this.queenPositions, N);
            this.cost = cost;
        }
    }
}
