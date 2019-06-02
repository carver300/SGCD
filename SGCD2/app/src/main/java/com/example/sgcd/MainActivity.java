package com.example.sgcd;

import android.support.design.widget.TextInputLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
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
import java.util.List;

import com.example.sgcd.Interface.SGCDAPI;
import com.example.sgcd.Model.Usuario;

public class MainActivity extends AppCompatActivity {



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

    }

    public void onClickRegistro(View view){
        Intent myIntent = new Intent(getBaseContext(),   RegistroPacienteActivity.class);
        startActivity(myIntent);
    }

    public void onClickVerPacientes(View view){
        Intent myIntent = new Intent(getBaseContext(),   VerPacientesActivity.class);
        startActivity(myIntent);
    }
}
