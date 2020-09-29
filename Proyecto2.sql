use SistemaPreguntas
--Creacion de tablas
create table Alumno(
	Usuario varchar(100) primary key,
	CU int,
	Nombre varchar(100),
	Passwd varchar(100)
	)

create table Administrador(
	Usuario varchar(100) primary key,
	Passwd varchar(100))


create table Prof(
	Usuario varchar(100) primary key,
	Nombre varchar(100),	
	Passwd varchar(100)
	)

create table Pregunta(
	Folio int primary key,
	UsuarioAlumno varchar(100) references Alumno,
	UsuarioProf varchar(100) references Prof,
	Pregunta varchar(2000),
	Respuesta varchar(2000),
	FechaPregunta datetime,
	FechaRespuesta datetime
	)


--Datos de prueba

insert into Administrador values('Admin', 'adminadmin')

insert into Alumno values('emi',189409,'Emilio','pass');
insert into Alumno values('rod',181935,'Rodrigo','pass');
insert into Alumno values('diego',182400,'Diego','pass');

insert into Prof values('ana','Ana Lidia','anita');
insert into Prof values('vic','Victorico','vic123');
insert into Prof values('esp','Esponda','esp123');
insert into Prof values('fel','Felipe','felipito');

insert into Pregunta values(166546,'emi','vic','¿Qué día es el examen?',null,'2020-05-17',null);
insert into Pregunta values(168546,'emi','vic','¿Cree que me podria mandar las notas de la clase? Gracias',null,'2020-05-17',null);
insert into Pregunta values(166446,'emi','ana','¿Cuáles son los criterios de evalución?',null,'2020-05-17',null);
insert into Pregunta values(267546,'emi','esp','¿Cómo le mando la tarea?',null,'2020-05-17',null);
insert into Pregunta values(136546,'emi','fel','¿Cómo va a ser el examen?','Opcion multiple. Saludos.','2020-05-17','2020-05-18');

insert into Pregunta values(132546,'rod','vic','¿Cree que me podria mandar las notas de la clase? Gracias',null,'2020-05-17',null);
insert into Pregunta values(122854,'rod','vic','¿Qué día es el examen?','El examen es el proximo Jueves. Saludos.','2020-05-17','2020-05-18');
insert into Pregunta values(165546,'rod','ana','¿Cómo va a ser el examen?',null,'2020-05-17',null);
insert into Pregunta values(367546,'rod','esp','¿Cuáles son los criterios de evalución?',null,'2020-05-17',null);
insert into Pregunta values(106546,'rod','fel','¿Cómo le mando la tarea?',null,'2020-05-17',null);

insert into Pregunta values(866546,'diego','ana','¿Cómo le mando la tarea?','Hola Diego. Por PDF a mi correo. Saludos.','2020-05-17','2020-05-19');
insert into Pregunta values(169546,'diego','vic','¿Qué día es el examen?',null,'2020-05-17',null);
insert into Pregunta values(886446,'diego','ana','¿Cree que me podria mandar las notas de la clase? Gracias',null,'2020-05-17',null);
insert into Pregunta values(267006,'diego','esp','¿Cómo va a ser el examen?',null,'2020-05-17',null);
insert into Pregunta values(111546,'diego','fel','¿Cómo le mando la tarea?',null,'2020-05-17',null);


--Selects,inserts de prueba
--insert into Pregunta values(654654,'emi','vic','Mi Pregunta',null,GETDATE(),null);
--update Pregunta set Respuesta='Mi respuesta',FechaRespuesta=GETDATE() where folio=16
--select Nombre from Alumno where Usuario='rod' and Passwd='password' union select Nombre from Prof where Usuario='Rodrigo' and Passwd='rod'
--select Nombre,Usuario from Alumno where Usuario='ana' and Passwd='pass'
--select para mostrar preguntas no constestadas de cierto profesor
--select Nombre,Alumno.CU,FechaPregunta,Pregunta from Pregunta inner join Alumno on Pregunta.UsuarioAlumno=Alumno.Usuario where Pregunta.Respuesta is null and Pregunta.UsuarioProf='vic'
--select para preguntas contestadas por cierto Prof
--select Nombre,Alumno.CU,FechaPregunta,Pregunta,Respuesta,FechaRespuesta from Pregunta inner join Alumno on Pregunta.UsuarioAlumno=Alumno.Usuario where Pregunta.Respuesta is not null and Pregunta.UsuarioProf='vic'
--Dropdown Alumno
--select Usuario,Nombre+' ('+str(CU)+')' as NomCU from Alumno
--select para mostrar preguntas no constestadas de cierto profesor de cierto alumno
--select Nombre,Alumno.CU,FechaPregunta,Pregunta from Pregunta inner join Alumno on Pregunta.UsuarioAlumno=Alumno.Usuario where Pregunta.Respuesta is null and Pregunta.UsuarioProf='vic' and Pregunta.UsuarioAlumno='emi'
--select para preguntas contestadas por cierto Prof por cierto Alumno
--select Nombre,Alumno.CU,FechaPregunta,Pregunta,Respuesta,FechaRespuesta from Pregunta inner join Alumno on Pregunta.UsuarioAlumno=Alumno.Usuario where Pregunta.Respuesta is not null and Pregunta.UsuarioProf='vic' and Pregunta.UsuarioAlumno='emi'

--select Alumno preguntas respondidas
--select Nombre,FechaPregunta,Pregunta from Pregunta inner join Prof on Pregunta.UsuarioProf=Prof.Usuario where Pregunta.Respuesta is not null and Pregunta.UsuarioAlumno='emi'
--Editar pregunta
--update Pregunta set Pregunta='nueva pregunta' where folio=16

--borrar pregunta
--delete from Pregunta where folio=16
--select usuario, passwd from Administrador where usuario ='Admin' and passwd = 'adminadmin'
--select * from Alumno
--delete from Alumno where Usuario ='bigmike'
--update Alumno set Passwd='rad' ,Nombre='rad' , CU=15 where Usuario ='bigmike'
--update Prof set passwd='rad',nombre='rad' where Usuario='esp'

--Update Alumno set Passwd='rad' where usuario='Rod'
--Update Prof set passwd = 'rad' where usuario = 'esp'
--select * from prof
--select * from pregunta
--delete from pregunta where UsuarioAlumno='Rod'
--select passwd from Prof where usuario='esp'

--select Folio,prof.Nombre as 'profesor',alumno.nombre as 'alumno',FechaPregunta,Pregunta,FechaRespuesta,Respuesta from Pregunta inner join Prof on Pregunta.UsuarioProf=Prof.Usuario inner join Alumno on pregunta.UsuarioAlumno = Alumno.usuario where Pregunta.Respuesta is null and alumno.Usuario = 'Rod' and prof.usuario = 'esp'

--Selects de resumen
/**
select UsuarioAlumno,Count(UsuarioAlumno) as 'Preguntas Hechas' from Pregunta
group by UsuarioAlumno

select UsuarioAlumno,count(UsuarioAlumno) as 'Preguntas con Respuesta' from Pregunta
where Pregunta.Respuesta is not null
group by UsuarioAlumno

select UsuarioAlumno,Alumno.CU,Alumno.Nombre,
count(UsuarioAlumno) as 'Preguntas Hechas',
sum(case when Respuesta is not null then 1 else 0 end) as 'Preguntas con Respuesta',
(sum(case when Respuesta is not null then 1 else 0 end)*100.0)/count(UsuarioAlumno) as '% de Preguntnas con Respuesta'
from Pregunta inner join Alumno on Pregunta.UsuarioAlumno=Alumno.Usuario group by UsuarioAlumno,Alumno.CU,Alumno.Nombre

select UsuarioAlumno,Alumno.CU,Alumno.Nombre,count(UsuarioAlumno) as 'Preguntas Hechas',sum(case when Respuesta is not null then 1 else 0 end) as 'Preguntas con Respuesta',(sum(case when Respuesta is not null then 1 else 0 end)*100.0)/count(UsuarioAlumno) as '% de Preguntnas con Respuesta' from Pregunta inner join Alumno on Pregunta.UsuarioAlumno=Alumno.Usuario group by UsuarioAlumno,Alumno.CU,Alumno.Nombre

select UsuarioProf,Prof.Nombre,
count(UsuarioProf) as 'Preguntas Recibidas',
sum(case when Respuesta is not null then 1 else 0 end) as 'Preguntas Contestadas',
(sum(case when Respuesta is not null then 1 else 0 end)*100.0)/count(UsuarioAlumno) as '% de Preguntas Contestadas'
from Pregunta inner join Prof on Pregunta.UsuarioProf=Prof.Usuario group by UsuarioProf,Prof.Nombre

select UsuarioProf,Prof.Nombre,count(UsuarioProf) as 'Preguntas Recibidas',sum(case when Respuesta is not null then 1 else 0 end) as 'Preguntas Contestadas',(sum(case when Respuesta is not null then 1 else 0 end)*100.0)/count(UsuarioAlumno) as '% de Preguntas Contestadas' from Pregunta inner join Prof on Pregunta.UsuarioProf=Prof.Usuario group by UsuarioProf,Prof.Nombre

select count(Folio) from Pregunta
select count(Usuario) from Alumno
select count(Usuario) from Prof
*/