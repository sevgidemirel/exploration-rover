using Business.BaseModel;
using Business.Model;
using Common.Constans;
using Controller.Controller;
using System;
using System.Collections.Generic;
using Utilities.Converter;
using Utilities.Helper;
using Utilities.Validation;


namespace FrontEnd
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter 'Q' key to see final result..");
            List<string> lines = new List<string>();
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            List<RoverRequest> marsRoverRequestList = new List<RoverRequest>();

            while (keyInfo.Key != ConsoleKey.Q)
            {
                string line = Console.ReadLine();
                lines.Add(line);
                if (!ValidateLine(line, lines.IndexOf(line)))
                {
                    lines.RemoveAt(lines.Count - 1);
                }
                keyInfo = Console.ReadKey(true);
            }

            if ((lines.Count - 1) % 2 != 0 || lines.Count == 1)
            {
                Console.WriteLine("You entered the missing line");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                int count = 0;
                for (int i = 1; i < lines.Count; i++)
                {
                    if (i % 2 == 1)
                    {
                        RoverRequest roverRequest = new RoverRequest();
                        roverRequest.Location = new Location();
                        roverRequest.Location.Planet = PlanetEnum.Mars;
                        roverRequest.Location.MaximumX = ExplorationRoverHelper.GetMaximumLocations(lines[0])[0];
                        roverRequest.Location.MaximumY = ExplorationRoverHelper.GetMaximumLocations(lines[0])[1];
                        roverRequest.Location.X = Convert.ToInt32(ExplorationRoverHelper.GetCoordinates(lines[i])[0]);
                        roverRequest.Location.Y = Convert.ToInt32(ExplorationRoverHelper.GetCoordinates(lines[i])[1]);
                        roverRequest.Location.CardinalDirection = CardinalDirectionConverter.FrontEndValueToEnum(ExplorationRoverHelper.GetCoordinates(lines[i])[2]);
                        marsRoverRequestList.Add(roverRequest);
                    }
                    else
                    {
                        RoverRequest roverRequest = marsRoverRequestList[count];
                        roverRequest.Rotation = lines[i];
                        marsRoverRequestList[count] = roverRequest;
                        count++;
                    }
                }
            }

            foreach (RoverRequest marsRoverRequest in marsRoverRequestList)
            {
                MarsExplorationRoverController marsController = new MarsExplorationRoverController();
                RoverRequest request = marsController.InitializeExplorationRover(marsRoverRequest);
                RoverResponse response = marsController.GetLatestLocation(request);

                string output = String.Format("{0} {1} {2}",
                response.Location.X,
                response.Location.Y,
                CardinalDirectionConverter.EnumToFrontEndValue(response.Location.CardinalDirection));
                Console.WriteLine(output);
            }
            Console.ReadKey();
        }

        private static bool ValidateLine(string line, int index)
        {
            LetterLineValidator validator = new LetterLineValidator();
            bool isValid = false;
            string validationMessage = "";

            #region MaximumPositionValidation
            if (index == 0)
            {
                try
                {
                    int[] maximumLocations = ExplorationRoverHelper.GetMaximumLocations(line);
                    isValid = validator.MinimumValueValidator(maximumLocations) && validator.MaxLenghtValidator(maximumLocations, MaximumLenghtConstans.MaximumLocation);
                    validationMessage = String.Format("Enter a different value than the minimum coordinates defined (x = {0}, y={1}) or don't enter more then {2} commands.",
                        LocationConstans.MinimumX, LocationConstans.MinimumY, MaximumLenghtConstans.MaximumLocation);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            #endregion
            #region FirstLineValidation
            else if (index % 2 == 1)
            {
                try
                {
                    string[] firstCordinates = ExplorationRoverHelper.GetCoordinates(line);
                    isValid = validator.MaxLenghtValidator(firstCordinates, MaximumLenghtConstans.RoverPosition);
                    validationMessage = String.Format("Dont enter more then {0} commands.",
                        MaximumLenghtConstans.RoverPosition);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            #endregion
            #region SecondLineValidation
            else if (index % 2 == 0)
            {
                char[] rotations = line.ToCharArray();
                isValid = validator.RotationValidator(rotations);
                validationMessage = String.Format("Please dont enter any values other than possible values");
            }
            #endregion

            if (!isValid) Console.WriteLine(validationMessage);
            return isValid;
        }

    }
}

