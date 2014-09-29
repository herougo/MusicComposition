using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MelodyCreator
{
    public struct Bar
    {
        public int Quarter_Note_Space;
        // Time Time_Signature;
        // Key Key
        public int[] Notes;
        // Harmonic Chords
    }
    
    public class Piece
    {
        public int Tempo { get; set; }
        // Key Startng_Key_Signature {get; set;}
        public Bar[] Bars = null;
        private OutputDevice OutDevice { get; set; }
        private int OutDeviceID = 0;

        // public int percent_played = 90;

        public Piece(int piece_tempo)
        {
            Tempo = piece_tempo;

            if (OutputDevice.DeviceCount == 0)
            {
                
            }
            else
            {
                try
                {
                    OutDevice = new OutputDevice(OutDeviceID);
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        public void Play()
        {
            int note_space_milliseconds = 1000 * 60 / (Tempo * Bars[0].Quarter_Note_Space);
            
            DateTime time1 = DateTime.Now;
            
            DateTime time2 = DateTime.Now;
            time2.AddMilliseconds(Bars.Length * Bars[0].Notes.Length / Bars[0].Quarter_Note_Space
                * 1000 * 60 / Tempo);

            int bar_counter = 0;
            int note_counter = 0;
            int prev_note = Bars[0].Notes[0];

            if (prev_note != -1)
            {
                OutDevice.Send(new ChannelMessage(ChannelCommand.NoteOn, 0, prev_note, 127));
                time1 = time1.AddMilliseconds(note_space_milliseconds);
            }

            int counter = 0;
            while (true)
            {
                if (DateTime.Now > time1)
                {
                    // change notes
                    
                    note_counter++;
                    if (note_counter == Bars[bar_counter].Notes.Length)
                    {
                        bar_counter++;
                        note_counter = 0;
                    }
                    time1 = time1.AddMilliseconds(note_space_milliseconds);

                    if (bar_counter >= Bars.Length)
                    {
                        if (prev_note != -1)
                        {
                            OutDevice.Send(new ChannelMessage(ChannelCommand.NoteOn, 0, prev_note, 0));
                        }

                        break;
                    }
                    else if (Bars[bar_counter].Notes[note_counter] != prev_note)
                    {
                        if (prev_note != -1)
                        {
                            OutDevice.Send(new ChannelMessage(ChannelCommand.NoteOn, 0, prev_note, 0));
                        }

                        prev_note = Bars[bar_counter].Notes[note_counter];

                        if (prev_note != -1)
                        {
                            OutDevice.Send(new ChannelMessage(ChannelCommand.NoteOn, 0, prev_note, 127));
                        }
                    }
                }

            }

            
        }

    }
}
