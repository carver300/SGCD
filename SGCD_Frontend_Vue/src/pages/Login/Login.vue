<template>
   <div class="modal-dialog text-center">
       <div class="col-xl-8 main-section">
           <div class="modal-content">
               <div class="col-12 usr-img">
                   <img src="@/assets/img/avatar.png" alt="avatar">
               </div>
                <form class="col-12">
                    <div class="form-group">
                        <input type="text" class="form-control" placeholder="Correo" v-model="usuario">
                    </div>
                    <div class="form-group">
                        <input type="password" class="form-control" placeholder="Contrasena" v-model="contra">
                    </div>
                    <button type="submit" class="btn btn-fill btn-primary mb-2" @click="validarUsuario()">Ingresar</button>
                </form>
           </div>
       </div>
   </div>
</template>

<style>
    
   
    .main-section{
        margin:0 auto;
        margin-top: 25%;
        padding: 0;
    }

    .modal-content{
        background-color:#2a2a2a;
        box-shadow: 0px 0px 3px #848484;
        opacity: .90;
        padding: 0 2px;

    }
    .usr-img{
        margin-top: -50px;
        margin-bottom: 35px;
    }

    .usr-img img{
        width: 100px;
        height: 100px;
    }
</style>

<script>
export default {
    name:'Login',
    data(){
        return {
            usuario:'',
            contra:''
        }
    },
    methods:{
        validarUsuario(){
            if(this.usuario == "capturista"){
                this.$router.push({name:'dash',params:{tipoUsuario:3}})
            }
        }
    }
}
</script>