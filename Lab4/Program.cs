class Program
{
    static void Main()
    {
        Console.WriteLine("--- Демонстрация иерархии классов ---");

        // Создаем объекты разных классов
        UIElement basicElement = new Control("Элемент", 10, 10);
        Button actionButton = new Button("Отправить", 20, 20, ConsoleColor.Green);
        ImageButton profileButton = new ImageButton("Профиль", 30, 30, ConsoleColor.Blue, "user_icon.png");
        RoundButton playButton = new RoundButton("Играть", 40, 40, ConsoleColor.Yellow, 25);

        // Демонстрация полиморфизма (вызов виртуальных/абстрактных методов)
        Console.WriteLine("\n--- Демонстрация отрисовки ---");
        basicElement.Render();
        actionButton.Render();
        profileButton.Render();
        playButton.Render();

        Console.WriteLine("\n--- Демонстрация нажатий ---");
        actionButton.Click(); // Виртуальный метод
        profileButton.Click(); // Переопределённый метод
        playButton.Click(); // Виртуальный метод

        Console.WriteLine("\n--- Демонстрация собственных методов ---");
        profileButton.DisplayImage();
        playButton.Spin();
        actionButton.Disable();
        
        Console.WriteLine("\n--- Повторное нажатие после блокировки ---");
        actionButton.Click();
        
        Console.WriteLine("\n--- Демонстрация ToString() ---");
        Console.WriteLine(basicElement.ToString());
        Console.WriteLine(actionButton.ToString());
        Console.WriteLine(profileButton.ToString());
        Console.WriteLine(playButton.ToString());
    }
}