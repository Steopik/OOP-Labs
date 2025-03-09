using ConsolePaint.Figures;

namespace ConsolePaint.Tools
{
    class ChangeAction
    {
        int StorageMaxSize = 5;
        int Rollback = 0;
        List<List<IFigure>> Storage;
        public ChangeAction()
        {
            Storage = new List<List<IFigure>>();
        }

        public ChangeAction(List<List<IFigure>> storage)
        {
            Storage = storage;
        }

        List<IFigure> Back()
        {
            if (Rollback > 3) throw new Exception("It is impossible to roll back more than 5 steps");
            Rollback += 1;
            return Storage[Storage.Count - (Rollback + 1)];
        }

        List<IFigure> Forward()
        {
            if (Rollback < 1) throw new Exception("It is impossible to restore more than 5 dates");
            Rollback -= 1;
            return Storage[Storage.Count - (Rollback + 1)]; 
        }

        void Add(List<IFigure> figures)
        {
            while (Storage.Count > StorageMaxSize)
            {
                Storage.RemoveAt(0);
            }

            while (Rollback > 0)
            {
                Storage.RemoveAt(Storage.Count - 1);
                Rollback -= 1;
            }

            for (int i = 0; i < StorageMaxSize - 1; i++)
            {
                Storage[i] = Storage[i + 1];
            }
            Storage[Storage.Count - 1] = figures;
        }
    }
}
