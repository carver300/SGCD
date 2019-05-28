package com.example.sgcd.Interface;
import com.example.sgcd.Model.Post;
import java.util.List;
import retrofit2.Call;
import retrofit2.http.GET;

public interface SGCDAPI {

    @GET("Servicio/VerServicios")
    Call<List<Post>> getPost();
}
