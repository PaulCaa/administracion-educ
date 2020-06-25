CREATE VIEW Listado_Catedras AS (
	SELECT
		cat.Id,
		mat.Nombre,
		cat.Dia,
		cat.Horario,
		cat.Turno,
		(ma.Apellido + ma.Nombre) as Maestro
	FROM EscuelaDB.dbo.Catedras cat
	JOIN EscuelaDB.dbo.Materias mat ON cat.Materia = mat.Id
	JOIN EscuelaDB.dbo.Maestros_Catedras mc ON cat.Id = mc.Catedra
	JOIN EscuelaDB.dbo.Maestros ma ON mc.Maestro = ma.Id
);
