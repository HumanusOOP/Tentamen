#Uppgift 1a (3p)
 .Nets String-implementation innehåller bl.a. metoderna med följande signaturer.

	// Reports the zero-based index of the first occurrence of the specified string in this instance. 
	// Returns -1 if value could not be found
	public int IndexOf (string value);

	// Retrieves a substring from this instance. The substring starts at a specified character position and continues to the end of the string.
	public string Substring (int startIndex);
    
	// Reports the zero-based index position of the last occurrence of a specified string within this instance.
	// Returns -1 if value could not be found
    public int LastIndexOf (string value);
    


Antag för uppgiftens skull att `LastIndexOf` inte finns implementerad i string-klassen. Skriv en implementation av `LastIndexOf`.

#Uppgift 1b (2p)

Skriv några tester för din funktion och motivera de tester du skrivit.

#Uppgift 2a (6p)
Implementera en en FIFO-kö som uppfyller följande interface. Koden ska ge relevanta felmeddelanden vid felsituationer och klassers/metoders begränsningar ska vara tydligt definierade och dokumenterade.

	public interface IQueue<T>
    {
        // Adds an object to the end of the queue
        void Enqueue(T element);

        // Returns the object at the beginning of the queue without removing it
        T Peek();

        // Removes and returns the object at the beginning of the
        T Dequeue();

        // Empties the queue
        void Clear();

        // Determines whether an element is in the queue.
        bool Contains(T element);

        // Returns the number of elements in the queue
        int Size();
    }

#Uppgift 2b (4p)
Resonera kring de olika funktionernas tidskomplexitet. Kunde några metoder i kön haft annan tidskomplexitet genom enkla modifikationer i implementationen? I så fall hur?


# Uppgift 3 (5p)

Givet följande kod för representation av både filer och kataloger, skriv en funktion för att skriva ut namnen på alla filer i en given katalog, och alla dess underkataloger. (5p)

	
    public class File
    {
        public File(string name, bool isDirectory)
        {
            Name = name;
            IsDirectory = isDirectory;
        }

        public string Name { get; private set; }
        public bool IsDirectory { get; private set; }
        public List<File> Files { get; private set; } = new List<File>();
        public void AddFile(File file)
        {
            if (IsDirectory)
            { 
                Files.Add(file);
            }
            else
            {
                throw new Exception("Can only add files to directories");
            }
        }
    }

# Uppgift 4a (5p)
4a. Följande kod råkar följa ett design pattern, vilket? Beskriv designmönstrets syfte.


    public interface ITranslator
    {
        string Greet();
    }

    public class SwedishSpeaker
    {
        public string Hälsa()
        {
            return "Hej!";
        }
    }

    public class SwedishTranslator : ITranslator
    {
        private readonly SwedishSpeaker _speaker = new SwedishSpeaker();

        public string Greet()
        {
            return _speaker.Hälsa();
        }
    }

    public class ArabicSpeaker
    {
        private ITranslator _translator;

        public ArabicSpeaker(ITranslator translator)
        {
            _translator = translator;
        }

        public string رحب()
        {
            return _translator.Greet();
        }
    }

  
# Uppgift 4b (5p)
Gör ett UML-diagram där klassnamn ersatts av namn som lättare förknippas med det designmönster som är implementerat.

# Uppgift 5a (5p)
Följande kod strider mot en eller flera SOLID-principer en eller flera gånger. Beskriv åtminstone 2 av dessa och förklara varför koden strider mot dem.  

	public interface IVehicle
    {
        // Refills the fuel tank to the max. Returns the number of litres filled
        decimal FillTank();

        // Drives the vehicle a number of kilometres, using fuel while doing so.
        // If the vehicle runs out of fuel, remaining kilometers will not be driven.
        void Drive(int kilometers);

        // Returns the amount of fuel left, in whole percents of a full tank.
        int FuelLevel();

        void OpenDoor();

        bool IsDoorOpen { get; }
    }

    public class Motorbike : IVehicle
    {
        private decimal _fuelConsumption = 0.34m; // litres per kilometer
        private decimal _fuelCapacity = 18m; // litres
        private decimal _fuelLevel;

        public void Drive(int kilometers)
        {
            _fuelLevel = _fuelLevel - kilometers * _fuelConsumption;
            if(_fuelLevel < 0)
            {
                _fuelLevel = 0;
            }
        }

        public int FuelLevel()
        {
            return (int)Math.Round((_fuelLevel / _fuelCapacity) * 100);
        }

        public decimal FillTank()
        {
            var amountToFill = _fuelCapacity - _fuelLevel;
            _fuelLevel = _fuelCapacity;
            return amountToFill;
        }

        public void OpenDoor()
        {
        }

        public bool IsDoorOpen { get { return false; } }
    }

    public class Car : IVehicle
    {
        private decimal _fuelConsumption = 0.77m; // litres per kilometer
        private decimal _fuelCapacity = 52m; // litres
        private decimal _fuelLevel;

        public void Drive(int kilometers)
        {
            _fuelLevel = _fuelLevel - kilometers * _fuelConsumption;
            if (_fuelLevel < 0)
            {
                _fuelLevel = 0;
                throw new Exception("Not enough fuel");
            }
        }

        public int FuelLevel()
        {
            return (int)Math.Round((_fuelLevel / _fuelCapacity) * 100);
        }

        public decimal FillTank()
        {
            var amountToFill = _fuelCapacity - _fuelLevel;
            _fuelLevel = _fuelCapacity;
            return amountToFill;
        }

        public void OpenDoor()
        {
            IsDoorOpen = true;
        }

        public bool IsDoorOpen { get; private set; }
    }

# Uppgift 5b (5p)

Refaktorera koden i 5a, så att den inte längre strider mot principerna du nämnde i 5a. Om du måste förändra kodens publika kontrakt, beskriv på vilket sätt det påverkar eventuella konsumenter.

# Uppgift 6a (5p)
Läs följande kod och beskriv i så god detalj som möjligt vad du tror att den gör och varför.  

    public class CreateUserCommand
    {
        private readonly DbConnectionFactory connectionFactory;

        public CreateUserCommand(DbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public bool CreateUser(string email)
        {
            var connection = connectionFactory.Create();
            try
            {
                connection.Open();

                var transaction = connection.BeginTransaction();
                var command = connection.CreateCommand();
                command.Transaction = transaction;

                const string ExistingUserSql = "SELECT COUNT(1) FROM [User] u WHERE u.Email = @email";
                command.Command = ExistingUserSql;
                command.Parameters = new { email = email };

                if (await command.QueryFirstAsync<int>() == 0)
                {
                    const string InsertIntoUserSql = "INSERT INTO [User] (Email) VALUES (@email)";
                    var insertCommand = connection.CreateCommand();
                    insertCommand.Transaction = transaction;
                    insertCommand.Command = InsertIntoUserSql;
                    insertCommand.Parameters = new { email = email };
                    await command.ExecuteAsync();
                    transaction.Commit();
                    return true;
                }

                return false;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }



# Uppgift 6b (5p)
Läs följande kod och beskriv i så god detalj som möjligt vad du tror att den gör och varför.

	static async void Main(string[] args)
    {
        Task t = Download();
        Console.WriteLine("Downloads started");
        await t;
        Console.WriteLine("Downloads complete");
    }

    static async Task Download()
    {
        var client = new HttpClient();
        var task1 = client.GetAsync("http://www.verylarge.com/image");
        var task2 = client.GetAsync("http://www.superbig.com/video");
        var task3 = client.GetAsync("http://www.manybytes.com/tothemoonandback");    
        await Task.WhenAll(task1, task2, task3);
    }
