package com.example.sgcd.Interface;
import com.example.sgcd.Model.Paciente;
import com.example.sgcd.Model.Post;
import java.util.List;
import retrofit2.Call;
import retrofit2.http.Field;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Body;
import retrofit2.http.Path;
import retrofit2.http.Query;

import com.example.sgcd.Model.Usuario;

public interface SGCDAPI {

    @GET("Paciente/VerPacientes")
    Call<List<Paciente>> getPost();

    @GET("Paciente/PacientePorId/{id}")
    Call<Paciente> getPaciente(@Path("id") int id_paciente);


    @POST("Usuario/IniciarSesionAPP")
    Call<Integer> loginApp(@Body Usuario user);

    @POST("Paciente/InsertarPaciente")
    Call<Integer> registrarPaciente(@Body Paciente paciente);
}
