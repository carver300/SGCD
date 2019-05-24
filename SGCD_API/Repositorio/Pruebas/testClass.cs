using Xunit;
using SGCD_API.Models;
using SGCD_API.Repositorio.Pacientes;

namespace SGCD_API.Repositorio.Pruebas
{
    public class testClass
    {

        PacientesRepository _repoPaciente = new PacientesRepository();

        [Fact]
        public void validarCamposVaciosPacienteTest(){
            //Objeto Vacio
            Paciente paciente1 = new Paciente(1);
            //Paciente con datos

            Assert.Equal(true,_repoPaciente.validarCamposVacios(paciente1));
            
        }

        [Fact]
        public void validarDatosRepetidosTest(){
            //Paciente datos 1
            Paciente paciente1 = new Paciente(2);
            //Paciente paciente datos 2
            Paciente paciente2 = new Paciente(2);

            Assert.Equal(false,_repoPaciente.validarDatosRepetidos(paciente1,paciente2));

        }

        [Fact]
        public void ValidarCaracteresEspecialesTest(){
            Paciente pacienteCaracter = new Paciente(4);

            Assert.Equal(false,_repoPaciente.validarCaracteresEspeciales(pacienteCaracter));
        }
    }
}