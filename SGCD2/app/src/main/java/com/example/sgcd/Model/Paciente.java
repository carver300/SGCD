package com.example.sgcd.Model;

public class Paciente {


    private String nombre;

    private String apepaterno;

    private String apematerno;

    private String sexo;

    private String edad;

    private String calle;

    private String colonia;

    private String codigopostal;

    private String telefono;

    private String correo;

    private String alergia;




    public Paciente(String nombre, String apepaterno, String apematerno, String sexo, String edad, String calle, String colonia, String codigopostal, String telefono, String correo, String alergia) {
        this.nombre = nombre;
        this.apepaterno = apepaterno;
        this.apematerno = apematerno;
        this.sexo = sexo;
        this.edad = edad;
        this.calle = calle;
        this.colonia = colonia;
        this.codigopostal = codigopostal;
        this.telefono = telefono;
        this.correo = correo;
        this.alergia = alergia;
    }
}
