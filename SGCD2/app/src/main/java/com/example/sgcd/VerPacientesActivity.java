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

import java.util.ArrayList;
import java.util.List;

import com.example.sgcd.Interface.SGCDAPI;
import com.example.sgcd.Model.Paciente;

public class VerPacientesActivity extends AppCompatActivity {


    TextView jsonText;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_ver_pacientes);

        jsonText = findViewById(R.id.jsontext);

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
                    jsonText.setText("Codigo: "+response.code());
                }

                List<Paciente> postList = response.body();

                for(Paciente post: postList){
                    String content = "";
                    content += "ID Paciente"+ post.getId_paciente() +"\n";
                    content += "Nombre"+ post.getNombre()+"\n";
                    content += "ApePaterno"+ post.getApepaterno()+"\n";
                    content += "ApeMaterno"+ post.getApematerno()+"\n";
                    content += "Edad"+ post.getEdad()+"\n";
                    content += "Alergia"+ post.getAlergia()+"\n";
                    content += "Calle"+ post.getCalle()+"\n";
                    content += "Colonia"+ post.getColonia()+"\n";
                    content += "CodPOstal"+ post.getCodigopostal()+"\n";
                    content += "Telefono"+ post.getTelefono()+"\n";
                    content += "Correo"+ post.getCorreo()+"\n";

                    jsonText.append(content);
                }
            }

            @Override
            public void onFailure(Call<List<Paciente>> call, Throwable t) {
                jsonText.setText(t.getMessage());
            }
        });
    }
}
