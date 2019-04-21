<template>
    <v-container>
        <v-layout>
            <h1>Consulta Informacion Paciente</h1>
        </v-layout>

        <v-layout>
            <v-flex xs1>
                <h4>Paciente</h4>                
                <v-text-field
                    outline
                ></v-text-field>
            </v-flex>

            <v-flex xs2 pt-4>
                <v-btn color="success">consultar</v-btn>
            </v-flex>
        </v-layout>

        <v-divider></v-divider>

        <v-layout pt-3>
            <v-flex>
                <h3>Informacion Personal</h3>
            </v-flex>
        </v-layout>

        <v-layout justify-start>
            <v-flex xs2 mr-3>
                <h4>Nombre</h4>

                <v-text-field
                    readonly
                    outline
                ></v-text-field>
            </v-flex>
            
            <v-flex xs3>
                <h4>Apellidos</h4>

                <v-text-field
                    readonly
                    outline
                ></v-text-field>
            </v-flex>
        </v-layout>

        <v-layout justify-start>
            <v-flex xs2 mr-3>
                <h4>Sexo</h4>
                <v-text-field
                    readonly
                    outline
                ></v-text-field>
            </v-flex>

            <v-flex xs1>
                <h4>Edad</h4>
                <v-text-field
                    readonly
                    outline
                ></v-text-field>
            </v-flex>
        </v-layout>

        <v-divider></v-divider>

        <v-divider></v-divider>

        <v-layout pt-3>
            <h3>Informacion de contacto</h3>
        </v-layout>

        <v-layout pt-3>
            <v-flex xs3 mr-3>
                <h4>Calle</h4>
                <v-text-field
                    readonly
                    outline
                ></v-text-field>
            </v-flex>

            <v-flex xs3 mr-3>
                <h4>Colonia/Fraccionamiento</h4>
                <v-text-field
                    readonly
                    outline
                ></v-text-field>
            </v-flex>

            <v-flex xs1>
                <h4>Codigo Postal</h4>
                <v-text-field
                    readonly
                    outline
                ></v-text-field>
            </v-flex>
        </v-layout>

        <v-layout>
            <v-flex xs2 mr-3>
                <h4>Telefono Celular/Casa</h4>
                <v-text-field
                    readonly
                    outline
                ></v-text-field>
            </v-flex>

            <v-flex xs3 mr-3>
                <h4>Correo Electronico</h4>
                <v-text-field
                    readonly
                    outline
                ></v-text-field>
            </v-flex>
        </v-layout>

        <v-layout justify-center>
            <v-flex xs2 mr-3>
                <v-btn color="warning">Modificar Informacion</v-btn>
            </v-flex>
            
            <v-flex xs2 ml-4>
                <v-btn color="error">Ejecutar Baja</v-btn>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
export default {
    name:'ConsultaInformacionPacienteComponent'
}
</script>