<template>
  <div class="modal-dialog text-center">
    <div class="col-xl-8 main-section">
      <div class="modal-content">
        <div class="col-12 usr-img">
          <img src="@/assets/img/avatar.png" alt="avatar">
        </div>
        <form class="col-12">
          <div class="form-group">
            <h6 class="text-left">Correo</h6>
            <input type="text" class="form-control" placeholder="Correo" v-model="User.usuario">
          </div>
          <div class="form-group">
            <h6 class="text-left">Contraseña</h6>
            <input
              type="password"
              class="form-control"
              placeholder="Contraseña"
              v-model="User.contra"
            >
          </div>
          <button
            type="submit"
            class="btn btn-block btn-fill btn-primary btn-rounded mb-2"
            @click="validarUsuario()"
          >Ingresar</button>
          <div class="form-group">
            <small class="text-primary">¿Olvidaste tu contraseña?</small>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<style>
.btn-rounded {
  border-radius: 20px;
}

.main-section {
  margin: 0 auto;
  margin-top: 25%;
  padding: 0;
}

.modal-content {
  background-color: #ffffff;
  box-shadow: 0px 0px 3px #848484;
  opacity: 0.9;
  padding: 0 2px;
}
.usr-img {
  margin-top: -50px;
  margin-bottom: 35px;
}

.usr-img img {
  width: 100px;
  height: 100px;
}
</style>

<script>
const axios = require("axios");

export default {
  name: "Login",
  data() {
    return {
      User: {
        usuario: "",
        contra: ""
      }
    };
  },
  methods: {
    validarUsuario() {
      axios
        .post("http://178.128.13.15:8001/api/usuario/IniciarSesion", this.User)
        .then(response => {
          if (response.data != -1) {
            localStorage.setItem("tipoUsuario", response.data);
            this.avanzarPaginaPrincipal();
          } else {
            this.notifyVue("top", "center", "Usuario o cantraseña incorrectos", "warning");
          }
        })
        .catch(error => {
          this.notifyVue(
            "top",
            "center",
            "Hubo un problema al guardar la informacion, favor de validar",
            "danger"
          );
        });
    },
    avanzarPaginaPrincipal() {
      this.$router.push("SGCD");
    },

    notifyVue (verticalAlign, horizontalAlign,mensaje,color) {
            this.$notifications.notify(
            {
                message: mensaje,
                icon: 'nc-icon nc-app',
                horizontalAlign: horizontalAlign,
                verticalAlign: verticalAlign,
                type: color
            })
        },
  }
};
</script>