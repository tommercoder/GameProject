using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public static class Hero
    {

        public static int IdleFrames = 7;
        public static int runFrames = 7;
        public static int attackFrames = 2;
        public static int deathFrames = 7;
        public static int RedFrames = 7;

        public static int EnemyIdleFrames = 8;
        public static int EnemyRunFrames = 8;

        public static int Enemy2RunFrames = 4;
        public static int Enemy2IdleFrames = 4;

        public static int Enemy5RunFrames = 4;
        public static int Enemy5IdleFrames = 4;
        public static int BossIdleFrames = 5;
        public static int BossRunFrames = 8;
        public static int BossAttackFrames = 9;
        public static int BossDeathFrames = 6;


        public static int OpenChestFrames = 2;
        public static int IdleChestFrames = 1;

        public static int fullHearts = 5;
        public static int heartsFrames = 5;
    }
}
