package com.example.sgcd;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.design.widget.TextInputLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;
import android.widget.TextView;
import android.content.Intent;

import java.io.IOException;

import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import com.example.sgcd.Model.Post;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.List;

import com.example.sgcd.Interface.SGCDAPI;
import com.example.sgcd.Model.Paciente;

public class VerPacientesActivity extends AppCompatActivity {



    List<Paciente> postList2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_ver_pacientes);

        getPosts();

    }



    private void getPosts(){



        Retrofit  retrofit = new Retrofit.Builder()
                .baseUrl("https://SGCD.azurewebsites.net/api/")
                .addConverterFactory(GsonConverterFactory.create())
                .build();

        SGCDAPI sgcd= retrofit.create(SGCDAPI.class);

        Call<List<Paciente>> call = sgcd.getPost();

        call.enqueue(new Callback<List<Paciente>>() {
            @Override
            public void onResponse(Call<List<Paciente>> call, Response<List<Paciente>> response) {
                if(!response.isSuccessful()){

                }

                List<Paciente> postList = response.body();


            }

            @Override
            public void onFailure(Call<List<Paciente>> call, Throwable t) {

            }
        });
    }
}
