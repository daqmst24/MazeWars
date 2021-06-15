using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;

namespace Assets.script
{
    interface IDamageable
    {

        void OnDamaged(Transform collison);
     
    }
}
