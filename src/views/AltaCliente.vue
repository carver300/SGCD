<template>
    
    <v-form>
        <v-container>    
            <v-layout>
                <h1>Alta Paciente</h1>    
            </v-layout>    
        </v-container>

        <v-container>
            <v-divider></v-divider>
            <h2>Informacion Personal</h2>
            <v-layout justify-start pt-2>
                <v-flex lg2>
                    <h3>
                        Nombre
                    </h3>
                    <v-text-field
                    outline
                    :counter="25">    
                    </v-text-field>

                </v-flex>
                <v-flex lg3>
                    <h3>Apellidos</h3>
                    <v-text-field
                    outline
                    :counter="25">
                    </v-text-field>
                </v-flex>
                
            </v-layout>

            <v-layout>
                
                <v-flex lg2>
                    <h3 style="padding-bottom:10px;">Sexo</h3>
                    <v-select
                    outline
                    :items="sexos"
                    
                    >
                    </v-select>
                </v-flex>

                <v-flex lg1>
                    <h3 style="padding-bottom:10px;">Edad</h3>
                    <v-text-field
                    outline
                    >

                    </v-text-field>
                </v-flex>
            </v-layout>
            
            <v-divider></v-divider>
            <h2>Informacion de contacto</h2>
            <v-layout  align-center>  
                <v-flex lg3>
                    <h3>Calle</h3>
                    <v-text-field
                    outline
                    >
                    </v-text-field>
                </v-flex>

                <v-flex lg3>
                    <h3>Colonia/Fraccionamiento</h3>
                    <v-text-field
                    outline>

                    </v-text-field>
                </v-flex>

                 <v-flex lg1>
                    <h3>Codigo Postal</h3>
                    <v-text-field
                    outline>
                    </v-text-field>
                </v-flex>
            </v-layout>

            <v-layout align-center>
                <v-flex lg2>
                    <h3>Telefono Celular/Casa</h3>
                    <v-text-field
                    outline>
                    </v-text-field>
                </v-flex>

                <v-flex lg3>
                    <h3>Correo Electronico</h3>
                    <v-text-field
                    outline>

                    </v-text-field>
                </v-flex>
            </v-layout>

            <v-layout justify-center>
                <v-btn color="primary"> Generar Alta</v-btn>
            </v-layout>
        </v-container>
    </v-form>
</template>

<script>
  export default {
    name:'AltaCliente',
    data: () => ({
        sexos: ['Masculino','Femenino'],
        correos: ['gmail.com','outloook.com','hotmail.com']
    })
  }
</script>