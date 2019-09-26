using Cegid.TechnicalTests.Data;
using Cegid.TechnicalTests.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace Cegid.TechnicalTests.ConsoleApp
{
    public class Program
    {
        enum Command
        {
            ExitProgram,
            CountCustomers,
            ListCustomers,
            CreateCustomer,
            CreateRooms,
            CreateReservation
        }

        public static async Task Main()
        {
            WriteLine("Please type the code of a task:");
            WriteLine("0\tExit");
            WriteLine("1\tCount customers");
            WriteLine("2\tList customers");
            WriteLine("3\tCreate customer");
            WriteLine("4\tCreate rooms");
            WriteLine("5\tCreate reservation");
            WriteLine("6\tDisable customer");

            var command = (Command)Enum.Parse(typeof(Command), ReadLine());

            var task = command switch
            {
                Command.ExitProgram => ExitProgramAsync(),
                Command.CountCustomers => CountCustomersAsync(),
                Command.ListCustomers => ListCustomersAsync(),
                Command.CreateCustomer => CreateCustomerAsync(),
                Command.CreateRooms => CreateRoomsAsync(),
                Command.CreateReservation => CreateReservationAsync(),
                _ => Main()
            };
            await task;
            await Main();
        }

        public static async Task CountCustomersAsync()
        {
            using var context = new CegidDbContext();

            var query = context.Customers
                .Where(c => c.IsEnabled);

            WriteLine($"Customers: {await query.CountAsync()}");
        }

        public static async Task ListCustomersAsync()
        {
            using var context = new CegidDbContext();

            var query = context.Customers
                .Where(c => c.IsEnabled);

            WriteLine("Number of clients to take:");
            var take = int.Parse(ReadLine());
            query = query.Take(take);

            WriteLine("Number of clients to skip:");
            var skip  = int.Parse(ReadLine());
            query = query.Skip(skip);

            foreach (var customer in await query.ToListAsync())
                WriteLine(customer);
        }

        public static async Task CreateCustomerAsync()
        {
            Write("First name: ");
            var firstName = ReadLine();

            Write("Last name: ");
            var lastName = ReadLine();

            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName
            };
            WriteLine($"Creation of \n{customer}");

            using var context = new CegidDbContext();
            context.Add(customer);
            await context.SaveChangesAsync();
        }

        public static async Task CreateRoomsAsync()
        {
            using var context = new CegidDbContext();
            if (await context.Rooms.AnyAsync())
            {
                WriteLine("Already created.");
                return;
            }
            for (int floor = 0; floor < 6; floor++)
            {
                for (int n = 0; n < 10; n++)
                {
                    var room = new Room
                    {
                        Number = floor * 100 + n,
                        Floor = floor
                    };
                    context.Add(room);
                }
            }
            await context.SaveChangesAsync();
        }

        public static async Task CreateReservationAsync()
        {
            Write("Customer id:");
            var customerId = ReadLine();

            DateTime start;
            do
            {
                Write("Start date (dd/mm/yyyy):");
            } while (!DateTime.TryParseExact(ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out start));

            DateTime end;
            do
            {
                Write("End date (dd/mm/yyyy):");
            } while (!DateTime.TryParseExact(ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out end));

            Write("Room number:");
            var roomN = int.Parse(ReadLine());

            using (var context = new CegidDbContext())
            {
                var room = await context.Rooms.FirstOrDefaultAsync(r => r.Number == roomN);
                var reservation = new Reservation
                {
                    CustomerId = customerId,
                    Start = start,
                    End = end,
                    RoomId = room.Id
                };
                context.Reservations.Add(reservation);
                await context.SaveChangesAsync();
            }
        }

        public static Task ExitProgramAsync() => Task.Run(() => Environment.Exit(0));
    }
}