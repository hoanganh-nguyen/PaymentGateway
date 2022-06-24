Feature: ProcessPayment
As a merchant, when a shopper buying a product, I process a payment through payment gateway

@ProcessPayment
Scenario Outline: Bad Request
	Given Shopper provides a bad payment request 
	When submitting a payment request
	Then payment gateway returns a unsuccessfule response
	And the error code is bad request


@ProcessPayment
Scenario: Bad Credit Card
	Given Shopper provides an invalid credit card
	When submitting a payment request
	Then payment gateway returns a unsuccessfule response
	And the error code is unprocessable entity



@ProcessPayment
Scenario Outline: Valid payment request
	Given Shopper provides a valid payment request
	When submitting a payment request
	Then payment gateway returns a successfule response
