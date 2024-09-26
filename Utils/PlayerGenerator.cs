using System;
using System.Numerics;
using futMatchSim.Models;
using futMatchSim.Models.Tactics;

namespace futMatchSim.Utils
{
	public class PlayerGenerator
	{
        private static string[] names = new string[]
        {
            "Antonio", "Manuel", "José", "Francisco", "David",
            "Juan", "Javier", "José Antonio", "Daniel", "Francisco Javier",
            "Carlos", "Jesús", "Alejandro", "Miguel", "José Luis",
            "Rafael", "Pedro", "Ángel", "Miguel Ángel", "José Manuel"
        };

        private static string[] last_names = new string[]
        {
            "García", "Rodríguez", "González", "Fernández", "López",
            "Martínez", "Sánchez", "Pérez", "Gómez", "Martín",
            "Jiménez", "Ruiz", "Hernández", "Díaz", "Moreno",
            "Muñoz", "Álvarez", "Romero", "Alonso", "Gutiérrez"
        };

        public static PlayerEntity generatePlayer()
        {
            Random random = new Random();

            string name = names[random.Next(names.Length)];
            string last_name = last_names[random.Next(last_names.Length)];

            PlayerEntity pe = new PlayerEntity(name, last_name, 1 + random.Next(99), new Vector3(random.Next(105) - 52, random.Next(64) - 32, 0));


            return pe;
        }

        public static Dictionary<PlayerEntity, TacticalOrders> generateTeam()
        {
            Dictionary<PlayerEntity, TacticalOrders> players = new Dictionary<PlayerEntity, TacticalOrders>();
            for (int i = 0; i < 11; i++)
            {
                players.Add(generatePlayer(), new TacticalOrders(false));
            }
            for (int i = 0; i < 7; i++)
            {
                players.Add(generatePlayer(), new TacticalOrders(true));
            }
            return players;
        }
	}
}

