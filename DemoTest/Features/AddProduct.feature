Feature: Add product to wishlist

Background: 
	Given I have navigated to test demo website

@smoke
Scenario: Add product to wishlist and verify
	Given I add four different products to my wishlist
	When I veiw my wishlist table
	Then I find total four selected items in my wishlist
	When I search for lowest price product
	Then I am able to add the lowest price item to my cart
	Then I am able to verify the item in my cart