Feature: RetrievingPaymentDetails

As a merchant, I want to get the payment details for the reporting purpose
@RetrievingPaymentDetails
Scenario: Payment details found
	Given A previous sucessful payment request 
	When I request to retrieve details
	Then the payment gateway returns a successful response
	And the response is matched with the previously payment made

Scenario: Payment details not found
	Given A previous unsucessful payment request 
	When I request to retrieve details
	Then the payment gateway returns an unsuccessful response
	And the error is not found
