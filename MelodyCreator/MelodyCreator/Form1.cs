
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MelodyCreator
{
    public partial class Form1 : Form
    {
        #region Input
        int harmonicNotes;
        int extraNotes;
        int maxInterval;
        int maxIntervalBtnThemes;
        int range;
        int maxNoteRepeat;
        string keyTonic;
        string keyQuality;
        #endregion

        string stylePath = AppDomain.CurrentDomain.BaseDirectory + "Style.txt";
        
        string[] pianoKeyFlat = new string[88];
        string[] pianoKeySharp = new string[88];
        string[] scaleTone = new string[16];
        int[] sixteenthBeat = new int[16];
        int[,] completePieceData = new int[100, 16]; // bar, sixteenth beat
        string[] bar = new string[50];
        string[] barInNumForm = new string[50];
        string[] harmonyPerBeat = new string[49];
        int[] harmonyPerBeatNum = new int[49];
        int barNum;
        int finalNote;

        Piece new_piece = new Piece(80);

        string[] procedure = new string[100];
        
        int harmonyBeat;

        public Form1()
        {
            InitializeComponent();

            #region Load Piano Keys (Scientific Pitch Notation)
            // Sharps
            pianoKeySharp[0] = "A0";
            pianoKeySharp[1] = "A♯0";
            pianoKeySharp[2] = "B0";
            pianoKeySharp[3] = "C1";
            for (int a = 1; a < 8; a++)
            {
                pianoKeySharp[4 + (a - 1) * 12] = "C♯" + a.ToString();
                pianoKeySharp[5 + (a - 1) * 12] = "D" + a.ToString();
                pianoKeySharp[6 + (a - 1) * 12] = "D♯" + a.ToString();
                pianoKeySharp[7 + (a - 1) * 12] = "E" + a.ToString();
                pianoKeySharp[8 + (a - 1) * 12] = "F" + a.ToString();
                pianoKeySharp[9 + (a - 1) * 12] = "F♯" + a.ToString();
                pianoKeySharp[10 + (a - 1) * 12] = "G" + a.ToString();
                pianoKeySharp[11 + (a - 1) * 12] = "G♯" + a.ToString();
                pianoKeySharp[12 + (a - 1) * 12] = "A" + a.ToString();
                pianoKeySharp[13 + (a - 1) * 12] = "A♯" + a.ToString();
                pianoKeySharp[14 + (a - 1) * 12] = "B" + a.ToString();
                pianoKeySharp[15 + (a - 1) * 12] = "C" + (a + 1).ToString();
            }

            // Flats
            pianoKeyFlat[0] = "A0";
            pianoKeyFlat[1] = "B0";
            pianoKeyFlat[2] = "B♭0";
            pianoKeyFlat[3] = "C1";
            for (int a = 1; a < 8; a++)
            {
                pianoKeyFlat[4 + (a - 1) * 12] = "D♭" + a.ToString();
                pianoKeyFlat[5 + (a - 1) * 12] = "D" + a.ToString();
                pianoKeyFlat[6 + (a - 1) * 12] = "E♭" + a.ToString();
                pianoKeyFlat[7 + (a - 1) * 12] = "E" + a.ToString();
                pianoKeyFlat[8 + (a - 1) * 12] = "F" + a.ToString();
                pianoKeyFlat[9 + (a - 1) * 12] = "G♭" + a.ToString();
                pianoKeyFlat[10 + (a - 1) * 12] = "G" + a.ToString();
                pianoKeyFlat[11 + (a - 1) * 12] = "A♭" + a.ToString();
                pianoKeyFlat[12 + (a - 1) * 12] = "A" + a.ToString();
                pianoKeyFlat[13 + (a - 1) * 12] = "B♭" + a.ToString();
                pianoKeyFlat[14 + (a - 1) * 12] = "B" + a.ToString();
                pianoKeyFlat[15 + (a - 1) * 12] = "C" + (a + 1).ToString();
            }
            #endregion

            UpdateProcedure();
        }

        int[] ranSequence = new int[501];
        public void CreateRanSequence(int endNum)
        {
            // Creates a sequence of random numbers from 0 to the specified number

            Random rnd = new Random();
            int[] ranSeqPlaceholder = new int[501];
            int seqCount = 0;

            // Reset ranSeqPlaceHolder
            for (int a = 0; a <= 500; a++)
            {
                ranSeqPlaceholder[a] = 0;
            }

            for (int a = 0; a <= endNum; a++)
            {
                ranSeqPlaceholder[a] = a;
            }
            while (endNum != -1)
            {
                int ranNum = rnd.Next(endNum + 1);

                ranSequence[seqCount] = ranSeqPlaceholder[ranNum];

                while (ranNum < endNum)
                {
                    ranSeqPlaceholder[ranNum] = ranSeqPlaceholder[ranNum + 1];
                    ranNum++;
                }
                ranSeqPlaceholder[ranNum] = 0;

                seqCount++;
                endNum--;
            }
        }

        public int CreateRandomNum(int endNum)
        {
            Random rnd = new Random();
            int ranNum = rnd.Next(endNum + 1);

            return ranNum;
        }

        public bool SearchString(string text, string substring)
        {
            // searches text string for the subtring string and is true if it is found
            bool inString = false;
            for (int a = 0; a <= (text.Length - substring.Length); a++)
            {
                if (text.Substring(a, substring.Length) == substring) inString = true;
            }
            return inString;
        }

        public int InString(string text, string substring)
        {
            // gives the first position of a desired substring
            int position = -1;

            for (int a = 0; a <= text.Length - substring.Length; a++)
            {
                if (text.Substring(a, substring.Length) == substring && position == -1) position = a;
            }

            return position;
        }

        public string Replace(string text, string find, string replaceWith)
        {
            // replace function
            int count = 0;
            string newText = text;
            while (newText.Length - find.Length - count >= 0)
            {
                if (newText.Substring(count, find.Length) == find)
                {
                    newText = newText.Substring(0, count) + replaceWith + newText.Substring(count + find.Length,
                        newText.Length - count - find.Length);
                    count += replaceWith.Length;
                }
                else count++;
            }
            return newText;
        }

        private void btnCreateMelody_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string harmony;
            string lastChord = null;
            int transposeInterval = 0;

            #region Get Input
            harmonicNotes = Convert.ToInt32(tBHarmonicNotes.Text);
            extraNotes = Convert.ToInt32(tBExtraNotes.Text);
            maxInterval = Convert.ToInt32(tBMaxInterval.Text);
            maxIntervalBtnThemes = Convert.ToInt32(tBMaxIntervalBtnThemes.Text);
            range = Convert.ToInt32(tBRange.Text);
            maxNoteRepeat = Convert.ToInt32(tBMaxNoteRepeat.Text);
            keyTonic = cBKeyTonic.Text;
            keyQuality = cBKeyQuality.Text;
            #endregion
            
            #region Reset
            // Reset sixteenth beats
            for (int a = 0; a < 16; a++)
            {
                sixteenthBeat[a] = 0;
            }

            // Reset Harmony
            harmonyBeat = 0;
            for (int a = 0; a < 49; a++)
            {
                harmonyPerBeat[a] = null;
            }

            // Reset Melody
            rTBMelody.Text = "";
            barNum = 0;
            for (int a = 0; a < 50; a++)
            {
                barInNumForm[a] = null;
                bar[a] = null;
            }

            // Reset Procedure
            for (int a = 0; a < 100; a++)
            {
                procedure[a] = null;
            }

            finalNote = 0;
            #endregion

            #region Load Scale
            // if the tonic is a sharp/flat
            string tonic = "";
            if (keyTonic == "F" || keyTonic == "D♯/E♭" || keyTonic == "G♯/A♭" || keyTonic == "A♯/B♭" ||
                (keyTonic == "C♯/D♭" && keyQuality == "Major"))
            {
                // Establish tonic
                if (SearchString(keyTonic, "/"))
                {
                    tonic = keyTonic.Substring(3, 2);
                }
                else
                {
                    tonic = keyTonic;
                }

                // Write scaleTones (starting in the 4 range)

                // Get to the tonic
                counter = 39;
                while ((tonic + "4") != pianoKeyFlat[counter])
                {
                    counter++;
                }

                scaleTone[1] = pianoKeyFlat[counter];

                // Other notes
                // Major Scale
                if (keyQuality == "Major")
                {
                    for (int a = 0; a < 2; a++)
                    {
                        scaleTone[2 + a * 7] = pianoKeyFlat[counter + 2 + a * 12];
                        scaleTone[3 + a * 7] = pianoKeyFlat[counter + 4 + a * 12];
                        scaleTone[4 + a * 7] = pianoKeyFlat[counter + 5 + a * 12];
                        scaleTone[5 + a * 7] = pianoKeyFlat[counter + 7 + a * 12];
                        scaleTone[6 + a * 7] = pianoKeyFlat[counter + 9 + a * 12];
                        scaleTone[7 + a * 7] = pianoKeyFlat[counter + 11 + a * 12];
                        scaleTone[8 + a * 7] = pianoKeyFlat[counter + 12 + a * 12];
                    }
                }
                // Natural Minor Scale
                else if (keyQuality == "Natural Minor")
                {
                    for (int a = 0; a < 2; a++)
                    {
                        scaleTone[2 + a * 7] = pianoKeyFlat[counter + 2 + a * 12];
                        scaleTone[3 + a * 7] = pianoKeyFlat[counter + 3 + a * 12];
                        scaleTone[4 + a * 7] = pianoKeyFlat[counter + 5 + a * 12];
                        scaleTone[5 + a * 7] = pianoKeyFlat[counter + 7 + a * 12];
                        scaleTone[6 + a * 7] = pianoKeyFlat[counter + 8 + a * 12];
                        scaleTone[7 + a * 7] = pianoKeyFlat[counter + 10 + a * 12];
                        scaleTone[8 + a * 7] = pianoKeyFlat[counter + 12 + a * 12];
                    }
                }
                // Harmonic Minor Scale
                else
                {
                    for (int a = 0; a < 2; a++)
                    {
                        scaleTone[2 + a * 7] = pianoKeyFlat[counter + 2 + a * 12];
                        scaleTone[3 + a * 7] = pianoKeyFlat[counter + 3 + a * 12];
                        scaleTone[4 + a * 7] = pianoKeyFlat[counter + 5 + a * 12];
                        scaleTone[5 + a * 7] = pianoKeyFlat[counter + 7 + a * 12];
                        scaleTone[6 + a * 7] = pianoKeyFlat[counter + 8 + a * 12];

                        // Sharpen the 7th
                        scaleTone[7 + a * 7] = pianoKeyFlat[counter + 11 + a * 12];

                        scaleTone[8 + a * 7] = pianoKeyFlat[counter + 12 + a * 12];
                    }
                }

            }
            else
            {
                // Establish tonic
                if (SearchString(keyTonic, "/"))
                {
                    tonic = keyTonic.Substring(0, 2);
                }
                else
                {
                    tonic = keyTonic;
                }

                // Write scaleTones (starting in the 4 range)

                // Get to the tonic
                counter = 39;
                while ((tonic + "4") != pianoKeySharp[counter])
                {
                    counter++;
                }

                scaleTone[1] = pianoKeySharp[counter];

                // Other notes
                // Major Scale
                if (keyQuality == "Major")
                {
                    for (int a = 0; a < 2; a++)
                    {
                        scaleTone[2 + a * 7] = pianoKeySharp[counter + 2 + a * 12];
                        scaleTone[3 + a * 7] = pianoKeySharp[counter + 4 + a * 12];
                        scaleTone[4 + a * 7] = pianoKeySharp[counter + 5 + a * 12];
                        scaleTone[5 + a * 7] = pianoKeySharp[counter + 7 + a * 12];
                        scaleTone[6 + a * 7] = pianoKeySharp[counter + 9 + a * 12];
                        scaleTone[7 + a * 7] = pianoKeySharp[counter + 11 + a * 12];
                        scaleTone[8 + a * 7] = pianoKeySharp[counter + 12 + a * 12];
                    }
                }
                // Natural Minor Scale
                else if (keyQuality == "Natural Minor")
                {
                    for (int a = 0; a < 2; a++)
                    {
                        scaleTone[2 + a * 7] = pianoKeySharp[counter + 2 + a * 12];
                        scaleTone[3 + a * 7] = pianoKeySharp[counter + 3 + a * 12];
                        scaleTone[4 + a * 7] = pianoKeySharp[counter + 5 + a * 12];
                        scaleTone[5 + a * 7] = pianoKeySharp[counter + 7 + a * 12];
                        scaleTone[6 + a * 7] = pianoKeySharp[counter + 8 + a * 12];
                        scaleTone[7 + a * 7] = pianoKeySharp[counter + 10 + a * 12];
                        scaleTone[8 + a * 7] = pianoKeySharp[counter + 12 + a * 12];
                    }
                }
                // Harmonic Minor Scale
                else
                {
                    for (int a = 0; a < 2; a++)
                    {
                        scaleTone[2 + a * 7] = pianoKeySharp[counter + 2 + a * 12];
                        scaleTone[3 + a * 7] = pianoKeySharp[counter + 3 + a * 12];
                        scaleTone[4 + a * 7] = pianoKeySharp[counter + 5 + a * 12];
                        scaleTone[5 + a * 7] = pianoKeySharp[counter + 7 + a * 12];
                        scaleTone[6 + a * 7] = pianoKeySharp[counter + 8 + a * 12];

                        // Sharpen the 7th
                        scaleTone[7 + a * 7] = pianoKeySharp[counter + 11 + a * 12];

                        scaleTone[8 + a * 7] = pianoKeySharp[counter + 12 + a * 12];
                    }
                }
            }

            scaleTone[0] = "-";
            #endregion

            #region Load Harmony
            harmony = rTBThemeAHarmony.Text;
            harmony = Replace(harmony, "\n", " ");
            counter = 0;

            while (harmony != "")
            {
                if (harmony.Substring(0, 1) == " ")
                {
                    harmony = harmony.Substring(1, harmony.Length - 1);
                }
                else if (harmony.Substring(0, 1) == "-")
                {
                    //If it's a repeat                    
                    counter++;
                    harmonyPerBeat[counter] = lastChord;
                    harmony = harmony.Substring(1, harmony.Length - 1);
                }
                else
                {
                    if (harmony.Substring(1, 1) == " ")
                    {
                        // if it's a chord with a length of 1
                        counter++;
                        harmonyPerBeat[counter] = harmony.Substring(0, 1);
                        harmony = harmony.Substring(1, harmony.Length - 1);
                    }
                    else if (harmony.Substring(2, 1) == " ")
                    {
                        // if it's a chord with a length of 2
                        counter++;
                        harmonyPerBeat[counter] = harmony.Substring(0, 2);
                        harmony = harmony.Substring(2, harmony.Length - 2);
                    }

                    lastChord = harmonyPerBeat[counter];
                }
            }

            harmony = rTBThemeBHarmony.Text;
            harmony = Replace(harmony, "\n", " ");

            while (harmony != "")
            {
                if (harmony.Substring(0, 1) == " ")
                {
                    harmony = harmony.Substring(1, harmony.Length - 1);
                }
                else if (harmony.Substring(0, 1) == "-")
                {
                    //If it's a repeat                    
                    counter++;
                    harmonyPerBeat[counter] = lastChord;
                    harmony = harmony.Substring(1, harmony.Length - 1);
                }
                else
                {
                    if (harmony.Substring(1, 1) == " ")
                    {
                        // if it's a chord with a length of 1
                        counter++;
                        harmonyPerBeat[counter] = harmony.Substring(0, 1);
                        harmony = harmony.Substring(1, harmony.Length - 1);
                    }
                    else if (harmony.Substring(2, 1) == " ")
                    {
                        // if it's a chord with a length of 2
                        counter++;
                        harmonyPerBeat[counter] = harmony.Substring(0, 2);
                        harmony = harmony.Substring(2, harmony.Length - 2);
                    }

                    lastChord = harmonyPerBeat[counter];
                }
            }

            harmony = rTBThemeAHarmony.Text;
            harmony = Replace(harmony, "\n", " ");

            while (harmony != "")
            {
                if (harmony.Substring(0, 1) == " ")
                {
                    harmony = harmony.Substring(1, harmony.Length - 1);
                }
                else if (harmony.Substring(0, 1) == "-")
                {
                    //If it's a repeat                    
                    counter++;
                    harmonyPerBeat[counter] = lastChord;
                    harmony = harmony.Substring(1, harmony.Length - 1);
                }
                else
                {
                    if (harmony.Substring(1, 1) == " ")
                    {
                        // if it's a chord with a length of 1
                        counter++;
                        harmonyPerBeat[counter] = harmony.Substring(0, 1);
                        harmony = harmony.Substring(1, harmony.Length - 1);
                    }
                    else if (harmony.Substring(2, 1) == " ")
                    {
                        // if it's a chord with a length of 2
                        counter++;
                        harmonyPerBeat[counter] = harmony.Substring(0, 2);
                        harmony = harmony.Substring(2, harmony.Length - 2);
                    }

                    lastChord = harmonyPerBeat[counter];
                }
            }

            // Convert to numbers
            counter = 1;

            while (counter != 49)
            {
                if (harmonyPerBeat[counter].ToUpper() == "I")
                {
                    harmonyPerBeatNum[counter] = 1;
                }
                else if (harmonyPerBeat[counter].ToUpper() == "IV")
                {
                    harmonyPerBeatNum[counter] = 4;
                }
                else if (harmonyPerBeat[counter].ToUpper() == "V")
                {
                    harmonyPerBeatNum[counter] = 5;
                }
                else if (harmonyPerBeat[counter].ToUpper() == "VI")
                {
                    harmonyPerBeatNum[counter] = 6;
                }
                counter++;
            }

            #endregion

            #region Load Procedure
            for (int a = 0; a < dGVProcedure.Rows.Count; a++)
            {
                procedure[a] = dGVProcedure.Rows[a].Cells[1].Value.ToString();
            }
            #endregion

            #region Follow Procedure
            counter = 0;
            string action;
            string parameters;
            while (procedure[counter] != null)
            {
                // Load action and parameters
                if (SearchString(procedure[counter], "("))
                {
                    action = procedure[counter].Substring(0, InString(procedure[counter], "("));
                    parameters = procedure[counter].Substring(
                        InString(procedure[counter], "(") + 1,
                        procedure[counter].Length - (InString(procedure[counter], "(") + 2));
                }
                else
                {
                    action = procedure[counter];
                    parameters = null;
                }

                // new melody
                WriteBar(action, parameters);

                counter++;
            }
            #endregion


            // Display Melody
            DisplayMelody();
        }

        public void WriteBar(string action, string parameter)
        {
            int barNumber;
            int interval;

            if (action == "new melody")
            {
                // Put -1 as a placeholder for a note
                ChooseRhythm(parameter);
                // Replace -1 with notes
                ChooseBasicNotes(parameter);
                // Decorate with extra notes
                if (parameter != "Henri Ending") DecorateMelody();
                // Record Melody
                RecordBar();
            }
            else if (action == "transpose")
            {
                barNumber = Convert.ToInt32(parameter.Substring(4, InString(parameter, ",") - 4).Trim());
                interval = Convert.ToInt32(parameter.Substring(InString(parameter, ",") + 1, parameter.Length - (InString(parameter, ",") + 1)).Trim());

                // Copy
                CopyBar(barNumber);
                Transpose(interval);
                RecordBar();
            }
            else if (action.Substring(0, 3) == "bar")
            {
                barNumber = Convert.ToInt32(action.Substring(4, action.Length - 4).Trim());

                // Copy
                CopyBar(barNumber);
                RecordBar();
            }

        }
        
        public void ChooseRhythm(string type)
        {
            Random rnd = new Random();
            
            // Reset melody
            for (int a = 0; a < 16; a++)
            {
                sixteenthBeat[a] = 0;
            }

            if (type == "Henri Theme")
            {
                // First beat always gets a note
                sixteenthBeat[0] = -1;

                // Create random sequence using eighth note accuracy
                CreateRanSequence(6);
                for (int a = 0; a < (harmonicNotes - 1); a++)
                {
                    sixteenthBeat[(ranSequence[a] + 1) * 2] = -1;
                }
            }
            else if (type == "Henri Ending")
            {
                // Create Rhythm (four eighth notes and a half note)
                for (int a = 0; a < 5; a++)
                {
                    sixteenthBeat[2 * a] = -1;
                }

                // Add extra notes
                // Decide between 4, 6, and sixteenth notes
                int ranNum = rnd.Next(3);
                CreateRanSequence(3);
                for (int a = 0; a < (2 + ranNum); a++)
                {
                    sixteenthBeat[2 * ranSequence[a] + 1] = -1;
                }
            }
        }

        public void ChooseBasicNotes(string type)
        {
            int counter;
            // Determine max values for range
            int highestNote = 1 + 7 * range;
            int lastNote = finalNote;
            int noteRepeatedNum = 0;
            int possibleNotesNum = 0;
            int[] possibleNotes = new int[10];
            int harmony;

            harmonyBeat = 0;

            #region Henri Theme

            if (type == "Henri Theme")
            {
                // Replace -1 with notes
                counter = 0;
                while (counter < 16)
                {
                    // if this is a new beat, update the harmony and possible notes
                    // Write possible notes
                    if ((counter / 4) * 4 == counter)
                    {
                        // Update Beat
                        harmonyBeat++;

                        // Reset possible notes
                        for (int a = 0; a < 10; a++)
                        {
                            possibleNotes[a] = 0;
                        }
                        // Update possible notes
                        for (int a = 0; a < range; a++)
                        {
                            possibleNotes[3 * a] = harmonyPerBeatNum[4 * barNum + harmonyBeat] + 7 * a;
                            possibleNotes[3 * a + 1] = harmonyPerBeatNum[4 * barNum + harmonyBeat] + 2 + 7 * a;
                            possibleNotes[3 * a + 2] = harmonyPerBeatNum[4 * barNum + harmonyBeat] + 4 + 7 * a;
                        }
                        if (harmonyPerBeatNum[4 * barNum + harmonyBeat] == 1)
                        {
                            possibleNotes[3 * range] = 1 + 7 * range;
                            possibleNotesNum = 3 * range + 1;
                        }
                        // switch notes outside the range
                        else
                        {
                            for (int a = 0; a < 3 * range; a++)
                            {
                                if (possibleNotes[a] > 15)
                                {
                                    possibleNotes[a] = possibleNotes[a] - 14;
                                }
                            }
                            possibleNotesNum = 3 * range;
                        }
                    }

                    // If there is a note to place
                    if (sixteenthBeat[counter] == -1)
                    {
                        Random rnd = new Random();
                        int ranNum = rnd.Next(0, possibleNotesNum);

                        if (counter == 0)
                        // if this is the first note
                        {
                            // if this is note the first note of the piece
                            if (lastNote != 0)
                            {
                                do
                                {
                                    ranNum = rnd.Next(possibleNotesNum);
                                    int a = (possibleNotes[ranNum] - lastNote); // interval in one direction
                                    int b = (lastNote - possibleNotes[ranNum]); // interval in other direction

                                } while (((possibleNotes[ranNum] - lastNote) >= maxIntervalBtnThemes && barNum % 4 == 0) || // first note of new theme is too far away
                                ((lastNote - possibleNotes[ranNum]) >= maxIntervalBtnThemes && barNum % 4 == 0) ||          // first note of new theme is too far away
                                ((possibleNotes[ranNum] - lastNote) >= maxInterval && barNum % 4 != 0) ||          // first note of new theme is too far away
                                ((lastNote - possibleNotes[ranNum]) >= maxInterval && barNum % 4 != 0));           // first note of new theme is too far away
                            }
                            
                            lastNote = possibleNotes[ranNum];
                            noteRepeatedNum++;

                            sixteenthBeat[counter] = possibleNotes[ranNum];
                        }
                        else
                        // if this is not the first note
                        {
                            do
                            {
                                ranNum = rnd.Next(possibleNotesNum);
                                int a = (possibleNotes[ranNum] - lastNote); // interval in one direction
                                int b = (lastNote - possibleNotes[ranNum]); // interval in other direction

                            } while (((possibleNotes[ranNum] - lastNote) >= maxInterval) ||
                                ((lastNote - possibleNotes[ranNum]) >= maxInterval) ||
                                ((possibleNotes[ranNum] == lastNote) && (noteRepeatedNum == maxNoteRepeat))); // if note is a repeat

                            // Update number of repeated notes
                            if (lastNote == possibleNotes[ranNum]) noteRepeatedNum++;
                            else
                            {
                                noteRepeatedNum = 1;
                            }

                            lastNote = possibleNotes[ranNum];

                            sixteenthBeat[counter] = possibleNotes[ranNum];
                        }
                    }

                    counter++;
                }
            }
            #endregion

            #region Henri Ending

            else if (type == "Henri Ending")
            {
                // Last note is always tonic
                sixteenthBeat[8] = 8;
                lastNote = 8;

                do
                {
                    // Reset notes in first two beats
                    for (int a = 0; a < 8; a++)
                    {
                        if (sixteenthBeat[a] != 0) sixteenthBeat[a] = -1;
                    }

                    harmony = harmonyPerBeatNum[barNum*4 + 2];
                    // Last note is always 2 or 7
                    counter = 7;
                    while (sixteenthBeat[counter] != -1)
                    {
                        counter--;
                    }
                    if (CreateRandomNum(1) == 1)
                    {
                        sixteenthBeat[counter] = 7;
                        lastNote = 7;
                    }
                    else
                    {
                        sixteenthBeat[counter] = 9;
                        lastNote = 9;
                    }

                    // Replace -1 with rest of notes
                    // max interval is 3 20%
                    // repeat 10%
                    // interval of 2 70%
                    // if there is a third, it must agree with the harmony
                    // the first note must agree with the harmony
                    while (counter >= 0)
                    {
                        // if there is a new harmony
                        if (counter == 3)
                        {
                            harmony = harmonyPerBeatNum[barNum * 4 + 1];
                        }

                        if (sixteenthBeat[counter] == -1)
                        {
                            if (CreateRandomNum(9) <= 7) // 70%
                            {
                                // Second
                                // if too low
                                if (lastNote < 2)
                                {
                                    sixteenthBeat[counter] = lastNote + 1;
                                    lastNote += 1;
                                }
                                // if too high
                                else if (lastNote > 14)
                                {
                                    sixteenthBeat[counter] = lastNote - 1;
                                    lastNote -= 1;
                                }
                                // 50% second higher
                                else if (CreateRandomNum(1) == 0)
                                {
                                    sixteenthBeat[counter] = lastNote + 1;
                                    lastNote += 1;
                                }
                                // 50% second lower
                                else
                                {
                                    sixteenthBeat[counter] = lastNote - 1;
                                    lastNote -= 1;
                                }
                                counter--;
                            }
                            else if (CreateRandomNum(2) <= 1) // 2/3 of 30% = 20%
                            {
                                // Third
                                // if too low
                                if (lastNote < 3)
                                {
                                    if (FitHarmony(lastNote + 2, harmony))
                                    {
                                        sixteenthBeat[counter] = lastNote + 2;
                                        lastNote += 2;
                                        counter--;
                                    }
                                }
                                // if too high
                                else if (lastNote > 13)
                                {
                                    if (FitHarmony(lastNote - 2, harmony))
                                    {
                                        sixteenthBeat[counter] = lastNote - 2;
                                        lastNote -= 2;
                                        counter--;
                                    }
                                }
                                // 50% third higher
                                else if (CreateRandomNum(1) == 0)
                                {
                                    if (FitHarmony(lastNote + 2, harmony))
                                    {
                                        sixteenthBeat[counter] = lastNote + 2;
                                        lastNote += 2;
                                        counter--;
                                    }
                                }
                                // 50% third lower
                                else
                                {
                                    if (FitHarmony(lastNote - 2, harmony))
                                    {
                                        sixteenthBeat[counter] = lastNote - 2;
                                        lastNote -= 2;
                                        counter--;
                                    }
                                }
                            }
                            else // 10%
                            {
                                // Repeat
                                sixteenthBeat[counter] = lastNote;
                                counter--;
                            }
                        }
                        else
                        {
                            counter--;
                        }
                    }

                } while (FitHarmony(sixteenthBeat[0], harmony) == false || ((sixteenthBeat[0] - finalNote) >= maxIntervalBtnThemes) ||
                                ((finalNote - sixteenthBeat[0]) >= maxIntervalBtnThemes));
            }
            #endregion
        }

        public void DecorateMelody()
        {
            int possibilityCount = 0;
            int[] possibleNoteSpot = new int[50];
            int[] possibleNote = new int[50];

            #region Record Possible Extra Notes
            // Look for two close eigth notes with an interval of a third
            for (int a = 1; a < 15; a++)
            {
                if (sixteenthBeat[a - 1] != 0 && sixteenthBeat[a] == 0 && sixteenthBeat[a + 1] != 0)
                {
                    if (sixteenthBeat[a - 1] - sixteenthBeat[a + 1] == 2)
                    {
                        possibleNoteSpot[possibilityCount] = a;
                        possibleNote[possibilityCount] = sixteenthBeat[a - 1] - 1;
                        possibilityCount++;
                    }
                    else if (sixteenthBeat[a + 1] - sixteenthBeat[a - 1] == 2)
                    {
                        possibleNoteSpot[possibilityCount] = a;
                        possibleNote[possibilityCount] = sixteenthBeat[a + 1] - 1;
                        possibilityCount++;
                    }
                }
            }

            // Look for two close eigth notes with the same notes
            for (int a = 1; a < 15; a++)
            {
                if (sixteenthBeat[a] == 0 && sixteenthBeat[a - 1] == sixteenthBeat[a + 1] &&
                    sixteenthBeat[a - 1] > 1 && sixteenthBeat[a - 1] < 15)
                {
                    // Record the note below
                    possibleNoteSpot[possibilityCount] = a;
                    possibleNote[possibilityCount] = sixteenthBeat[a - 1] - 1;

                    // Record the note above half the time
                    Random rnd = new Random();
                    int ranNum = rnd.Next(1);

                    if (ranNum == 0)
                    {
                        possibleNoteSpot[possibilityCount] = a;
                        possibleNote[possibilityCount] = sixteenthBeat[a - 1] + 1;
                    }

                    possibilityCount++;
                }
                else if (sixteenthBeat[a] == 0 && sixteenthBeat[a - 1] == sixteenthBeat[a + 1] &&
                    sixteenthBeat[a - 1] == 1)
                {
                    // Record the note above
                    possibleNoteSpot[possibilityCount] = a;
                    possibleNote[possibilityCount] = sixteenthBeat[a - 1] + 1;
                    possibilityCount++;
                }
                else if (sixteenthBeat[a] == 0 && sixteenthBeat[a - 1] == sixteenthBeat[a + 1] &&
                    sixteenthBeat[a - 1] == 15)
                {
                    // Record the note below
                    possibleNoteSpot[possibilityCount] = a;
                    possibleNote[possibilityCount] = sixteenthBeat[a - 1] - 1;
                    possibilityCount++;
                }

            }

            possibilityCount--;
            #endregion

            #region Add Extra Notes

            CreateRanSequence(possibilityCount);
            for (int a = 0; a < extraNotes; a++)
            {
                if (possibleNoteSpot[a] != 0) sixteenthBeat[possibleNoteSpot[ranSequence[a]]] = 
                    possibleNote[ranSequence[a]];
            }

            #endregion
        }

        public void RecordBar()
        {
            GetFinalNote();
            
            // Numbers
            for (int a = 0; a < 16; a++)
            {
                completePieceData[barNum, a] = sixteenthBeat[a];
                
                barInNumForm[barNum] += sixteenthBeat[a];

                // In-between stuff
                if (((a + 1) / 4) * 4 - 1 == a) // if it is the end of a beat
                {
                    if (a != 15) barInNumForm[barNum] += " | ";
                }
                else
                {
                    barInNumForm[barNum] += "-";
                }
            }

            // Notes
            for (int a = 0; a < 16; a++)
            {
                if (sixteenthBeat[a] != 0)
                {
                    bar[barNum] += scaleTone[sixteenthBeat[a]] + " ";
                }
                else
                {
                    bar[barNum] += "--" + " ";
                }

                // if it is the end of a beat
                if (((a + 1) / 4) * 4 - 1 == a && a != 15)
                {
                    bar[barNum] += "| ";
                }
            }

            barNum++;
        }

        public void DisplayMelody()
        {
            rTBMelody.Text = "";
            rTBMelodyNoteForm.Text = "";

            barNum = 0;
            while (bar[barNum] != null)
            {
                // line between 4 bar intervals
                if (barNum % 4 == 0)
                {
                    rTBMelody.Text += "\n";
                    rTBMelodyNoteForm.Text += "\n";
                }

                // display line
                if (barNum == 0)
                {
                    rTBMelody.Text += barInNumForm[barNum];
                    rTBMelodyNoteForm.Text += bar[barNum];
                }
                else
                {
                    rTBMelody.Text += "\n" + barInNumForm[barNum];
                    rTBMelodyNoteForm.Text += "\n" + bar[barNum];
                }
                barNum++;
            }

        }

        public void GetFinalNote()
        {
            int counter = 15;

            while (sixteenthBeat[counter] == 0)
            {
                counter--;
            }

            finalNote = sixteenthBeat[counter];
        }

        public void CopyBar(int sourceBar)
        {
            for (int a = 0; a < 16; a++)
            {
                sixteenthBeat[a] = completePieceData[sourceBar - 1, a];
            }
        }

        public void Transpose(int interval)
        {
            int counter = 0;

            // transposes melody up or down a certain interval. Positive intervals are up and negative intervals
            // are down

            // interval up
            if (interval > 0)
            {
                while (counter < 16)
                {
                    if (sixteenthBeat[counter] != 0)
                    {
                        sixteenthBeat[counter] += interval - 1;
                    }
                    counter++;
                }
            }
            // interval down
            else if (interval < 0)
            {
                while (counter < 16)
                {
                    if (sixteenthBeat[counter] != 0)
                    {
                        sixteenthBeat[counter] += interval + 1;
                    }
                    counter++;
                }
            }            
        }

        public bool FitHarmony(int tone, int chord)
        {
            bool pass = false;

            if (tone % 7 == chord % 7 || tone % 7 == (chord + 2) % 7 || tone % 7 == (chord + 4) % 7)
            {
                pass = true;
            }

            return pass;
        }

        public void UpdateProcedure()
        {
            string barNum;
            string action;

            dGVProcedure.Rows.Clear();
            
            FileStream fs = new FileStream(stylePath, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine();

                if (line == ("#" + cBStyle.Text))
                {
                    // Get to procedure
                    while (line.Substring(0, 5).ToLower() != "key q") // the data before the procedure for the piece
                    {
                        line = sr.ReadLine();
                    }

                    do
                    {
                        line = sr.ReadLine();
                        
                        // Load Values
                        barNum = line.Substring(0, InString(line, " - "));
                        action = line.Substring(InString(line, " - ") + 3, line.Length - (InString(line, " - ") + 3));

                        // Add Row
                        dGVProcedure.Rows.Add(barNum, action);
                    } while (sr.Peek() != -1 && line.Substring(0, 4) == "bar ") ;
                }
            }

            sr.Close();
            fs.Close();
        }

        private void cBStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(stylePath, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine();

                if (line == ("#" + cBStyle.Text))
                {
                    line = sr.ReadLine();
                    tBHarmonicNotes.Text = line.Substring(InString(line, "- ") + 2, 
                        line.Length - (InString(line, "- ") + 2));
                    line = sr.ReadLine();
                    tBExtraNotes.Text = line.Substring(InString(line, "- ") + 2,
                        line.Length - (InString(line, "- ") + 2));
                    line = sr.ReadLine();
                    tBMaxInterval.Text = line.Substring(InString(line, "- ") + 2,
                        line.Length - (InString(line, "- ") + 2));
                    line = sr.ReadLine();
                    tBRange.Text = line.Substring(InString(line, "- ") + 2,
                        line.Length - (InString(line, "- ") + 2));
                    line = sr.ReadLine();
                    tBMaxNoteRepeat.Text = line.Substring(InString(line, "- ") + 2,
                        line.Length - (InString(line, "- ") + 2));
                    line = sr.ReadLine();
                    cBKeyTonic.Text = line.Substring(InString(line, "- ") + 2,
                        line.Length - (InString(line, "- ") + 2));
                    line = sr.ReadLine();
                    cBKeyQuality.Text = line.Substring(InString(line, "- ") + 2,
                        line.Length - (InString(line, "- ") + 2));
                }
            }

            sr.Close();
            fs.Close();

            UpdateProcedure();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            int[] major_pattern = new int[9]{-61, 0, 2, 4, 5, 7, 9, 11, 12};

            int c = 60;

            new_piece.Bars = new Bar[barNum];

            for (int b = 0; b < barNum; b++)
            {
                new_piece.Bars[b].Quarter_Note_Space = 4;

                new_piece.Bars[b].Notes = new int[16];
                for (int n = 0; n < 16; n++)
                {
                    new_piece.Bars[b].Notes[n] = ((completePieceData[b, n] - 1) / 7) * 12
                        + major_pattern[((completePieceData[b, n] - 1) % 7) + 1] + c;
                }

            }

            new_piece.Play();
        }

        
    }
}

/* TO DO
incorporate ifs and ors into the new syntax (especially for the transpose interval)



*/