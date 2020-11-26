using System;
using System.Collections.Generic;
using System.Text;

namespace Caeser_Cipher
{
    class Caesar
    {
        private List<char> alphabets = new List<char>{
                'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f',
                'G', 'g', 'H', 'h', 'I', 'i', 'J', 'j', 'K', 'k', 'L', 'l', 'M', 'm', 'N', 'n', 'O', 
                'o', 'P', 'p', 'Q', 'q', 'R', 'r', 'S', 's', 'T', 't', 'U', 'u', 'V', 'v', 'W', 'w',
                'X', 'x', 'Y', 'y', 'Z', 'z', ' ', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private int offset;
        private List<char> key = new List<char>();

        /// <summary>
        /// initialize new Key for Caesar cryptography with random offset.
        /// </summary>
        public Caesar()
        {
            Random random = new Random();
            this.offset = random.Next(1, 60);
            CreateKey(this.alphabets, this.offset);
        }
        
        /// <summary>
        /// initialize new Key for Caesar cryptography.
        /// </summary>
        /// <param name="offset">Integer between 1 - 60 </param>
        public Caesar(int offset)
        {
            this.offset = offset;
            CreateKey(this.alphabets, this.offset);
        }

        private void CreateKey(List<char> alphabets, int offset)
        {

            foreach (char c in alphabets)
            {
               this.key.Add('0'); 
            }

            for (int i = 0; i < alphabets.Count; i++)
            {
                if (i + offset < alphabets.Count)
                {
                    int x = (i + offset);
                    this.key[x] = this.alphabets[i];
                }
                else
                {
                    int y = (i - alphabets.Count) + offset;
                    this.key[y] = this.alphabets[i];
                }
            }
        }


        public string Encrypt(string plainText)
        {
            List<char> plaintTextList = new List<char>();
            List<char> cypherTextList = new List<char>();
            foreach (char c in plainText)
            {
                plaintTextList.Add(c);
                cypherTextList.Add(c);
            }
            for (int i = 0; i < plaintTextList.Count; i++)
            {
                int index = this.alphabets.IndexOf(plaintTextList[i]);
                cypherTextList[i] = this.key[index];
            }
            string cypherText = string.Join("", cypherTextList.ToArray());
            return cypherText;
        }

        public string Decrypt(string cypherText)
        {
            List<char> plaintTextList = new List<char>();
            List<char> cypherTextList = new List<char>();
            foreach (char c in cypherText)
            {
                plaintTextList.Add(c);
                cypherTextList.Add(c);
            }
            for (int i = 0; i < cypherTextList.Count; i++)
            {
                int index = this.key.IndexOf(cypherTextList[i]);
                plaintTextList[i] = this.alphabets[index];
            }
            string plainText = string.Join("", plaintTextList.ToArray());
            return plainText;
        }

    }
}
