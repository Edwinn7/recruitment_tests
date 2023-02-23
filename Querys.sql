SELECT *
FROM db_selection_01.Property
ORDER BY value_in_euros DESC;

SELECT Country.name
FROM Country
LEFT JOIN Person ON Country.id = Person.country_id
WHERE Person.name IS NULL;

SELECT AVG(value_in_euros) AS average_value
FROM Property
WHERE type = 'vehicle';

SELECT Person.name, COUNT(*) AS vehicle_count
FROM Person
JOIN Property ON Person.id = Property.person_id
WHERE Property.type = 'vehicle'
GROUP BY Person.id
ORDER BY vehicle_count DESC
LIMIT
1;

SELECT Person.name, Country.name AS country, Property.type
FROM Person
JOIN Property ON Person.id = Property.person_id
JOIN Country ON Person.country_id != Country.id AND Property.country_id = Country.id
WHERE Property.country_id != Person.country_id;

SELECT Person.name, SUM(Property.value_in_euros) AS total_property_value
FROM Person
JOIN Property ON Person.id = Property.person_id
WHERE Property.type <> 'vehicle'
GROUP BY Person.id
HAVING total_property_value > 500000;