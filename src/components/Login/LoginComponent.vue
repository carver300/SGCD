<template>
    <v-content>
        <v-container fluid fill-height>
            <v-layout align-center justify-center>
                <v-flex lg2>
                    <v-card class="elevation-5">
                        <v-card-title primary-title>
                            <v-layout justify-center>
                               <v-avatar
                                   size="200px"
                                   color="gray"
                               >
                                   <img src="http://www.sclance.com/pngs/user-icon-png/user_icon_png_1449226.png" alt="alt">
                               </v-avatar>    
                            </v-layout>
                        </v-card-title>

                        <v-card-text>
                            <v-layout row wrap>
                                <v-flex xs11>
                                    <h3 style="margin-left:35px;">Usuario</h3>
                                    <v-text-field
                                        v-model="usuario"
                                        prepend-icon="person"
                                        outline
                                        type="text"
                                    ></v-text-field>
                                </v-flex>
                                <v-flex xs11>
                                    <h3 style="margin-left:35px;">Contrasena</h3>
                                    <v-text-field
                                        v-model="contrasena"
                                        prepend-icon="lock"
                                        outline
                                        type="password"
                                    ></v-text-field>
                                </v-flex>
                            </v-layout>
                            <v-layout justify-center>
                                <v-flex xs4>
                                    <v-btn 
                                    color="primary" 
                                    style="margin-left:-10px;"
                                    @click="validarDatos()"
                                    >
                                        <v-icon dark style="margin-left:-10px; margin-right:10px;">
                                            save_alt
                                        </v-icon>
                                        Ingresar
                                    </v-btn>
                                </v-flex>
                            </v-layout>
                        </v-card-text>
                    </v-card>
                </v-flex>
            </v-layout>
        </v-container>
    </v-content>
</template>

<script>
export default {
    name: 'LoginComponent',
    data(){
        return{
        usuario:'',
        contrasena:''
        }
    },
    methods:{
        validarDatos(){
            
            if(this.usuario && this.contrasena)
            {
                this.$router.push('/Home');
            }
            else if (!this.usuario || !this.contrasena)
            {
                this.$refs['modal-error'].show()
            }
        }
    }
}
</script>