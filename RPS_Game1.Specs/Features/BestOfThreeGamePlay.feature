Feature: GamePlay
	When a game of RPS is on between two players
	The format is best 2 out of 3
	
@CI
Scenario: Player 1 wins the first two rounds he wins
	Given a game is started with two players
	When Player 1 wins the round
	 And Player 1 wins the round
	Then Player 1 is the winner

@CI
Scenario: Player 1 wins the first and the third rounds he wins
	Given a game is started with two players
	When Player 1 wins the round
	 And Player 2 wins the round
	 And Player 1 wins the round
	Then Player 1 is the winner

@CI
Scenario: Player 2 wins the first round but  Player 1 wins the last two rounds
	Given a game is started with two players
	When Player 2 wins the round
	 And Player 1 wins the round
	 And Player 1 wins the round
	Then Player 1 is the winner

@CI
Scenario: Player 2 wins the first and third round
	Given a game is started with two players
	When Player 2 wins the round
	 And Player 1 wins the round
	 And Player 2 wins the round
	Then Player 2 is the winner

@CI
Scenario: Players keep tieing the round
	Given a game is started with two players
	When the round is a tie
	 And the round is a tie
	 And the round is a tie
	Then Still no winner

@CI
Scenario: Player 1 wins the first round then 3 ties then wins again
	Given a game is started with two players
	When Player 1 wins the round
	 And the round is a tie
	 And the round is a tie
	 And Player 1 wins the round
	Then Player 1 is the winner