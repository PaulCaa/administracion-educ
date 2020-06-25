CREATE VIEW Cursadas_Alumno AS(
	SELECT
		es.Legajo,
		m.Nombre Materia,
		cat.Id IdCatedra,
		cat.Dia,
		cat.Horario,
		cat.Turno
	FROM EscuelaDB.dbo.Estudiantes es
	JOIN EscuelaDB.dbo.Cursadas cu ON es.Id = cu.Alumno
	JOIN EscuelaDB.dbo.Catedras cat ON cu.Catedra = cat.Id
	JOIN EscuelaDB.dbo.Materias m ON cat.Materia = m.Id
);