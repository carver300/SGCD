package com.example.sgcd.Interface;
import com.example.sgcd.Model.Paciente;
import com.example.sgcd.Model.Post;
import java.util.List;
import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Body;
import com.example.sgcd.Model.Usuario;

public interface SGCDAPI {

    @GET("Servicio/VerServicios")
    Call<List<Post>> getPost();

    @POST("Usuario/IniciarSesionAPP")
    Call<Integer> loginApp(@Body Usuario user);

    @POST("Paciente/InsertarPaciente")
    Call<Integer> registrarPaciente(@Body Paciente paciente);
}
