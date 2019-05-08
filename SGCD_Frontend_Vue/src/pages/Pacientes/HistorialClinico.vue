<template>
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-xl-12">
                    <card>
                        <div class="row">
                            <div class="col-xl-2">
                                <card>
                                    <div slot="header">
                                        <h3>Buscar Paciente</h3>
                                    </div>
                                    <div class="row">
                                        <div class="col-xl-12">
                                            <base-input
                                                label="Paciente"
                                                >
                                            </base-input>
                                            <button class="btn btn-fill btn-info">
                                                Buscar
                                            </button>
                                        </div>
                                    </div>
                                    <div slot="footer">

                                    </div>
                                </card>
                            </div>
                            <div class="col-xl-10">
                                <card>
                                    <div slot="header">
                                        <h3>Informacion Paciente</h3>
                                    </div>
                                    <div class="row">
                                        <div class="col-xl-3">
                                            <base-input
                                                label="Nombre">
                                            </base-input>
                                        </div>
                                        <div class="col-xl-3">
                                            <base-input
                                                label="Apellido Paterno">
                                            </base-input>
                                        </div>
                                        <div class="col-xl-3">
                                            <base-input
                                                label="Apellido Materno">
                                            </base-input>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xl-3">
                                            <base-input
                                                label="Sexo">
                                            </base-input>
                                        </div>
                                        <div class="col-xl-2">
                                            <base-input
                                                label="Edad">
                                            </base-input>
                                        </div>
                                    </div>
                                </card>
                            </div>
                        </div>
                    </card>
                </div>
            </div>
        </div>
    </div>
</template>
