Feature: Finding Users
	In order to a keep track of my members
	As a club manager
	I want to know who has already joined

Scenario: List all users
	Given the following registered users
	| Name         | Password | Telephone Number | Street         | City   | Country |
	| Jack Sparrow | pirat1s  | 07568953571      | 10 Main Street | Nassau | Bahamas |
	| Jack Rackham | pirat2s  | 07568953572      | 12 Main Street | Nassau | Bahamas |
	| Charles Vane | pirat3s  | 07568953573      | 14 Main Street | Nassau | Bahamas |
	When I list all of the registered users
	Then I should obtain the following users:
	| Name         |
	| Jack Sparrow |
	| Jack Rackham |
	| Charles Vane |

Scenario: Find a user by name
	Given the following registered users
	| Name         | Password | Telephone Number | Street         | City   | Country |
	| Jack Sparrow | pirat1s  | 07568953571      | 10 Main Street | Nassau | Bahamas |
	| Jack Rackham | pirat2s  | 07568953572      | 12 Main Street | Nassau | Bahamas |
	| Charles Vane | pirat3s  | 07568953573      | 14 Main Street | Nassau | Bahamas |
	When I search for registered users named "Jack Rackham"
	Then I should obtain the following user:
	| Name         |
	| Jack Rackham |

Scenario: Find a user by id
	Given a new user
	| Name         | Password | Telephone Number | Street         | City   | Country |
	| Jack Rackham | pirat3s  | 07568953571      | 10 Main Street | Nassau | Bahamas |
	And he has registered online
	When I search for a registered user with the returned Id value
	Then I should obtain the following user:
	| Name         |
	| Jack Rackham |
