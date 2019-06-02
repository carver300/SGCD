package com.example.sgcd;

import android.support.design.widget.TextInputLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Gravity;
import android.widget.Toast;
import android.view.View;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import com.example.sgcd.Interface.SGCDAPI;
import com.example.sgcd.Model.Paciente;

public class RegistroPacienteActivity extends AppCompatActivity {


    TextInputLayout txtNombre;
    TextInputLayout txtApepaterno;
    TextInputLayout txtApematerno;
    Toast toast;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registro_paciente);

        txtNombre = findViewById(R.id.textInputNombre);
        txtApepaterno = findViewById(R.id.textInputApepaterno);
        txtApematerno = findViewById(R.id.textInputApematerno);
    }



    public void onClickRegistrar(View view){

    }
}
