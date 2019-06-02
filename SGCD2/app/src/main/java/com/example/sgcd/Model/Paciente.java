package com.example.sgcd.Model;

public class Paciente {

    private int id_paciente;

    private String nombre;

    private String apepaterno;

    private String apematerno;

    private String sexo;

    private String edad;

    private String calle;

    public int getId_paciente() {
        return id_paciente;
    }

    public void setId_paciente(int id_paciente) {
        this.id_paciente = id_paciente;
    }

    private String colonia;

    private String codigopostal;

    private String telefono;

    private String correo;

    private String alergia;

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getApepaterno() {
        return apepaterno;
    }

    public void setApepaterno(String apepaterno) {
        this.apepaterno = apepaterno;
    }

    public String getApematerno() {
        return apematerno;
    }

    public void setApematerno(String apematerno) {
        this.apematerno = apematerno;
    }

    public String getSexo() {
        return sexo;
    }

    public void setSexo(String sexo) {
        this.sexo = sexo;
    }

    public String getEdad() {
        return edad;
    }

    public void setEdad(String edad) {
        this.edad = edad;
    }

    public String getCalle() {
        return calle;
    }

    public void setCalle(String calle) {
        this.calle = calle;
    }

    public String getColonia() {
        return colonia;
    }

    public void setColonia(String colonia) {
        this.colonia = colonia;
    }

    public String getCodigopostal() {
        return codigopostal;
    }

    public void setCodigopostal(String codigopostal) {
        this.codigopostal = codigopostal;
    }

    public String getTelefono() {
        return telefono;
    }

    public void setTelefono(String telefono) {
        this.telefono = telefono;
    }

    public String getCorreo() {
        return correo;
    }

    public void setCorreo(String correo) {
        this.correo = correo;
    }

    public String getAlergia() {
        return alergia;
    }

    public void setAlergia(String alergia) {
        this.alergia = alergia;
    }

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
