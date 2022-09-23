using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    record VideoGame(
        string title,
        string platform, // Playstation, Xbox, Nintendo, PC Games
        double price,
        long webCode
    );

}
