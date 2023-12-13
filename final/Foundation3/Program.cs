using System;
//3
class Program
{
    static void Main(string[] args)
    {

        Address eventAddress1 = new Address("9875 Main ST", "Salt Lake", "Utah", "USA", "70036");
        Address eventAddress2 = new Address("2825 Ridge RD", "Mesa", "Arizona", "USA", "15672");
        Address eventAddress3 = new Address("7569 Valv", "San Jose", "Perez Zeledon", "Costa Rica", "12356");

        Lectures lecture = new Lectures("Book of mormon lecture", "Get closer to Christ by reading and understanding the scriptures with us in this marathon", "01/01/2024", "10:00 (am)", eventAddress1, "Russell M Nelson", 100);
        Receptions reception = new Receptions("Wedding Reception", "Come and join John & Fatima's wedding reception", "12/25/2023", "18:00 (6pm)", eventAddress2, "getJFinvitation@gmail.com");
        OG oG = new OG("Anual Vaccination against the flu", "Health comes first, and here we all believe that as health is a right for everyone, it must be free! Come join us to our annual vaccination against the flu", "02/26/2024", "14:00 (2pm)", eventAddress3, "Sunny day");




        Console.WriteLine("--- Lecture ---");
        Console.WriteLine("Standard details:\n" + lecture.TDDTA());
        Console.WriteLine("\n\nFull details:\n" + lecture.detailedInfo());
        Console.WriteLine("\n\nShort Description:\n" + lecture.shortDescription());

        Console.WriteLine("\n--- Reception ---");
        Console.WriteLine("Standard details:\n" + reception.TDDTA());
        Console.WriteLine("\n\nFull details:\n" + reception.detailedInfo());
        Console.WriteLine("\n\nShort Description:\n" + reception.shortDescription());

        Console.WriteLine("\n--- Outdoor Gathering ---");
        Console.WriteLine("Standard details:\n" + oG.TDDTA());
        Console.WriteLine("\n\nFull details:\n" + oG.detailedInfo());
        Console.WriteLine("\n\nShort Description:\n" + oG.shortDescription());


    }
}