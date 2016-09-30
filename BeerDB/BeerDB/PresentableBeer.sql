CREATE VIEW [dbo].[PresentableBeer]
	AS SELECT b.Id as BeerId,b.Name as BeerName, t.Id AS BeerTypeId ,t.Name AS BeerTypeName ,SUM(r.Rating)/ count(r.Rating) AS BeerRating FROM BeerType t, Beer b
	left join BeerRating r on b.Id = r.BeerId
	WHERE
	b.TypeId = t.Id
	group by b.Id, b.Name, t.Id, t.Name;
