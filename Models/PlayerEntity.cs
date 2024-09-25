using System;
using System.Numerics;
using futMatchSim.Models.Enums;

namespace futMatchSim.Models
{
	public class PlayerEntity
	{
		public string firstName { get; set; }
        public string lastName { get; set; }
		public int shirtNumber;
		private GamePosition gamePosition;

		private Vector3 position = new Vector3(0, 0, 0);
		private Vector3 direction = new Vector3(0, 0, 0);
		private float speed = 0.0f;


        public PlayerEntity(string firstName, string lastName, int number, Vector3 position)
		{
			this.firstName = firstName;
			this.lastName = lastName;
			this.shirtNumber = number;
			this.position = position;
		}

		public Vector3 updatePos()
		{
			this.position += this.direction * this.speed * (float) Program.deltaTime;

			if (Program.devMode) {
				Console.WriteLine("Player " + this.gamePosition + " " + this.lastName + "(" + this.shirtNumber + ") moved to " + this.position.ToString());
			}

			return this.position;
        }

		public void setNewDirection(Vector3 dir, float speed)
		{
			this.direction = dir;
			this.speed = speed;
		}

	}
}

