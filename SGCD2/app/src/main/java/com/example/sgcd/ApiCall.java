package com.example.sgcd;


import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.http.Field;
import retrofit2.http.FormUrlEncoded;
import retrofit2.http.POST;

public interface ApiCall {

    @FormUrlEncoded
    @POST("Login")
    Call<ResponseBody> Login(
            @Field("usuario") String usuario,
            @Field("contra") String contra
    );
}
