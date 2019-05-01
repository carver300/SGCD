<template>
    <v-container>
        <v-layout>
            <v-flex xs12>
                <v-card class="elevation-10" id="contenedor">
                    <v-card-title primary-title>
                        <h2>Servicios</h2>
                        <v-spacer></v-spacer>
                        <v-text-field
                            outline
                            v-model="search"
                            append-icon="search"
                            label="Search"
                            single-line
                            hide-details
                        ></v-text-field>
                    </v-card-title>

                    <v-card-text>
                        <v-data-table
                        id="contenedor"
                        :search="search"
                        :headers="headers"
                        :items="valoresTabla"
                        class="elevation-0"
                        hide-actions
                        
                        >
                            <template v-slot:items="props">
                                <td class="text-xs-left"><h4>{{ props.item.id_paciente }}</h4></td>
                                <td class="text-xs-left"><h4>{{ props.item.nombre }}</h4></td>
                                <td class="text-xs-left"><h4>{{ props.item.apepaterno }}</h4></td>
                                <td class="text-xs-left"><h4>{{ props.item.apematerno }}</h4></td>
                                <td class="text-xs-left"><h4>{{ props.item.sexo }}</h4></td>
                                
                                <td class="justify-left layout ">
                                    <v-icon
                                        class="mr-2"
                                        @click="abrirDialogEditar(props.item)"
                                    >
                                        edit
                                    </v-icon>
                                    <v-icon
                                        @click="deleteItem(props.item)"
                                    >
                                        delete
                                    </v-icon>
                                </td>
                            </template>
                            <template v-slot:no-results>
                                <v-alert :value="true" color="error" icon="warning">
                                    Your search for "{{ search }}" found no results.
                                </v-alert>
                            </template>
                        </v-data-table>
                    </v-card-text>
                </v-card>
            </v-flex>
        </v-layout>
        <v-layout pt-4>
           <v-flex xs12>
                <v-card class="elevation-10">
                    <v-card-title>
                        <v-layout pt-3>
                            <h2>Detalle del servicio</h2>
                        </v-layout>
                    </v-card-title>
                    <v-card-text>
                        <v-layout justify-center pb-3>
                            <v-flex xs12>
                                <v-divider></v-divider>
                            </v-flex>
                        </v-layout>
                        <v-layout>
                            <v-flex xs2>
                                <h4>Nombre</h4>
                                <v-text-field
                                    outline
                                ></v-text-field>
                            </v-flex>
                        </v-layout>
                        <v-layout>
                            <v-flex xs3>
                                <h4>Descripcion</h4>
                                <v-textarea
                                    label="Descripcion del servicio"
                                    outline
                                ></v-textarea>
                            </v-flex>
                        </v-layout>
                        <v-layout>
                            <v-flex xs1>
                                <h4>Precio</h4>
                                <v-text-field
                                    outline
                                ></v-text-field>
                            </v-flex>
                            <v-flex xs2 ml-3>
                                <h4>Duracion estimada</h4>
                                <v-text-field
                                    label="Tiempo de duracion"
                                    outline
                                ></v-text-field>
                            </v-flex>
                        </v-layout>
                    </v-card-text>
                </v-card>
           </v-flex>
        </v-layout>
    </v-container>
</template>

<style>
    #contenedor{
        border-style:solid;
        border-radius: 3px;
        border-width: 1px;
    }
    .titulos{
        font-size: 30px;
    }
    table.v-table thead tr th {
        font-size: 20px;
    }
</style>

<script>
export default {
    name:'DetalleServicios',
    data(){
        return{
            headers:[
                { text: 'Id_Servicio', align: 'left', value: 'id_servicio' },
                { text: 'Nombre', align: 'left', value: 'nombre' },
                { text: 'Descripcion', align: 'left', value: 'descripcion' },
                { text: 'Precio', align: 'left', value: 'precio' },
                { text: 'Duracion', align: 'left', value: 'duracion' }
            ],
            valoresTabla:[],
            objetoServicio:{
                id_servicio:'',
                nombre:'',
                descripcion:'',
                precio:'',
                duracion:''
            },
            index:-1,
            search: '',
            dialog:false
        }
    }
}
</script>
