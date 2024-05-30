using EightQueensSolver.DataStructures;
using EightQueensSolver.Entities;

namespace EightQueensSolver
{
    public class Solver
    {
        public List<Queen> Queens = new List<Queen>();
        public List<List<Queen>> AllStates = new List<List<Queen>>();
        public const int N = 8;
        public int CountTimeComplexity = 0;
        public int CountCapacitiveComplexity = 0;

        public void AStar()
        {
            CountTimeComplexity = 0;
            CountCapacitiveComplexity = 0;
            PriorityQueue<State> openSet = new PriorityQueue<State>();
            HashSet<string> closedSet = new HashSet<string>();

            int[] initialState = BuildInitialState();

            State startState = new State(initialState, HeuristicCost(initialState));
            openSet.Enqueue(startState, startState.cost);

            while (openSet.Count > 0)
            {
                State currentState = openSet.Dequeue();
                CountTimeComplexity++;

                List<Queen> current = new List<Queen>();
                for (int t = 0; t < N; t++)
                {
                    current.Add(new Queen(t + 1, currentState.queenPositions[t] + 1));
                }
                AllStates.Add(current);
 
                if (currentState.cost == 0)
                {
                    // Розв'язок знайдено
                    for (int i = 0; i < N; i++)
                    {
                        Queens[i].column = currentState.queenPositions[i] + 1;
                        Queens[i].row = i + 1;
                    }
                    return;
                }

                // Генерація наступного стану
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {                        
                        if (currentState.queenPositions[i] != j)
                        {
                            int[] nextState = new int[N];
                            Array.Copy(currentState.queenPositions, nextState, N);
                            nextState[i] = j;

                            State newState = new State(nextState, HeuristicCost(nextState));

                            if (!closedSet.Contains(string.Join(",", nextState)))
                            {
                                openSet.Enqueue(newState, newState.cost);
                                CountCapacitiveComplexity++;
                            }
                        }
                    }
                }
                closedSet.Add(string.Join(",", currentState.queenPositions));
            }
        }

        public Node RBFS(Node node, int f_limit, int currentCapacity)
        { 
            if (HeuristicCost(node.State) == 0) return node; // Розв'язок знайдено

            List<Node> successors = GetSuccessors(node);
            currentCapacity += successors.Count;

            CountCapacitiveComplexity = Math.Max(CountCapacitiveComplexity, currentCapacity);
            CountTimeComplexity++;

            if (!successors.Any())
                return null;
            
            foreach (var s in successors)
            {
                s.f = Math.Max(s.g + HeuristicCost(s.State), node.f);
            }

            while (true)
            {
                successors.Sort((a, b) => a.f.CompareTo(b.f));
                Node best = successors[0];

                if (best.f > f_limit)
                    return null;

                List<Queen> current = new List<Queen>();
                for (int t = 0; t < N; t++)
                {
                    current.Add(new Queen(t + 1, best.State[t] + 1));
                }
                AllStates.Add(current);

                int alternative = successors.Count > 1 ? successors[1].f : int.MaxValue;
                var result = RBFS(best, Math.Min(f_limit, alternative), currentCapacity);

                best.f = result != null ? result.g : int.MaxValue;

                if (result != null)
                    return (result);
            }
        }

        public void SolveWithRBFS()
        {
            CountTimeComplexity = 0;
            CountCapacitiveComplexity = 0;
            AllStates.Clear();
            List<Queen> start = new List<Queen>();
            for (int t = 0; t < N; t++)
            {
                int x = Queens[t].row;
                int y = Queens[t].column;
                start.Add(new Queen(x, y));
            }
            AllStates.Add(start);

            int[] initialState = BuildInitialState();

            List<Queen> initial = new List<Queen>();
            for (int t = 0; t < N; t++)
            {
                initial.Add(new Queen(t + 1, initialState[t] + 1));
            }
            AllStates.Add(initial);

            Node initialNode = new Node(initialState, 0, null);
            
            var solution = RBFS(initialNode, int.MaxValue, 0);

            for (int i = 0; i < N; i++)
            {
                Queens[i].column = solution.State[i] + 1;
                Queens[i].row = i + 1;
            }
        }

        private int HeuristicCost(int[] queenPositions)
        {
            int hCost = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (queenPositions[i] == queenPositions[j] ||
                        Math.Abs(i - j) == Math.Abs(queenPositions[i] - queenPositions[j]))
                    {
                        hCost++;
                    }
                }
            }
            return hCost;
        }

        private List<Node> GetSuccessors(Node node)
        {
            List<Node> successors = new List<Node>();
            int[] state = node.State;
            for (int i = 0; i < state.Length; i++)
            {
                int pos = state[i];
                for (int newPos = 0; newPos < state.Length; newPos++)
                {
                    CountTimeComplexity++;
                    if (newPos != pos)
                    {
                        int[] newState = (int[])state.Clone();
                        newState[i] = newPos;

                        bool flag = true;
                        for (int j = 0; j < i; j++)
                        {
                            if (newState[j] == newPos || Math.Abs(j - i) == Math.Abs(newState[j] - newPos))
                                flag = false;
                        }
                        if (flag) successors.Add(new Node(newState, node.g + 1, node));
                    }
                }
            }
            return successors;
        }

        private int[] BuildInitialState()
        {
            int k = 0;
            int[] state = new int[] { -1, -1, -1, -1, -1, -1, -1, -1 };
            bool[] isQueenInRow = new bool[] { false, false, false, false, false, false, false, false };
            for (int i = 0; i < N; i++)
            {
                if (state[Queens[i].row - 1] == -1)
                {
                    state[Queens[i].row - 1] = Queens[i].column - 1;
                    isQueenInRow[i] = true;
                    k++;
                }
            }
            int j = 0;
            for (int i = 0; i < N; i++)
            {
                if (!isQueenInRow[i])
                {
                    while (state[j] != -1)
                    {
                        j++;
                    }
                    state[j] = Queens[i].column - 1;
                    Queens[i].row = j + 1;
                }
            }
            if (k == 8)
            {
                AllStates.Clear();
            }
            else CountTimeComplexity++;
            return state;
        }
    }
}
