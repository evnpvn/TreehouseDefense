namespace TreehouseDefense
{
    class Level
    {
        private readonly IInvader[] _invaders;
        public Tower[] towers {get; set;}
        public Level(IInvader[] invaders)
        {
            _invaders = invaders;
        }
        // returns true if player wins, false if game continues or invader scores
        public bool Play()
        {
            //run until all invaders are neutralized or an invader reaches the end of the path
            int remainingInvaders = _invaders.Length;
            while(remainingInvaders > 0)
            {
                //each tower has an opportunity to fire on invaders
                foreach(Tower tower in towers)
                    {
                        tower.FireOnInvaders(_invaders);
                    }
            
                //count and move the invaders that are still active
                remainingInvaders = 0;
                foreach(IInvader invader in _invaders)
                {
                    if(invader.IsActive)
                    {
                        invader.Move();
                            if(invader.HasScored)
                            {
                                return false;
                            }
                        remainingInvaders++;
                    }
                }
            }
            return true;
        }
    }
}