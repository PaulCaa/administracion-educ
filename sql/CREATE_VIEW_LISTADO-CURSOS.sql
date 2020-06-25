CREATE VIEW Listado_Cursos AS(
	SELECT
		(m.Id + cat.Id) IdCurso,
		m.Nombre NombreCurso,
		(e.Apellido + ', ' + e.Nombre) Alumno,
		e.Legajo,
		cat.Dia,
		cat.Turno,
		(prof.Apellido + ', ' + prof.Nombre) Maestro
	FROM EscuelaDB.dbo.Cursadas cu
	JOIN EscuelaDB.dbo.Estudiantes e ON cu.Alumno = e.Id
	JOIN EscuelaDB.dbo.Catedras cat ON cu.Catedra = cat.Id
	JOIN EscuelaDB.dbo.Materias m ON cat.Materia = m.Id
	JOIN EscuelaDB.dbo.Maestros_Catedras mc ON cat.Id = mc.Catedra
	JOIN EscuelaDB.dbo.Maestros prof ON mc.Maestro = prof.Id
);