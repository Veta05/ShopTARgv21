using ShopTARgv21.Core.Dto;

namespace ShopTARgv21.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
        {
            string guid = Guid.NewGuid().ToString();

            SpaceshipDto spaceship = new SpaceshipDto();

            spaceship.Id = Guid.Parse(guid);
            spaceship.Name = "asd";
            spaceship.ModelType = "asd";
            spaceship.SpaceshipBuilder = "asd";
            spaceship.PlaceOfBuild = "asd";
            spaceship.EnginePower = 1;
            spaceship.LiftUpToSpaceByTonn = 1;
            spaceship.Crew = 1;
            spaceship.Passengers = "3";
            spaceship.LaunchDate = DateTime.Now;
            spaceship.BuildOfDate = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipServices>().Create(spaceship);

            Assert.NotNull(result);
        }
    }
}