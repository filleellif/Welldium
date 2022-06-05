namespace Welldium.Domain.Test;

public abstract class RobotTest
{
    private readonly Robot _sut;

    protected RobotTest()
    {
        var id = Guid.NewGuid();
        var name = Guid.NewGuid().ToString();
        var area = new Area(new Point(1, 1), new Size(10, 10));

        _sut = new Robot(id, name, area);
    }

    public sealed class When_initializing : RobotTest
    {
        [Fact]
        public void It_places_robot_in_the_middle()
        {
            var expected = new Point(6, 6);

            var actual = _sut.Position;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void It_starts_heading_up()
        {
            var expected = Direction.Up;

            var actual = _sut.Direction;

            Assert.Equal(expected, actual);
        }
    }

    public sealed class When_advancing : RobotTest
    {
        [Fact]
        public void When_facing_up_it_moves_up()
        {
            _sut.Advance();

            var expected = new Point(6, 7);
            var actual = _sut.Position;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void When_facing_left_it_moves_left()
        {
            _sut.TurnLeft();
            _sut.Advance();

            var expected = new Point(5, 6);
            var actual = _sut.Position;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void When_facing_right_it_moves_right()
        {
            _sut.TurnRight();
            _sut.Advance();

            var expected = new Point(7, 6);
            var actual = _sut.Position;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void When_facing_down_it_moves_down()
        {
            _sut.TurnRight();
            _sut.TurnRight();
            _sut.Advance();

            var expected = new Point(6, 5);
            var actual = _sut.Position;

            Assert.Equal(expected, actual);
        }
    }

    public sealed class When_turning_left : RobotTest
    {
        [Theory]
        [InlineData(1, Direction.Left)]
        [InlineData(2, Direction.Down)]
        [InlineData(3, Direction.Right)]
        [InlineData(4, Direction.Up)]
        public void It_changes_direction_correctly(int numberOfTurns, Direction expected)
        {
            for (int i = 0; i < numberOfTurns; i++)
            {
                _sut.TurnLeft();
            }

            var actual = _sut.Direction;

            Assert.Equal(expected, actual);
        }
    }

    public sealed class When_turning_right : RobotTest
    {
        [Theory]
        [InlineData(1, Direction.Right)]
        [InlineData(2, Direction.Down)]
        [InlineData(3, Direction.Left)]
        [InlineData(4, Direction.Up)]
        public void It_changes_direction_correctly(int numberOfTurns, Direction expected)
        {
            for (int i = 0; i < numberOfTurns; i++)
            {
                _sut.TurnRight();
            }

            var actual = _sut.Direction;

            Assert.Equal(expected, actual);
        }
    }
}