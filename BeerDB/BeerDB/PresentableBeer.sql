CREATE VIEW [dbo].[PresentableBeer]
	AS SELECT b.Id,b.Name,t.Name AS Type ,SUM(r.Rating)/ count(r.Rating) AS Rating  FROM Type t, Beer b
	left join Rating r on b.Id = r.BeerId
	WHERE
	b.TypeId = t.Id
	group by b.id, b.Name, t.Name;
