using HammingCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.HashFunction;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRC_HAMMING
{
    public partial class Form1 : Form
    {
        string input_value, control_data, interrupted_data, output_with_fixed_errors,output_without_control_data;
        int errors_occured, errors_fixed, errors_undetected;
        int bytes_of_send_data, bytes_of_control_data;
        int rodzaj_crc = 32;
        int bytes_of_crc=32;
        int columnsAmount = -1;
        int rowsAmount = -1;
        string wartosc_poprawiona_hamming;
        string[,] tablica_wynikow = new string[14, 2];
        int[,] bytesToTrim = new int[1,2];
        bool saveLastByteTrimInfo = true;

        static Random random = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bytesToTrim[0, 0] = 0;
            bytesToTrim[0, 1] = 0;
            saveLastByteTrimInfo = true;
            clearArray(tablica_wynikow);
            clearResults();
            if(textBox1.Text.Length<8 || !textBox1.Text.All(c => "01".Contains(c)))
            {
                MessageBox.Show("Wprowadź dane binarne, minimum 8 znaków");
            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    rodzaj_crc = 12;
                    bytes_of_crc = 12;
                }
                if (radioButton2.Checked == true)
                {
                    rodzaj_crc = 16;
                    bytes_of_crc = 16;
                }
                if (radioButton3.Checked == true)
                {
                    rodzaj_crc = 32;
                    bytes_of_crc = 32;
                }

                //bytes_of_crc = 32;
                CRC.Setting setings_crc = new CRC.Setting(bytes_of_crc - 1, 13, 0, CRC.DefaultSettings.ReflectIn, CRC.DefaultSettings.ReflectOut, 0);
                string wprowadzona_wartosc_string = textBox1.Text;
                Binary wprowadzona_wartosc_binary = binary_string_to_Binary(textBox1.Text);

                tablica_wynikow[0, 0] = "Wprowadzone dane";
                tablica_wynikow[0, 1] = wprowadzona_wartosc_string;
                tablica_wynikow[11, 0] = "Wprowadzone dane po 8 bitów";
                byte[] wprowdzony_tekst_8bit = binary_string_to_Byte_array(wprowadzona_wartosc_string);
                var wprowadzony_tekst_8bit_string = string.Concat(wprowdzony_tekst_8bit.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
                tablica_wynikow[11, 1] = wprowadzony_tekst_8bit_string;
                tablica_wynikow[4, 0] = "Ilość wprowadzonych danych";
                tablica_wynikow[4, 1] = wprowadzona_wartosc_string.Length.ToString();

                // ----------------------------------- Główna część programu ----------------------------------
                
                byte[] in_1 = generate_CRC(wprowadzona_wartosc_string, setings_crc); // generuj crc dla wprowadzony danych
                var byte_crc_string = string.Concat(in_1.Select(b => Convert.ToString(b, 2).PadLeft(8, '0'))); // zamiana tablicy bajtowej na binarny string
                tablica_wynikow[1, 0] = "Wygenerowane CRC";
                tablica_wynikow[1, 1] = byte_crc_string;

                wprowadzona_wartosc_binary = binary_string_to_Binary(byte_crc_string);

                Binary wartosc_z_kodem_hamminga = hamming_Send(wprowadzona_wartosc_binary); // wygenerowanie wiadomości z kodem hamminga

                tablica_wynikow[2, 0] = "Wprowadzone dane z kodem Hamminga";
                tablica_wynikow[2, 1] = wartosc_z_kodem_hamminga.ToString();
                tablica_wynikow[5, 0] = "Ilość przesłanych danych";
                tablica_wynikow[5, 1] = wartosc_z_kodem_hamminga.Length.ToString();

                wartosc_poprawiona_hamming = hamming_Receive(wartosc_z_kodem_hamminga); // sprawdzenie otrzymanej wartości z kodem hamminga i ewentualna korekcja błędów

                tablica_wynikow[3, 0] = "Poprawione dane z kodem Hamminga";
                tablica_wynikow[3, 1] = wartosc_poprawiona_hamming.ToString();

                byte[] in_2 = binary_string_to_Byte_array(wartosc_poprawiona_hamming);

                bool outt = test_CRC(in_2, setings_crc); // sprawdź crc dla wprowadzonych danych
                                                         // false = brak błędów, true = wystąpiły błędy
                tablica_wynikow[13, 0] = "Test CRC";
                tablica_wynikow[13, 1] = outt.ToString();
                tablica_wynikow[10, 0] = "Sygnał wyjściowy bez danych kontrolnych";
                string output_temp = wartosc_poprawiona_hamming.ToString().Substring(0, wartosc_poprawiona_hamming.Count() - bytes_of_crc);
                if (bytes_of_crc == 12)
                {
                    output_temp = output_temp.Substring(0,output_temp.Count()-4);
                }
                tablica_wynikow[10, 1] = trimLastByte(output_temp);
                tablica_wynikow[12, 0] = "Liczba błędów niewykrytych";
               // tablica_wynikow[12, 1] = xorStringBinaries(tablica_wynikow[10, 1], tablica_wynikow[0, 1]).ToString();
                showResults(tablica_wynikow);

                // ---------------------------------- Koniec głównej części programu
            }



        }

        public static string ConvertToBinary(ulong value)
        {
            if (value == 0) return "0";
            System.Text.StringBuilder b = new System.Text.StringBuilder();
            while (value != 0)
            {
                b.Insert(0, ((value & 1) == 1) ? '1' : '0');
                value >>= 1;
            }
            return b.ToString();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox13.Enabled = true;
            }
            if (checkBox2.Checked == false)
            {
                textBox13.Enabled = false;
            }
        }


        public byte[] generate_CRC(string data, CRC.Setting settings)
        {
            byte[] byte_data = binary_string_to_Byte_array(data);

            string data_with_crc=data;
            CRC.Setting set = settings;
            CRC crc_1 = new CRC(set);
            byte[] crc_generated = crc_1.ComputeHash(byte_data);
            byte[] input_data_array = Encoding.ASCII.GetBytes(data);

            var data_with_crc_array = new byte[byte_data.Length + crc_generated.Length];
            byte_data.CopyTo(data_with_crc_array, 0);
            crc_generated.CopyTo(data_with_crc_array, byte_data.Length);

            
            return data_with_crc_array;
        }

        public bool test_CRC(byte[] data_with_generated_crc, CRC.Setting settings)
        {
            bool errors = false;
            CRC.Setting set = settings;

            CRC test_CRC = new CRC(set);
            byte[] test_score = test_CRC.ComputeHash(data_with_generated_crc);

            for(int i=0; i<test_score.Length; i++)
            {
                if (test_score[i] != 0)
                {
                    errors = true;
                    return errors;
                }
            }

            return errors;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CRC.Setting setings_crc = new CRC.Setting(bytes_of_crc - 1, 13, 0, CRC.DefaultSettings.ReflectIn, CRC.DefaultSettings.ReflectOut, 0);
            string wprowadzona_wartosc_string = "11110011";
            byte[] in_1 = generate_CRC(wprowadzona_wartosc_string, setings_crc);
            //in_1[2] = 2;

            bool outt = test_CRC(in_1, setings_crc);
            var byte_crc_string = string.Concat(in_1.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int dlugosc_generowany_danych = 0;
            String wygenerowane_dane = "";

            try
            {
               dlugosc_generowany_danych = Convert.ToInt16(textBox3.Text);
                for (int k = 0; k < dlugosc_generowany_danych; k++)
                {
                    int bit = random.Next(0, 2);
                    wygenerowane_dane = String.Concat(wygenerowane_dane, Convert.ToString(bit));
                }
                textBox1.Text = wygenerowane_dane;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Błąd. Wpisz poprawną liczbę");
            }
            

            

        }

        public void Hamming() {

            Binary message;

            message = new Binary(new[] { true, false, true, false });
            int columnsAmount = message.Count();
            int rowsAmount = (int)Math.Ceiling(Math.Log(columnsAmount, 2) + 1);
            int parity_bit = 0;

            Binary bin_parity_bit = new Binary(new[] { false });
            BinaryMatrix H = GenerateHMatrix(rowsAmount, columnsAmount);
            Binary verification = GenerateVerificationBits(H, message);
            Binary help_frame = Binary.Concatenate(message, verification);

            if (help_frame.CountOnes() % 2 == 0)
            {
                bin_parity_bit = new Binary(new[] { false });
                parity_bit = 0;
            }
            if (help_frame.CountOnes() % 2 != 0)
            {
                bin_parity_bit = new Binary(new[] { true });
                parity_bit = 1;
            }

            Binary frame = Binary.Concatenate(help_frame, bin_parity_bit);

            //Console.WriteLine("Message = {0}", message);
            //Console.WriteLine("H matrix:");
            //Console.Write(H);
            //Console.WriteLine("Verification = {0}", verification);
            //Console.WriteLine("Output Frame = {0}", frame);
            //Console.WriteLine();


            //Console.WriteLine("*** Receiving ***");
            //Console.WriteLine("Corrupt message? [y/n]");
            bool? corruptMessage = null;
            //do
            //{
            //    switch (Console.ReadKey().Key)
            //    {
            //        case ConsoleKey.Y:
            //            corruptMessage = true;
            //            break;
            //        case ConsoleKey.N:
            //            corruptMessage = false;
            //            break;
            //    }
            //  Console.WriteLine();
            // }
            while (!corruptMessage.HasValue);

            int frame_lenght = frame.Length;
            Binary receivedFrame = new Binary(frame.ToArray());
            if (corruptMessage.Value)
            {
                int badBit = random.Next(0, receivedFrame.Length - 1);
                int badBit2 = random.Next(0, receivedFrame.Length - 1);

                receivedFrame[badBit] = !receivedFrame[badBit2];
                receivedFrame[badBit2] = !receivedFrame[badBit2];

            }
            Binary recivedFrameWithParitBit = new Binary(receivedFrame.ToArray().Take(frame_lenght));
            Binary receivedParityBit = new Binary(frame.ToArray().Skip(frame_lenght - 1));
            receivedFrame = new Binary(receivedFrame.ToArray().Take(frame_lenght - 1));
            Binary receivedMessage = new Binary(receivedFrame.Take(columnsAmount));
            Binary receivedVerification = new Binary(receivedFrame.Skip(columnsAmount));
            int generatedParityBit = -1;

            H = GenerateHMatrix(rowsAmount, columnsAmount);
            Binary receivedMessageVerification = GenerateVerificationBits(H, receivedMessage);
            Binary s = receivedVerification ^ receivedMessageVerification;
            if (recivedFrameWithParitBit.CountOnes() % 2 == 0)
            {
                generatedParityBit = 0;

            }
            if (recivedFrameWithParitBit.CountOnes() % 2 != 0)
            {
                generatedParityBit = 1;
            }

            //Console.WriteLine("received frame = {0}", Binary.Concatenate(receivedFrame, receivedParityBit));
            //Console.WriteLine("H matrix:");
            //Console.Write(H);
            //Console.WriteLine("received message verification: {0}", receivedMessageVerification);
            //Console.WriteLine("s value: {0}", s);

            if (s.CountOnes() > 0)
            {
                if (generatedParityBit == 1)
                {
                    try
                    {
                        BinaryMatrix HWithIdentity = GenerateHWithIdentity(H);
                        int faultyBitPosition = FindFaultyBit(HWithIdentity, s);

                        Binary correctedFrame = new Binary(receivedFrame.ToArray());
                        correctedFrame[faultyBitPosition] = !correctedFrame[faultyBitPosition];

                        //Console.WriteLine("H matrix with identity:");
                        //Console.Write(HWithIdentity);
                        //Console.WriteLine("Fault bit possition founded: {0}", faultyBitPosition);

                        Binary correctedFrameGeneratedVerify = GenerateVerificationBits(H, new Binary(correctedFrame.Take(columnsAmount)));
                        Binary correctedFrameVerify = new Binary(correctedFrame.Skip(columnsAmount));
                        Binary correctionVerify = correctedFrameVerify ^ correctedFrameGeneratedVerify;
                       // if (correctionVerify.CountOnes() == 0)
                           // Console.WriteLine("Corrected frame = {0}", correctedFrame);
                       // else
                            //Console.WriteLine("The frame cannot be corrected, more than 1 bit error");
                    }
                    catch (WarningException)
                    {
                       // Console.WriteLine("The frame cannot be corrected");
                    }
                }
                if (generatedParityBit == 0)
                {
                    //Console.WriteLine("More than 1 error");
                }
            }
            else
            {
                if (generatedParityBit == 0)
                {
                    //Console.WriteLine("The received frame is correct");
                }
                if (generatedParityBit == 1)
                {
                   // Console.WriteLine("Parity bit error");
                }
            }


           // Console.ReadKey();
        }

        static BinaryMatrix GenerateHMatrix(int rowsAmount, int columnsAmount)
        {
            BinaryMatrix H = new BinaryMatrix(rowsAmount, columnsAmount);

            int n = 0;
            for (int i = 1; i <= Math.Pow(2, rowsAmount); i++)
            {
                Binary binary = new Binary(i, H.RowAmount);
                if (binary.CountOnes() >= 2)
                {
                    for (int y = 0; y < rowsAmount; y++)
                    {
                        H.Set(y, n, binary[y]);
                    }
                    n++;
                }
                if (n >= H.ColumnAmount)
                    break;
            }
            return H;
        }

        static Binary GenerateVerificationBits(BinaryMatrix H, Binary message)
        {
            Binary verification = new Binary(new bool[H.RowAmount]);
            for (int i = 0; i < H.RowAmount; i++)
            {
                Binary row = H.GetRow(i);
                Binary addiction = row & message;
                bool verificationBit = addiction.CountOnes() % 2 == 1 ? true : false;
                verification[i] = verificationBit;
            }
            return verification;
        }

        static BinaryMatrix GenerateHWithIdentity(BinaryMatrix H)
        {
            BinaryMatrix HWithIdentity = new BinaryMatrix(H.RowAmount, H.ColumnAmount + H.RowAmount);
            for (int y = 0; y < H.RowAmount; y++)
            {
                for (int x = 0; x < H.ColumnAmount; x++)
                {
                    HWithIdentity.Set(y, x, H.Get(y, x));
                }
            }

            for (int y = 0; y < H.RowAmount; y++)
            {
                int n = 0;
                for (int x = H.ColumnAmount; x < H.ColumnAmount + H.RowAmount; x++)
                {
                    HWithIdentity.Set(y, x, y == n);

                    n++;
                }
            }
            return HWithIdentity;
        }


        private static int FindFaultyBit(BinaryMatrix H, Binary s)
        {
            for (int i = 0; i < H.ColumnAmount; i++)
            {
                Binary column = H.GetColumn(i);
                Binary check = s ^ column;
                if (check.Any(b => b))
                    continue;
                return i;
            }

            throw new WarningException("Faulty bit not found!");
        }

        public Binary hamming_Send(Binary msg)
        {
            
            Binary message = msg;

            //message = new Binary(new[] { true, false, true, false });
            columnsAmount = message.Count();
            // rowsAmount = (int)Math.Ceiling(Math.Log(columnsAmount, 2)+1);
            rowsAmount = (int)Math.Ceiling(Math.Log(columnsAmount+1,2));
            int parity_bit = 0;

            Binary bin_parity_bit = new Binary(new[] { false });
            BinaryMatrix H = GenerateHMatrix(rowsAmount, columnsAmount);
            Binary verification = GenerateVerificationBits(H, message);
            Binary help_frame = Binary.Concatenate(message, verification);

            if (help_frame.CountOnes() % 2 == 0)
            {
                bin_parity_bit = new Binary(new[] { false });
                parity_bit = 0;
            }
            if (help_frame.CountOnes() % 2 != 0)
            {
                bin_parity_bit = new Binary(new[] { true });
                parity_bit = 1;
            }

            Binary frame = Binary.Concatenate(help_frame, bin_parity_bit);
            //Binary frame = help_frame;
            return frame;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals("Brak"))
            {
                textBox2.Clear();
            }
            
        }

        public String hamming_Receive(Binary received_frame)
        {

            tablica_wynikow[6, 0] = "Liczba błędów";
            tablica_wynikow[6, 1] = "0";
            Binary wiadomosc_do_zwrotu;
            Binary frame = received_frame;
            bool? corruptMessage = null;
            bool czy_wystepuja_bledy = false;
            int rodzaj_bledow = 0; // 1 - wprowadzone, 2 - wygenerowane
            List<int> lista_wpisanych_bledow = new List<int>();
            int liczba_bledow_do_wygenerowania = 0;
            int frame_status = -1;
            // 1- ramka poprawiona
            // 2 - ramka niepoprawiona, wiecej niz 2 bledy
            // 3- ramka poprawna, brak bledow
            // -1 - blad obliczania ramki
            // 4 - blad bitu parzystosci

            if (!textBox2.Text.Equals("Brak")) // dodaj wpisane błędy
            {
                rodzaj_bledow = 1;
                czy_wystepuja_bledy = true;
                string wpisane_bledy = textBox2.Text;
                while (wpisane_bledy.Contains(','))
                {
                    int index_przecinek = wpisane_bledy.IndexOf(',');
                    lista_wpisanych_bledow.Add(Convert.ToInt16(wpisane_bledy.Substring(0, index_przecinek)));
                    wpisane_bledy = wpisane_bledy.Substring(index_przecinek + 1);
                }
                lista_wpisanych_bledow.Add(Convert.ToInt16(wpisane_bledy));
                tablica_wynikow[6, 0] = "Liczba błędów";
                tablica_wynikow[6, 1] = lista_wpisanych_bledow.Count().ToString();

               
            }

            if(checkBox2.Checked==true && textBox13.Text != null) // generuj błędy
            {
                rodzaj_bledow = 2;
                czy_wystepuja_bledy = true;
                try {
                    liczba_bledow_do_wygenerowania = Convert.ToInt16(textBox13.Text);
                    tablica_wynikow[6, 0] = "Liczba błędów";
                    tablica_wynikow[6, 1] = liczba_bledow_do_wygenerowania.ToString();
                }
                catch(Exception eez)
                {
                    MessageBox.Show("Błędna liczba błędów do wygenerowania");
                }
                
            }

            if(textBox2.Text == null && textBox13.Text == null)
            {
                czy_wystepuja_bledy = false;
            }



            int frame_lenght = frame.Length;
            Binary receivedFrame = new Binary(frame.ToArray());
            if (czy_wystepuja_bledy==true)
            {
                if (rodzaj_bledow == 1)
                {
                    for(int i =0; i <lista_wpisanych_bledow.Count; i++)
                    {
                        receivedFrame[lista_wpisanych_bledow[i]] = !receivedFrame[lista_wpisanych_bledow[i]];
                        
                    }
                }

                if (rodzaj_bledow == 2)
                {
                    for(int j=0; j<liczba_bledow_do_wygenerowania; j++)
                    {
                        int badBit = random.Next(0, receivedFrame.Length - 1);
                        receivedFrame[badBit] = !receivedFrame[badBit];
                    }
                }

                //int badBit = random.Next(0, receivedFrame.Length - 1);
                //int badBit2 = random.Next(0, receivedFrame.Length - 1);

                //receivedFrame[badBit] = !receivedFrame[badBit2];
                //receivedFrame[badBit2] = !receivedFrame[badBit2];

            }
            Binary recivedFrameWithParitBit = new Binary(receivedFrame.ToArray().Take(frame_lenght));

            tablica_wynikow[9, 0] = "Przesłane dane";
            tablica_wynikow[9, 1] = recivedFrameWithParitBit.ToString();

            Binary receivedParityBit = new Binary(frame.ToArray().Skip(frame_lenght - 1));
            receivedFrame = new Binary(receivedFrame.ToArray().Take(frame_lenght - 1));
            Binary receivedMessage = new Binary(receivedFrame.Take(columnsAmount));
            Binary receivedVerification = new Binary(receivedFrame.Skip(columnsAmount));
            int generatedParityBit = -1;

            BinaryMatrix H = GenerateHMatrix(rowsAmount, columnsAmount);
            Binary receivedMessageVerification = GenerateVerificationBits(H, receivedMessage);
            Binary s = receivedVerification ^ receivedMessageVerification;

            wiadomosc_do_zwrotu = new Binary(recivedFrameWithParitBit.Take(columnsAmount));
            frame_status = 2;

            if (recivedFrameWithParitBit.CountOnes() % 2 == 0)
            {
                generatedParityBit = 0;

            }
            if (recivedFrameWithParitBit.CountOnes() % 2 != 0)
            {
                generatedParityBit = 1;
            }

            //Console.WriteLine("received frame = {0}", Binary.Concatenate(receivedFrame, receivedParityBit));
            //Console.WriteLine("H matrix:");
            //Console.Write(H);
            //Console.WriteLine("received message verification: {0}", receivedMessageVerification);
            //Console.WriteLine("s value: {0}", s);

            if (s.CountOnes() > 0)
            {
                if (generatedParityBit == 1)
                {
                    try
                    {
                        BinaryMatrix HWithIdentity = GenerateHWithIdentity(H);
                        int faultyBitPosition = FindFaultyBit(HWithIdentity, s);

                        tablica_wynikow[7, 0] = "Pozycja błędu";
                        tablica_wynikow[7, 1] = faultyBitPosition.ToString();

                        Binary correctedFrame = new Binary(receivedFrame.ToArray());
                        correctedFrame[faultyBitPosition] = !correctedFrame[faultyBitPosition];

                        //Console.WriteLine("H matrix with identity:");
                        //Console.Write(HWithIdentity);
                        //Console.WriteLine("Fault bit possition founded: {0}", faultyBitPosition);

                        Binary correctedFrameGeneratedVerify = GenerateVerificationBits(H, new Binary(correctedFrame.Take(columnsAmount)));
                        Binary correctedFrameVerify = new Binary(correctedFrame.Skip(columnsAmount));
                        Binary correctionVerify = correctedFrameVerify ^ correctedFrameGeneratedVerify;
                        // if (correctionVerify.CountOnes() == 0)
                        // Console.WriteLine("Corrected frame = {0}", correctedFrame);
                        // else
                        //Console.WriteLine("The frame cannot be corrected, more than 1 bit error");
                        wiadomosc_do_zwrotu = new Binary(correctedFrame.Take(columnsAmount));
                        frame_status = 1;
                    }
                    catch (WarningException)
                    {
                        // Console.WriteLine("The frame cannot be corrected");
                    }
                }
                if (generatedParityBit == 0)
                {
                    //Console.WriteLine("More than 1 error");
                }

                
            }
            else
            {
                if (generatedParityBit == 0)
                {
                    //Console.WriteLine("The received frame is correct");
                    frame_status = 3;
                }
                if (generatedParityBit == 1)
                {
                    // Console.WriteLine("Parity bit error");
                    frame_status = 4;
                }
            }
            //MessageBox.Show(frame_status.ToString());
            tablica_wynikow[8, 0] = "Ilość błędów wykrytych";
            if (frame_status == 1)
            {
                tablica_wynikow[8, 1] = "1";
            }
            if (frame_status == 2)
            {
                tablica_wynikow[8, 1] = ">2";
            }
            if (frame_status == 3)
            {
                tablica_wynikow[8, 1] = "0";
            }
            if (frame_status == 4)
            {
                tablica_wynikow[8, 1] = "Błąd bitu parzystości";
            }
            if (frame_status == -1)
            {
                tablica_wynikow[8, 1] = "Błąd obliczania";
            }

            return wiadomosc_do_zwrotu.ToString();
            
        }


        public Binary binary_string_to_Binary(String txt)
        {
            List<bool> lista_binarna = new List<bool>();
            while (txt.Count() > 0)
            {
                int bit = Convert.ToInt16(txt.Substring(0, 1));
                txt = txt.Substring(1);
                if (bit == 0)
                {
                    lista_binarna.Add(false);
                }
                if (bit == 1)
                {
                    lista_binarna.Add(true);
                }

                
            }
            Binary wartosc_binarna = new Binary(lista_binarna);
            return wartosc_binarna;
        }

        public Byte[] binary_string_to_Byte_array(String txt)
        {
            string input = txt;
            double numOfBytes2 = (double)input.Length / 8;
            int integerNumOfBytes = Convert.ToInt16(Math.Ceiling(numOfBytes2));
            int counter = 0;
            string temp = "";
            while (txt.Length > 0)
            {
                try {
                    temp = string.Concat(temp, txt.Substring(0, 8));
                }
                catch(Exception ee)
                {
                    int txt_count = txt.Length;
                    for (int z=txt_count; z< 8; z++)
                    {
                        txt = string.Concat("0", txt);
                    }
                    temp = string.Concat(temp, txt);
                    if (saveLastByteTrimInfo == true)
                    {
                        bytesToTrim[0, 0] = counter;
                        bytesToTrim[0, 1] = 8 - txt_count;
                        saveLastByteTrimInfo = false;
                    }
                   
                    break;
                }
                txt = txt.Substring(8);
                counter++;
            }
            input = temp;

            int numOfBytes = input.Length / 8;

            if (numOfBytes == 0)
            {
                numOfBytes = 1;
            }
            byte[] bytes = new byte[numOfBytes];
            for (int i = 0; i < numOfBytes; ++i)
            {
                bytes[i] = Convert.ToByte(input.Substring(8 * i, 8), 2);
            }

            return bytes;
        }

        public Byte[] string_bin_to_Byte_array(string txt)
        {
            byte[] returnn = new byte[txt.Length];
            int index = 0;
            while (txt.Length > 0)
            {
                string znak = txt.Substring(0, 1);
                if (znak == "1")
                {
                    Decimal dec = 1;
                    returnn[index]= Convert.ToByte(dec);
                    index++;
                    txt = txt.Substring(1);
                }
                if (znak == "0")
                {
                    Decimal dec = 0;
                    returnn[index] = Convert.ToByte(dec);
                    index++;
                    txt = txt.Substring(1);
                }
            }

            return returnn;
        }

        public void showResults (string[,] tab)
        {
            for(int i=0; i<=tab.GetUpperBound(0); i++)
            {
                switch (tab[i, 0])
                {
                    case "Wprowadzone dane":
                        tb_wprowadzone_dane.Text = tab[i, 1];
                        break;
                    case "Wygenerowane CRC":
                        tb_wygenerowane_crc.Text = tab[i, 1];
                        break;
                    case "Wprowadzone dane z kodem Hamminga":
                        tb_dane_crc_hamming.Text = tab[i, 1];
                        break;
                    case "Poprawione dane z kodem Hamminga":
                        tb_poprawione_dane_z_crc.Text = tab[i, 1];
                        break;
                    case "Wprowadzone dane po 8 bitów":
                        tb_ilosc_wprowadzonych_danych.Text = (tab[i, 1].Length).ToString();
                        break;
                    case "Ilość przesłanych danych":
                        tb_ilosc_przeslanych_danych.Text = (Convert.ToInt16(tab[i, 1])-Convert.ToInt16(tab[11, 1].Length)).ToString();
                        break;
                    case "Liczba błędów":
                        tb_ilosc_bledow.Text = tab[i, 1];
                        break;
                    case "Pozycja błędu":
                        tb_pozycja_bledu.Text = tab[i, 1];
                        break;
                    case "Ilość błędów wykrytych":
                        break;
                    case "Przesłane dane":
                        tb_przeslane_dane.Text = tab[i, 1];
                        break;
                    case "Sygnał wyjściowy bez danych kontrolnych":
                        tb_sygnal_wyjsciowy.Text = tab[i, 1];
                        break;
                    case "Liczba błędów niewykrytych":
                        tb_ilosc_bledow_niewykrytych.Text = tablica_wynikow[12, 1];
                        break;
                    case "Test CRC":
                        tb_test_crc.Text = tablica_wynikow[13, 1];
                        break;
                    case null:
                        break;
                }
            }
            if (tb_test_crc.Text.Equals("False"))
            {
                tb_test_crc.BackColor = Color.Green;
                tb_test_crc.ForeColor = Color.Yellow;
            }
            else if (tb_test_crc.Text.Equals("True"))
            {
                tb_test_crc.BackColor = Color.Red;
            }
        }

        public void clearResults()
        {
            tb_dane_crc_hamming.Clear();
            tb_ilosc_bledow.Clear();
            tb_ilosc_przeslanych_danych.Clear();
            tb_ilosc_wprowadzonych_danych.Clear();
            tb_poprawione_dane_z_crc.Clear();
            tb_pozycja_bledu.Clear();
            tb_przeslane_dane.Clear();
            tb_sygnal_wyjsciowy.Clear();
            tb_wprowadzone_dane.Clear();
            tb_wygenerowane_crc.Clear();
            tb_ilosc_bledow_niewykrytych.Clear();
            tb_test_crc.Clear();
            tb_test_crc.BackColor = Color.Empty;
        }

        public int xorStringBinaries(string a, string b)
        {
            Binary b_a = binary_string_to_Binary(a);
            Binary b_b = binary_string_to_Binary(b);
            Binary result = b_a ^ b_b;
            int onesInResult = result.CountOnes();
            return onesInResult;
        }

        public void clearArray(string[,] tablica_wynikow)
        {
            for (int i = 0; i < tablica_wynikow.GetUpperBound(0) + 1; i++)
            {
                tablica_wynikow[i, 0] = null;
                tablica_wynikow[i, 1] = null;
            }
        }

        public String trimLastByte(String txt)
        {
            if(bytesToTrim[0, 0] != 0)
            {
                string temp = txt.Substring(8 * bytesToTrim[0, 0] + bytesToTrim[0, 1]);
                txt = String.Concat(txt.Substring(0, txt.Length - 8), temp);
                return txt;
            }
            return txt;
        }
        
    }
}
