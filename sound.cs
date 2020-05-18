using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;
using System.Collections;

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
        static SoundPlayer sound_sword = new SoundPlayer(Properties.Resources.sound_sword);

        static bool sound_enabled = true;

        public static void sound_on()
        {
            sound_enabled = true;
        }
        public static void sound_off()
        {
            sound_enabled = false;
            
        }
        public static void play_1()
        {
            if(sound_enabled)
            sound_1.Play();
        }
        public static void play_2()
        {
            if (sound_enabled)
                sound_2.Play();
        }
        public static void play_sound_sword()
        {
            if (sound_enabled)
                sound_sword.Play();
        }
        public static void play_button_exit()
        {
            if (sound_enabled)
                sound_button_exit.Play();
        }
        public static void play_button_start()
        {
            if (sound_enabled)
                sound_button_start.Play();
        }
        public static void play_collect()
        {
            if (sound_enabled)
                sound_collect.Play();
        }
        public static void play_menu()
        {
            if (sound_enabled)
                sound_menu.PlayLooping();
            
          
        }
        public static bool if_music()
        {
            if (sound_enabled)
                return true;
            else
                return false;
        }
        public static void dont_play_menu()
        {
            sound_menu.Stop();
        }
        public static void dont_play_exit()
        {
            sound_button_exit.Stop();
        }
        public static void play_teleport()
        {
            if (sound_enabled)
                sound_teleport.Play();
        }
    }
}
