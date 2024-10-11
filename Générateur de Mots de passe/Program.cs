using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Générateur_de_Mots_de_passe
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            bool retry = true;
            while (retry)
            {
                // Réglage de la console
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                // Implémentation de l'intégralité des caractères
                string lowercase = "abcdefghijklmnopqrstuvwxyz";
                string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string digits = "1234567890";
                string symbols = "!@#$%^&*()-_=+[{]}|;:',<.>/?`~";
                // Combiner tous les caractères ensembles
                string allCharacters = lowercase + uppercase + digits + symbols;
                // Création d'un tableau avec l'intégralité des caractères.
                char[] characterArray = allCharacters.ToCharArray();
                // Génération du mot de passe
                Console.Write("Combien souhaitez-vous de caractères ? ");
                int pwLength;
                while (!int.TryParse(Console.ReadLine(), out pwLength) || pwLength <= 0)
                {
                    Console.WriteLine("Entrée invalide. Veuillez rentrer un entier positif.");
                }
                string password = GeneratePassword(pwLength, characterArray);
                // Ajout du mot de passe dans le presse-papier, et affichage de celui-ci en rouge foncé
                Clipboard.SetText(password);
                Console.WriteLine("Votre mot de passe est a été ajouté au presse-papier. Le voici :");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(password);
                Console.ReadLine();
            }
        }
        static string GeneratePassword(int length, char[] characterArray)
        {
            Random random = new Random();
            char[] password = new char[length];
            for (int i = 0; i < length; i++)
            {
                int RandomIndex = random.Next(characterArray.Length);
                password[i] = characterArray[RandomIndex];
            }
            return new string(password);
        }
    }
}
