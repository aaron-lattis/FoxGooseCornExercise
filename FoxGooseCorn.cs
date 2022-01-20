using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxGooseCorn
{
    abstract class FoxGooseCorn
    {

        public bool IsOnStartingShore { get; set; }

        public bool IsOnDestinationShore { get; set; }

        public string Name { get; protected set; }


        public FoxGooseCorn()
        {
            IsOnStartingShore = true;
            IsOnDestinationShore = false;
        }


        public void Move()
        {
            if (IsOnStartingShore)
            {
                IsOnStartingShore = false;
                IsOnDestinationShore = true;
            }
            else
            {
                IsOnStartingShore = true;
                IsOnDestinationShore = false;
            }
        }
    }
}
