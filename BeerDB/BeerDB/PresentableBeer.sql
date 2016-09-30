CREATE VIEW [dbo].[PresentableBeer]
	AS SELECT b.Id as BeerId,b.Name,t.Id AS TypeId,t.Name AS BeerType ,SUM(r.Rating)/ count(r.Rating) AS BeerRating FROM BeerType t, Beer b
	left join BeerRating r on b.Id = r.BeerId
	WHERE
	b.TypeId = t.Id
	group by b.Id, b.Name, t.Id, t.Name;
