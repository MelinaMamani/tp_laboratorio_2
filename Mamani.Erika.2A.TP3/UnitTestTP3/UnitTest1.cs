using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using ClasesInstansiables;
using Archivos;
using Excepciones;


namespace UnitTestTP3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AlumnoRepetidoExceptionTest()
        {
            Alumno a = new Alumno(1500, "Juan", "Martínez", "459000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(45800, "Juana", "Martínez", "459000", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);

            Universidad universidad = new Universidad();
            try
            {
                universidad += a;
                universidad += a2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        [TestMethod]
        public void DniInvalidoExceptionTest()
        {
            try
            {
                Alumno a = new Alumno(20, "Jose", "Gonzalez", "1230002d", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            try
            {
                Alumno a = new Alumno(10, "Pedro", "Lopez", "78.000.150", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Deudor);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        [TestMethod]
        public void NacionalidadInvalidaExceptionTest()
        {
            try
            {
                Alumno a = new Alumno(50, "Manuel", "Gomez", "95150367", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.Deudor);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

            try
            {
                Alumno a = new Alumno(323, "Roberto", "Piazaa", "0", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

            try
            {
                Alumno a = new Alumno(458, "María", "Gonzalez", "12536188", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void ValorNumericoDNI()
        {
            Profesor profesor = new Profesor(1500, "Cristina", "Margo", "483232", Persona.ENacionalidad.Argentino);
            Alumno a = new Alumno(132897, "Victoria", "Mara", "95002365", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Assert.IsInstanceOfType(profesor.DNI, typeof(int));
            Assert.IsInstanceOfType(a.DNI, typeof(int));
        }

        [TestMethod]
        public void ValoresNulosAlumno()
        {
            
            Alumno a = new Alumno(1500, "Jose", "Peralta", "45877", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.IsNotNull(a);
            Assert.IsNotNull(a.Apellido);
            Assert.IsNotNull(a.DNI);
            Assert.IsNotNull(a.Nacionalidad);
            Assert.IsNotNull(a.Nombre);


            Alumno a2 = new Alumno(4800, "Camila", "Gonzalez", "94777489", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
            Assert.IsNotNull(a2);
            Assert.IsNotNull(a2.Apellido);
            Assert.IsNotNull(a2.DNI);
            Assert.IsNotNull(a2.Nacionalidad);
            Assert.IsNotNull(a2.Nombre);
        }

        [TestMethod]
        public void ValoresNulosProfesor()
        {
            Profesor profesor = new Profesor(4785, "Carolina", "Megar", "1500365", Persona.ENacionalidad.Argentino);
            Assert.IsNotNull(profesor);
            Assert.IsNotNull(profesor.Apellido);
            Assert.IsNotNull(profesor.DNI);
            Assert.IsNotNull(profesor.Nacionalidad);
            Assert.IsNotNull(profesor.Nombre);
        }

        [TestMethod]
        public void ValoresNulosJornada()
        {
            Profesor profesor = new Profesor();
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, profesor);
            Assert.IsNotNull(jornada);
            Assert.IsNotNull(jornada.Alumnos);
            Assert.IsNotNull(jornada.Clases);
            Assert.IsNotNull(jornada.Instructor);
        }

        [TestMethod]
        public void ValoresNulosUniversidad()
        {
            Universidad universidad = new Universidad();
            Assert.IsNotNull(universidad);
            Assert.IsNotNull(universidad.Alumnos);
            Assert.IsNotNull(universidad.Instructores);
            Assert.IsNotNull(universidad.Jornadas);
        }
    }
}
