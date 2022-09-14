using OOPReview1;
namespace TestOOPReview1
{
    [TestClass]
    public class RosterTest
    {
        [TestMethod]
        [DataRow(97, "Connor McDavid", NhlPosition.C)]
        [DataRow(18, "Zach Hyman", NhlPosition.LW)]
        [DataRow(25, "Darnell Nurse", NhlPosition.D)]
        public void Constructor_ValidValues_SetsNoNamePosition(int playerNo, string playerName, NhlPosition playerPosition)
        {
            // Arrange
            NhlRoster validPlayer1 = new NhlRoster(playerNo, playerName, playerPosition);

            // Act & Assert
            Assert.AreEqual(playerNo, validPlayer1.PlayerNumber);
            Assert.AreEqual(playerName, validPlayer1.PlayerName);
            Assert.AreEqual(playerPosition, validPlayer1.Position);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(99)]
        public void No_InvalidNO_ThrowsArgumentOutOfRangeException(int playerNo)
        {

            // Act and Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => 
            {
                // Arrange
                NhlRoster invalidPlayer1 = new NhlRoster(playerNo, "Connor McDavid", NhlPosition.C);
            }
            );
            Assert.AreEqual("Player number must be between 0 and 98", exception.ParamName);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void Player_InvalidPlayerName_ThrowsArgumentNullException(string playerName)
        {

            // Act and Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                // Arrange
                NhlRoster invalidPlayer1 = new NhlRoster(97, playerName, NhlPosition.C);
            }
            );
            Assert.AreEqual("Name must contain text", exception.ParamName);
        }
    }
}