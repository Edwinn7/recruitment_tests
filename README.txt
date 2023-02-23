+-------------------------+
| RECRUITMENT TESTS DAYVO |
+-------------------------+
Send tests to: recruitment.tests@dayvo.com
	(subject: full name and ID / content: You must send your full name, ID and a zip file with the answers)
visual studio: https://visualstudio.microsoft.com

Dayvo 2021 (c) All right reserved

+------------------------+
| PROGRAMMING ASSIGNMENT |
+------------------------+

This test is to be completed with C# using .NET Core or .NET 5.
Please provide the directory with the solution file (.sln) and any other relevant files.

Given the interface:

    interface ICollectionSorter {

        string[] SortAscending(int[] numbers);
        
        string[] SortDescending(int[] numbers);

    }

1. Write the class BubbleSortCollectionSorter : ICollectionSorter.

2. Use Bubble Sort, as the name implies.
    - Pseudocode: https://en.wikipedia.org/wiki/Bubble_sort#Pseudocode_implementation

2. Notice that you need to return string[], not int[].
    - You can change arrays to IEnumerables. No problem with that.
    - Simply converting the numbers to strings will do.
    - However, numbers from 0 to 9 (both ends included), must be returned as their English names.
      Return the name in uppercase for odd numbers, and in lowercase for even numbers.
      Return the name as "ZeRo" if it's a 0.
      Example: [0, 2, 5, 10] must be returned as ["ZeRo", "two", "FIVE", "10"].
    - For this part, bonus points if you use a generator (yield) to return the result.
    - You can use LinQ too.

3. Write the number of swaps to the console after sorting the input.
    - As soon as you realize that the number of swaps reaches the maximum value of ushort, throw an InvalidOperationException.

4. Remember the DRY principle. Avoid copying, pasting and changing comparison operators.
    - https://en.wikipedia.org/wiki/Don%27t_repeat_yourself

5. Write comments and document the code.

6. Write unit tests that show the code is working as intended.

+----------------------+
| FRONT-END ASSIGNMENT |
+----------------------+

(This test is to be completed with vanilla CSS or Bootstrap (3.x, 4.x, 5.x) and vanilla JS or Vuejs)
(Replicating the exact looks of the samples is not the goal of this assignment)

COLUMNS (columns.png)
---------------------

(Please provide a columns.html file)

1. Replicate a responsive layout that looks like the image.
2. Columns don't need to have any particular shape (ie: a defined height). Focus on column width instead.
3. On a big screen, all columns are on the same row (they use 1/6 of available space per-row).
4. On a medium screen, columns 1-4 are on the first row (they use 25% of available space per-row), whereas columns 5-6 are on the second row (they use 50% of available space per-row).
5. On a small screen, each column uses a complete row (they use 100% of available space per-row).

REPLICATOR (replicator.png)
---------------------------

(Please provide a replicator.html file)

1. Create a form that behaves as stated below.
2. Design or layout are not important. Focus on functionality.
3. There's a text input that allows you to type.
4. What you type into the input is replicated somewhere else (such as inside of a <p>, for example) AS YOU TYPE.
5. When the input is empty, a red text saying "You need to type something" is displayed.
6. When the input is not empty, a green text saying "You have typed something" is displayed.

7. A message saying "The message is X characters longs." is to be displayed at all times. Here, X is the length of the input text.
8. A message saying "Y out of X are consonants (NN,NN % of the total)." is to be displayed at all times. Here, Y is the number of consonants in the input text, and NN,NN is the percentage of the input text used by consonants (only a-z, A-Z are consonants), which is to be displayed with two decimal numbers at all times.

+---------------------+
| DATABASE ASSIGNMENT |
+---------------------+

(To complete this test you will need to connect to our remote MySQL / MariaDB database, examine its schema and write and execute the queries.)

Connection details:
Host: 20.190.239.235
Port: 52347
Database: db_selection_01 
User: test01
Password: q_fIK94Kv5eYV4m9mE1rU9Vm

For each exercise, write a query that returns the expected results:

1. Type of the most expensive property.

(3, 1510000, Real state, 3, 5 )
SELECT *
FROM db_selection_01.Property
ORDER BY value_in_euros DESC;
_________________________________________________________________________________________________________________________________
2. Name of the countries of which our database contains no people.
SELECT Country.name
FROM Country
LEFT JOIN Person ON Country.id = Person.country_id
WHERE Person.name IS NULL;

_________________________________________________________________________________________________________________________________
3. Average value of vehicles (properties of type = 'vehicle').
SELECT AVG(value_in_euros) AS average_value
FROM Property
WHERE type = 'vehicle';
_________________________________________________________________________________________________________________________________
4. Name of the person with more vehicles (properties of type = 'vehicle').
FROM Person
JOIN Property ON Person.id = Property.person_id
WHERE Property.type = 'vehicle'
GROUP BY Person.id
ORDER BY vehicle_count DESC
LIMIT
1;
_________________________________________________________________________________________________________________________________
5. Name of the people who have properties outside of their countries.
SELECT Person.name, Country.name AS country, Property.type
FROM Person
JOIN Property ON Person.id = Property.person_id
JOIN Country ON Person.country_id != Country.id AND Property.country_id = Country.id
WHERE Property.country_id != Person.country_id;
_________________________________________________________________________________________________________________________________
6. List of people with their names and the total value of their properties, but display only those with more than 500.000 of total property value.

SELECT Person.name, SUM(Property.value_in_euros) AS total_property_value
FROM Person
JOIN Property ON Person.id = Property.person_id
WHERE Property.type <> 'vehicle'
GROUP BY Person.id
HAVING total_property_value > 500000;
_________________________________________________________________________________________________________________________________