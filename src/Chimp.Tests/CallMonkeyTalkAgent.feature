Feature: Call MonkeyTalk Wire
	

@mytag
Scenario: Call MonkeyTalk Wire with a Simple Play Command
	Given I have a running MonkeyTalk Agent at location "mock"
	When I send a simple play command payload
	Then the result should be "OK"

Scenario Outline: Call MonkeyTalk Wire with a Play Command
	Given I have a running MonkeyTalk Agent at location "<location>"
	And I want to send a "Play" command
	And the componentType is "<componentType>"
	And the monkeyId is "<monkeyId>"
	And the payload arguments are "<args>"
	When I send a "<action>" action with the payload
	Then the result should be "<result>"

	Examples: 
	| location                                       | componentType | monkeyId | args | action | result |
	| mock                                           | Button        | *        |      | Tap    | OK     |
	| http://localhost:22283/api/mockmonkeytalkagent | Button        | *        |      | Tap    | OK     |
	



