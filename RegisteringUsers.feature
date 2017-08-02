Feature: Registering Users
	In order to a keep track of my members
	As a club manager
	I want to record new members

Scenario: Add a new user
	Given a new user
	| Name         | Password | Telephone Number | Street         | City   | Country |
	| Jack Sparrow | pirat3s  | 07568953571      | 10 Main Street | Nassau | Bahamas |
	When he registers online
	Then he should be assigned a unique account number
	
Scenario: Users with the same name cannot register twice
	Given the following registered users
	| Name         | Password | Telephone Number | Street         | City   | Country |
	| Jack Sparrow | pirat1s  | 07568953571      | 10 Main Street | Nassau | Bahamas |
	| Jack Rackham | pirat2s  | 07568953572      | 12 Main Street | Nassau | Bahamas |
	And a new user
	| Name         | Password | Telephone Number | Street         | City   | Country |
	| Jack Sparrow | pirat3s  | 07568953574      | 20 Main Street | Nassau | Bahamas |
	When he tries to register online
	Then his request should be rejected with a Conflict error
	
