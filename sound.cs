using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Project
{
    static class sound
    {
        static SoundPlayer sound_1 = new SoundPlayer(Properties.Resources.sound_1);
        static SoundPlayer sound_2 = new SoundPlayer(Properties.Resources.sound_2);
        static SoundPlayer sound_button_exit = new SoundPlayer(Properties.Resources.sound_button_exit);
        static SoundPlayer sound_button_start = new SoundPlayer(Properties.Resources.sound_button_start);
        static SoundPlayer sound_collect = new SoundPlayer(Properties.Resources.sound_collect);
        static SoundPlayer sound_menu = new SoundPlayer(Properties.Resources.sound_menu);
        static SoundPlayer sound_teleport = new SoundPlayer(Properties.Resources.sound_teleport);

        public static void play_1()
        {
            sound_1.Play();
        }
        public static void play_2()
        {
            sound_2.Play();
        }
        public static void play_button_exit()
        {
            sound_button_exit.Play();
        }
        public static void play_button_start()
        {
            sound_button_start.Play();
        }
        public static void play_collect()
        {
            sound_collect.Play();
        }
        public static void play_menu()
        {
            sound_menu.Play();
        }
        public static void play_teleport()
        {
            sound_teleport.Play();
        }
    }
}
