using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace CSharpHyrje
{
	class Akademia
	{
		public static List<string> courses = new List<string> { "Math", "Physics", "Programming", "Chemistry" };
		public static List<string> students = new List<string>
			{  "Agon Ramadani", "Leart Zemiraj", "Brikena Thaqi",
			   "Maria Begova", "Petrit Vakolli", "Elisa Bushaku",
			   "Valmir Veliu", "Arianit Begisholli", "Venesa Hajraliu"
			};


		static void Main(string[] arguments)
		{
			Start();
		}

		public static void Start()
		{

			Console.WriteLine("--------------- WELCOME TO THE ACADEMY PROGRAM ---------------");

			Console.WriteLine("\nType in first name : ");
			string FirstName = Console.ReadLine();
			Console.WriteLine("\nType in your last name : ");
			string LastName = Console.ReadLine();

			string FullName = string.Concat(FirstName, " ", LastName);

			Console.Clear();

			bool IsAuthorized = Authorize(FullName, FirstName);


			if (IsAuthorized)
			{
				Console.WriteLine("\nWhich course are you enrolled in?\n");

				int attentionLine = Console.CursorTop;

				Console.WriteLine("(ATTENTION: IF YOU HAVE NOT YET BEEN ENROLLED, PRESS 'A'.)");

				Thread.Sleep(3000);

				Console.SetCursorPosition(0, attentionLine);

				Console.WriteLine(new string(' ', Console.WindowWidth));

				Console.SetCursorPosition(0, attentionLine);

				retry:
				for (int i = 0; i < courses.Count; i++)
				{
					Console.WriteLine($"{(i + 1)}.{courses[i]}");
				}

				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						Console.WriteLine("Awesome, you may continue with your arithmetic lessons!");
						break;
					case "2":
						Console.WriteLine("Great, you may continue with your physics lessons!");
						break;
					case "3":
						Console.WriteLine("Perfect, you may continue with your coding lessons!");
						break;
					case "4":
						Console.WriteLine("Very well, you may continue with your chemistry lessons!");
						break;
					case "A":
					case "a":
						Console.WriteLine("You are not in any courses yet.");
						Console.WriteLine("Would you like to enroll in a course? ");
						string answer = Console.ReadLine();
						if (answer == "yes")
							EnrollStudent();
						break;
					default:
						Console.WriteLine("Invalid choice, please retry!\n");
						goto retry;
				}

			}
			
		}


		public static void EnrollStudent()
		{
			Console.Clear();
			Console.WriteLine("We are very sorry, applications open on June 16th,");
			Console.ReadKey();
		}

		public static bool Authorize(string StudentFullName, string FirstName)
		{
			if (students.Contains(StudentFullName))
			{
				Console.WriteLine($"\nWelcome, back {FirstName}.\nWhat a pleasure to have you with us!");
				return true;
			}

			Console.WriteLine("Sorry, you are not a student at this academy!!");
			return false;
		}
	}
}