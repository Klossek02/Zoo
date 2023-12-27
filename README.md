# Zoo
A project for Object Oriented Design class. 

# Description
The Byteot ZOO was founded in 0x7CF by King Byteasar 0xD the Wise. In the ZOO
we have *enclosures* that have a name (string), a list of *animals*
inhabiting them and an *employee* responsible for a given *enclosure*. Each
animal has a name (string), age (positive int) and *species*. Each *species*
consists of a *name* and, in the case of carnivorous species, a list of
favorite foods (species). Each employee has a first name (string), last name
(string), age (positive int), and a list of *enclosures* they look after. In
addition, in order to better adjust the offer, the zoo registers visitors.
For each visitor, his name (string), last name (string) and the list of
*enclosures* that he visited are saved.

Possible representations:
	0 - Base representation. Objects with references - references are used for connections between objects.
		Enclosure
			- name (string)
			- animals (list of animals refs)
			- employee (employee ref)
			
		Animal
			- name (string)
			- age (int)
			- species (species ref)
			
		Species
			- name (string)
			- favouriteFoods (list of species refs) (only for carnivorous)
		
		Employee
			- name (string)
			- surname (string)
			- age (int)
			- enclosures (list of enclosures refs)

		Visitor 
			- name (string)
			- surname (string)
			- visitedEnclosures (list of enclosures refs)
