namespace Autofac
{
    public class Logic
    {
        private IGrandfather _grandfather;
        private IFather _father;
        private ISon _son;

        public Logic(IGrandfather grandfather, IFather father, ISon son)
        {
            _grandfather = grandfather;
            _father = father;
            _son = son;
        }

        public string Run(string relation)
        {
            switch (relation.ToLower())
            {
                case "g" :
                    return _grandfather.Name();
                case "f" :
                    return _father.Name() + " - " + _grandfather.Son.Name();
                case "s" :
                    return _son.Name() + " - " + _grandfather.Son.Son.Name();
            }
            return string.Empty;
        }
    }
}