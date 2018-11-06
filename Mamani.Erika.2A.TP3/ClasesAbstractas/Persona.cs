using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{ 
    public abstract class Persona
    {
        #region Enumerado aninado

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion

        #region Atributos

        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;

        #endregion

        #region Propiedades

        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }

            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Persona"/>.
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Persona"/>.
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Persona"/>.
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }


        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Persona"/>.
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI tipo: <see cref="string"/></param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Valida el DNI correspondiente a nacionalidades
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad para validar DNI</param>
        /// <param name="dato">DNI numérico</param>
        /// <returns>Retorna el DNI correspondiente a la nacionalidad, sino lanza <see cref="DniInvalidoException"/>.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int dni = 0;

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato >= 1 && dato <= 89999999)
                    {
                        dni = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato >= 90000000 && dato <= 99999999)
                    {
                        dni = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
                default:
                    break;
            }

            return dni;
        }

        /// <summary>
        /// Valida que el DNI posea un formato correcto
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad para validar DNI</param>
        /// <param name="dato">DNI a validar, tipo <see cref="string"/></param>
        /// <returns>Retorna el DNI validado, sino lanza <see cref="DniInvalidoException"/>. </returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            int aux = 0;

            if (dato.Length >= 1 && dato.Length <= 8 && (int.TryParse(dato, out aux)))
            {
                dni = aux;
            }
            else
            {
                throw new DniInvalidoException();
            }
            return dni;
        }

        /// <summary>
        /// Valida que una cadena no posea numeros u otros caracteres.
        /// </summary>
        /// <param name="dato">Dato a validar</param>
        /// <returns>Retorna un <see cref="string"/> que contiene la cadena validada.</returns>
        private string ValidarNombreApellido(string dato)
        {
            Regex regex = new Regex("[a-zA-Z]");
            string cadena = "";

            foreach (Match match in regex.Matches(dato))
            {
                cadena += match.Value;
            }

            return cadena;
        }

        /// <summary>
        /// Muestra todos los datos de la <see cref="Persona"/>
        /// </summary>
        /// <returns>Retorna un <see cref="string"/> que contiene los datos.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre);
            sb.AppendFormat("\nNACIONALIDAD: {0}", this.Nacionalidad);
            sb.AppendFormat("\nDNI: {0}", this.DNI);

            return sb.ToString();
        }

        #endregion
    }
}
