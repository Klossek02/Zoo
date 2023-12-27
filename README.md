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

6 - Each object is represented by unique integer identifer. All data is kept in one map string->string. 
	Representation is a bit similar to 1. but data is accesed as string in that map. Additionally "<fieldname_count>" 
	like in representation 6. Data is accessed like "<id>.<fieldname>[idx]". So to eg. access name of enclosure 3 use 
	string "3.name[0]" and to access second animal in that enclosure - "3.animals[1]". To access number of animals in that 
	enclosure use "3.animals_count" 
