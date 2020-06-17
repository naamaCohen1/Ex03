using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        private GarageManager m_GarageManager;
        private InputValidation m_InputValidation;

        public UserInterface()
        {
            m_GarageManager = new GarageManager();
            m_InputValidation = new InputValidation();
        }

        public void RunApp()
        {
            bool exitGarage = false;

            while(!exitGarage)
            {
                showMainMenu();
                exitGarage = getUserChoise();
            }

            Console.WriteLine("Thanks for using our Garage! GoogBye..");
            Environment.Exit(0);
        }

        private void showMainMenu()
        {
            StringBuilder menu = new StringBuilder();
            Console.Write(@"
Welcome to our Garage. Please choose an option:
        1. Enter a vehicle to the garage 
        2. Show vehicles' License numbers in garage
        3. Change vehicle status
        4. Fill air pressure to Max
        5. Refuel vehicle
        6. Charge Battert vehicle
        7. Show vehicle's data
        8. Exit
Your choice: ");
        }

        private bool getUserChoise() 
        {
            bool exit = false;
            int userChoice;

            try
            {
                userChoice = m_InputValidation.CheckIfInt(Console.ReadLine()); 
                switch (userChoice)
                {
                    case 1:
                        addGarageVehicle();
                        break;
                    case 2:
                        showVehicleInGarage();
                        break;
                    case 3:
                        changeVehicleStatus();
                        break;
                    case 4:
                        fillAirPressureToMax();
                        break;
                    case 5:
                        refuelVehicle();
                        break;
                    case 6:
                        chargeBatteryVehicle();
                        break;
                    case 7:
                        printVehicleData();
                        break;
                    case 8:
                        exit = true;
                        break;
                    default:
                        Console.Write("Invalid choice - {0}, please try again.{1}Your choice: ", userChoice, Environment.NewLine);
                        getUserChoise();
                        break;
                }
            }
            catch(FormatException fe)
            {
                Console.WriteLine(string.Format("{0}, Please try again.{1}Your choice: ", fe.Message, Environment.NewLine));
                getUserChoise();
            }

            return exit;
        }

        private void addGarageVehicle()
        {
            try
            {
                string licenseNumber = getLicenseNumber(); 
                if(m_GarageManager.CheckIfVehicleInGarage(licenseNumber))
                {
                    Console.WriteLine("The Vehicle is already in the Garage. Vehicle status was change to 'IN PROGRESS'");
                }
                else
                {
                    addNewVehicle(licenseNumber);
                    Console.WriteLine(string.Format("Vehicle with License number '{0}' was Entered to the garage.", licenseNumber));
                }
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(string.Format("{0}{1}Please Try Again.", ae.Message, Environment.NewLine));
                addGarageVehicle();
            }
        }

        private string getLicenseNumber()
        {
            Console.Write("Please enter the vehicle's license number: ");
            string licenseNumber = m_InputValidation.CheckLicenseNumber(Console.ReadLine(), "License Number");
            return licenseNumber;
        }

        private void addWheelParametes(string i_LicenseNumber)
        {
            string manufactureName = null;
            float leftedAirPressure = 0;
            try
            {
                getWheelParametes(ref manufactureName, ref leftedAirPressure);
                m_GarageManager.AddWheelDetails(manufactureName, leftedAirPressure, i_LicenseNumber);
            }
            catch(ValueOutOfRangeException voor)
            {
                Console.WriteLine(string.Format("{0}, Please Try Again.", voor.Message, Environment.NewLine));
                addWheelParametes(i_LicenseNumber);
            }
        }

        private void addModelAndLeftedEnergyPresent(string i_LicenseNumber)
        {
            string vehicleModel = null;
            float leftedEnergyPrecent = 0;
            try
            {
                getModelAndLeftedEnergyPresent(ref vehicleModel, ref leftedEnergyPrecent);
                m_GarageManager.AddModelAndLeftedEnergyPrecent(vehicleModel, leftedEnergyPrecent, i_LicenseNumber);
            }
            catch (Exception ex)
            {
                if(ex is ArgumentException || ex is ValueOutOfRangeException)
                {
                    Console.WriteLine(string.Format("{0}, Please Try Again.", ex.Message, Environment.NewLine));
                    addModelAndLeftedEnergyPresent(i_LicenseNumber);
                }
            }
        }

        private void getModelAndLeftedEnergyPresent(ref string io_VehicleModel, ref float io_LeftedEnergyPrecent)
        {
            try
            {
                Console.Write("Please enter your vehicle model: ");
                io_VehicleModel = m_InputValidation.CheckName(Console.ReadLine());
                Console.Write("Please enter vehicle's lefted energy precent: ");
                io_LeftedEnergyPrecent = m_InputValidation.CheckIfFloat(Console.ReadLine());
            }
            catch (FormatException fe)
            {
                Console.WriteLine(string.Format("{0}, Please try again.", fe.Message));
                getModelAndLeftedEnergyPresent(ref io_VehicleModel, ref io_LeftedEnergyPrecent);
            }
        }

        private void addNewVehicle(string i_LicenseNumber) 
        {
            string owner = null, ownerPhone = null, vehicleModel = null;
            int vehicleType = 0;
            float leftedEnergyPrecent = 0f;

            try
            {
                getNewVehicleDetails(ref owner, ref ownerPhone, ref vehicleType, ref vehicleModel, ref leftedEnergyPrecent); 
                m_GarageManager.EnterNewVehicle(owner, ownerPhone, vehicleType, i_LicenseNumber);
                addModelAndLeftedEnergyPresent(i_LicenseNumber);
                getAdditionalParameters(vehicleType, i_LicenseNumber);
                addWheelParametes(i_LicenseNumber);
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(string.Format("{0}, Please Try Again.", ae.Message, Environment.NewLine));
                addNewVehicle(i_LicenseNumber);
            }
        }

        private void getNewVehicleDetails(
            ref string io_Owner, ref string io_OwnerPhone, ref int io_VehicleType, ref string io_VehicleModel, ref float io_LeftedEnergyPrecent)
        {
            try
            {
                Console.Write("Please enter your name: ");
                io_Owner = m_InputValidation.CheckName(Console.ReadLine());
                Console.Write("Please enter your phone number: ");
                io_OwnerPhone = m_InputValidation.CheckNumber(Console.ReadLine(), "Owner Phone Number");
                Console.Write(@"Please enter your vehicle type:
        1. FUEL_CAR
        2. ELECTRIC CAR
        3. FUEL MOTORCYCLE
        4. ELECTRIC MOTORCYCLE
        5. TRUCK
Your choice: ");
                io_VehicleType = m_InputValidation.CheckIfInt(Console.ReadLine());
            }
            catch(Exception ex)
            {
                if(ex is ArgumentException || ex is FormatException)
                {
                    Console.WriteLine(string.Format("{0}, Please Try Again.", ex.Message));
                    getNewVehicleDetails(ref io_Owner, ref io_OwnerPhone, ref io_VehicleType, ref io_VehicleModel, ref io_LeftedEnergyPrecent);
                }
                else
                {
                    throw;
                }
            }
        }

        private void getAdditionalParameters(int i_vehicleType, string i_LicenseNumber) 
        {
            string vehicleType = m_GarageManager.GetVehicleTypeAsString(i_vehicleType);

            if(vehicleType.Contains("CAR"))
            {
                getCarParameters(i_LicenseNumber);
            }
            else if(vehicleType.Contains("MOTORCYCLE"))
            {
                getMotoecycleParameters(i_LicenseNumber);
            }
            else if(vehicleType.Contains("TRUCK"))
            {
                getTruckParameters(i_LicenseNumber);
            }
        }

        private void getMotoecycleParameters(string i_LicenseNumber) 
        {
            int engineCapacity, licenseType;

            try
            {
                Console.Write(@"Please enter your lisence Type: 
        1. A
        2. A1
        3. AA
        4. B
Your choice: ");
                licenseType = m_InputValidation.CheckIfInt(Console.ReadLine());
                Console.Write("Please enter your engine capacity [cm^2]: ");
                engineCapacity = m_InputValidation.CheckIfInt(Console.ReadLine());
                m_InputValidation.CheckNumber(engineCapacity.ToString(), "Engine Capacity");
                m_GarageManager.SetMotorcycleAdditionalParams(i_LicenseNumber, licenseType, engineCapacity); 
            }
            catch(Exception ex)
            {
                if(ex is ArgumentException || ex is FormatException)
                {
                    Console.WriteLine(string.Format("{0}, Please Try Again.", ex.Message));
                    getMotoecycleParameters(i_LicenseNumber);
                }
                else
                {
                    throw;
                }
            }
        }

        private void getCarParameters(string i_LicenseNumber) 
        {
            int vehicleColor, numOfDoors;

            try
            {
                Console.Write(@"Please enter your vehicle color: 
        1. RED
        2. WHITE
        3. BLACK
        4. SILVER
Your choice: ");
                vehicleColor = m_InputValidation.CheckIfInt(Console.ReadLine());
                Console.Write("Please enter your number of doors [2, 3, 4, 5]: ");
                numOfDoors = m_InputValidation.CheckIfInt(Console.ReadLine());

                m_GarageManager.SetCarAdditionalParams(i_LicenseNumber, vehicleColor, numOfDoors);
            }
            catch(Exception ex)
            {
                if(ex is ArgumentException || ex is FormatException)
                {
                    Console.WriteLine(string.Format("{0}, Please Try Again.", ex.Message));
                    getCarParameters(i_LicenseNumber);
                }
                else
                {
                    throw;
                }
            }
        }

        private void getTruckParameters(string i_LicenseNumber) 
        {
            bool isTransportingDangerousMaterial;
            float cargoCapacity;

            try
            {
                Console.Write("Do you transfer dangerous materials [true / false]: ");
                isTransportingDangerousMaterial = m_InputValidation.CheckIfBool(Console.ReadLine().ToLower()); 
                Console.Write("Please enter cargo capacity: ");
                cargoCapacity = m_InputValidation.CheckIfFloat(Console.ReadLine()); 

                m_GarageManager.SetTruckAdditionalParams(i_LicenseNumber, isTransportingDangerousMaterial, cargoCapacity);
            }
            catch(Exception ex)
            {
                if (ex is ArgumentException || ex is FormatException)
                {
                    Console.WriteLine(string.Format("{0}, Please try again.", ex.Message));
                    getTruckParameters(i_LicenseNumber);
                }
            }
        }

        private void showVehicleInGarage()
        {
            bool showAllVehicles;

            try
            {
                Console.Write("Do you want to see all garage vehicles? [true / false]: ");
                showAllVehicles = m_InputValidation.CheckIfBool(Console.ReadLine().ToLower());

                if(showAllVehicles)
                {
                    showAllVehicleInGarage();
                }
                else
                {
                    showVehicleInGarageByStatus();
                }
            }
            catch(FormatException fe)
            {
                Console.WriteLine(string.Format("{0}, Please try again.", fe.Message));
                showVehicleInGarage();
            }
        }

        private void showAllVehicleInGarage()
        {
            StringBuilder listToPrint = new StringBuilder();

            List<string> garageVehicles = m_GarageManager.GetAllVehiclesInGarage();

            if(garageVehicles.Count != 0)
            {
                listToPrint.AppendLine("Vehicles' License number in the Garage: ");
                foreach (string vehicleLicenseNum in garageVehicles)
                {
                    listToPrint.AppendLine(vehicleLicenseNum);
                }
            }
            else
            {
                listToPrint.AppendLine("There are no vehicle in the garage.");
            }

            Console.WriteLine(listToPrint);
        }

        private void showVehicleInGarageByStatus() 
        {
            StringBuilder listToPrint = new StringBuilder();

            try
            {
                int status = getRequestedStatus();
                List<string> filteredVehicleList = m_GarageManager.GetVehiclesInGarageByStatus(status); 
                eVehicleStatus vehicleStatus = m_GarageManager.CheckIfValidStatusParam(status);

                if(filteredVehicleList.Count != 0)
                {
                    listToPrint.AppendLine(string.Format("Vehicles' License number with status {0}", vehicleStatus.ToString()));
                    foreach (string vehicleLicenseNum in filteredVehicleList)
                    {
                        listToPrint.AppendLine(vehicleLicenseNum);
                    }
                }
                else
                {
                    listToPrint.AppendLine(string.Format("There are no vehicle with status {0} in the garage.", vehicleStatus.ToString()));
                }

                Console.WriteLine(listToPrint);
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(string.Format("{0}, Please Try Again.", ae.Message));
                showVehicleInGarageByStatus();
            }
        }

        private void changeVehicleStatus() 
        {
            try
            {
                string licenseNumber = getLicenseNumber(); 
                int status = getRequestedStatus();
                m_GarageManager.ChangeGarageVehicleStatus(licenseNumber, status); 
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(string.Format("{0}, Please Try Again.", ae.Message));
                changeVehicleStatus();
            }
        }

        private int getRequestedStatus() 
        {
            int status = 0;
            try
            {
                Console.Write(@"Please enter the requested status:
        1. IN_PROGRESS
        2. PAID
        3. DONE
Your choice: ");
                status = m_InputValidation.CheckIfInt(Console.ReadLine());
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(string.Format("{0}, Please Try Again.", ae.Message));
                getRequestedStatus();
            }

            return status;
        }

        private void fillAirPressureToMax() 
        {
            try
            {
                string licenseNumber = getLicenseNumber(); 
                m_GarageManager.FillAirPressureToMax(licenseNumber); 
                Console.WriteLine(string.Format("Vehicle with License num. {0} Wheels were filled", licenseNumber));
            }
            catch(Exception ex)
            {
                if(ex is ArgumentException || ex is ValueOutOfRangeException)
                {
                    Console.WriteLine(string.Format("{0}, Please Try Again.", ex.Message));
                    fillAirPressureToMax();
                }
                else
                {
                    throw;
                }
            }
        }

        private void refuelVehicle() 
        {
            string licenseNumber;
            float amountToAdd;
            int fuelType;

            try
            {
                licenseNumber = getLicenseNumber(); 
                Console.Write(@"Please enter vehicle's fuel type: 
        1. SOLER
        2. OCTAN_95
        3. OCTAN_96
        4. OCTAN_98             
Your choice: ");
                fuelType = m_InputValidation.CheckIfInt(Console.ReadLine());
                Console.Write("Please enter amount of fuel to add: ");
                amountToAdd = m_InputValidation.CheckIfFloat(Console.ReadLine()); 
                m_GarageManager.RefuelVehicleEnergy(licenseNumber, fuelType, amountToAdd); 
                Console.WriteLine(string.Format("Vehicle with License num. {0} was refuel", licenseNumber));
            }
            catch (Exception ex)
            {
                if(ex is FormatException || ex is ValueOutOfRangeException)
                {
                    Console.WriteLine(string.Format("{0}, Please Try Again.", ex.Message));
                    refuelVehicle();
                }
                else if(ex is ArgumentException)
                {
                    if(ex.Message.Contains("is not a Fuel Vehicle"))
                    {
                        Console.WriteLine(ex.Message);
                    }
                    else
                    {
                        Console.WriteLine(string.Format("{0}, Please Try Again.", ex.Message));
                        refuelVehicle();
                    }
                }
                else
                {
                    throw;
                }
            }
        }

        private void chargeBatteryVehicle() 
        {
            string licenseNumber;
            float minToCharge = 0f;

            try
            {
                licenseNumber = getLicenseNumber(); 
                Console.Write("Please enter num of nimutes to charge: ");
                minToCharge = m_InputValidation.CheckIfFloat(Console.ReadLine()); 
                m_GarageManager.ChargeVehicleEnergy(licenseNumber, minToCharge); 
                Console.WriteLine(string.Format("Vehicle with License num. {0} was charged", licenseNumber));
            }
            catch(Exception ex)
            {
                if(ex is FormatException || ex is ValueOutOfRangeException)
                {
                    Console.WriteLine(string.Format("{0}, Please Try Again.", ex.Message));
                    chargeBatteryVehicle();
                }
                else if(ex is ArgumentException)
                {
                    if(ex.Message.Contains("is not an Electric Vehicle"))
                    {
                        Console.WriteLine(ex.Message);
                    }
                    else
                    {
                        Console.WriteLine(string.Format("{0}, Please Try Again.", ex.Message));
                        chargeBatteryVehicle();
                    }
                }
                else
                {
                    throw;
                }
            }
        }

        private void getWheelParametes(ref string i_ManufactureName, ref float i_LeftedAirPressure) 
        {
            try
            {
                Console.Write("Please Enter Wheel's Manufacture Name: ");
                i_ManufactureName = m_InputValidation.CheckName(Console.ReadLine());
                Console.Write("Please Enter wheel's lefted air pressure: ");
                i_LeftedAirPressure = m_InputValidation.CheckIfFloat(Console.ReadLine()); 
            }
            catch(FormatException fe)
            {
                Console.WriteLine(string.Format("{0}, Please try againg.", fe.Message));
            }
        }

        private void printVehicleData() 
        {
            try
            {
                string licenseNumber = getLicenseNumber(); 
                Console.WriteLine(m_GarageManager.GetVehicleData(licenseNumber));
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(string.Format("{0}, Please Try Again.", ae.Message));
                printVehicleData();
            }
        }
    }
}