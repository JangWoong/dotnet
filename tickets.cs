string file = "Tickets.csv";
string choice;
do
{
    // ask user a question
    Console.WriteLine("1) Read data from file.");
    Console.WriteLine("2) Create file from data.");
    Console.WriteLine("3) Add records to the file.");
    Console.WriteLine("Enter any other key to exit.");
    // input response
    choice = Console.ReadLine();

    if (choice == "1")
    {
        // read data from file
        if (File.Exists(file))
        {
            // read data from file
            StreamReader sr = new StreamReader(file);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                // display data
                Console.WriteLine(line);
            }
            sr.Close();
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }
    else if (choice == "2")
    {
        // create file from data
        StreamWriter sw = new StreamWriter(file);
        // save header
        sw.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching");
        bool datainput = true;
        int ticketID = 1;

        while (datainput)
        {          
            Console.Write("Enter the Summary: ");
            string summary = Console.ReadLine();

            Console.Write("Enter the Status: ");
            string status = Console.ReadLine();

            Console.Write("Enter the Priority: ");
            string priority = Console.ReadLine();

            Console.Write("Enter the Submitter: ");
            string submitter = Console.ReadLine();

            Console.Write("Enter the Assigned: ");
            string assigned = Console.ReadLine();

            Console.Write("Enter the Watching: ");
            string watching = Console.ReadLine();

            // save 
            sw.WriteLine($"{ticketID.ToString()},{summary},{status},{priority},{submitter},{assigned},{watching}");
            // ask a question
            Console.WriteLine("Do you want more input data (Y/N)? Pressing any key other than 'Y' will exit.");
            if(Console.ReadLine().ToUpper() == "Y")
                datainput = true;
            else
                datainput = false;

            ticketID++;
        }
        sw.Close();
    }
    else if (choice == "3")
    {
        // read data from file
        if (File.Exists(file))
        {
            int ticketID = 1;

            // read data from file
            StreamReader sr = new StreamReader(file);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] arr = line.Split(',');
                
                // check the number
                bool result  = int.TryParse(arr[0], out ticketID);

                // display data
                Console.WriteLine(line);
            }
            sr.Close();

            StreamWriter sw = File.AppendText(file);
            bool datainput = true;

            while (datainput)
            {
                ticketID++;

                Console.Write("Enter the Summary: ");
                string summary = Console.ReadLine();

                Console.Write("Enter the Status: ");
                string status = Console.ReadLine();

                Console.Write("Enter the Priority: ");
                string priority = Console.ReadLine();

                Console.Write("Enter the Submitter: ");
                string submitter = Console.ReadLine();

                Console.Write("Enter the Assigned: ");
                string assigned = Console.ReadLine();

                Console.Write("Enter the Watching: ");
                string watching = Console.ReadLine();

                // save 
                sw.WriteLine($"\n{ticketID.ToString()},{summary},{status},{priority},{submitter},{assigned},{watching}");
                // ask a question
                Console.WriteLine("Do you want more input data (Y/N)? Pressing any key other than 'Y' will exit.");
                if(Console.ReadLine().ToUpper() == "Y")
                    datainput = true;
                else
                    datainput = false;
            }
            sw.Close();
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }
} while (choice == "1" || choice == "2"|| choice == "3");
