package com.example.sgcd;


import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class RetrofitClient {

    private static final String BASE_URL = "http://192.168.0.24/api/usuario/Login";
    private static RetrofitClient mIntance;
    private Retrofit retrofit;

    private RetrofitClient(){
        retrofit = new Retrofit.Builder()
                .baseUrl(BASE_URL)
                .addConverterFactory(GsonConverterFactory.create())
                .build();
    }

    public static synchronized RetrofitClient getInstance(){
        if (mIntance == null){
            mIntance = new RetrofitClient();
        }
        return mIntance;
    }

    public ApiCall getApi(){
        return retrofit.create(ApiCall.class);
    }
}
