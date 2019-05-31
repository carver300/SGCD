<template>
  <div class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-xl-3">
          <div class="card">
            <div class="card-header">
              <div class="row pt-2">
                <div class="col-xl-12">
                  <h3 class="card-title">Atencion de cita</h3>
                  <p class="card-category">Ingrese el folio de la cita para cargar los datos</p>
                  <hr>
                </div>
              </div>
              <div class="row">
                <div class="col-xl-5">
                  <base-input label="Cita" placeholder="Folio cita"></base-input>
                </div>
              </div>
              <div class="row">
                <div class="col-xl-4">
                  <button class="btn btn-fill btn-info">Buscar</button>
                </div>
              </div>
            </div>
            <div class="card-body"></div>
          </div>
        </div>
        <div class="col-xl-9">
          <div class="card">
            <div class="card-header">
              <h3 class="card-title">Informacion del paciente</h3>
              <p class="card-category">Informacion general del paciente</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>