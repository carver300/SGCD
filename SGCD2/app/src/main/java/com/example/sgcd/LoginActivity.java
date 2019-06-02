package com.example.sgcd;

import android.app.ProgressDialog;
import android.support.design.widget.TextInputLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.widget.EditText;
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

public class LoginActivity extends AppCompatActivity {



    ProgressDialog progress;

    EditText sEmail;
    EditText sPass;
    Toast toast;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        sEmail = findViewById(R.id.editEmail);
        sPass = findViewById(R.id.editPassword);

        progress = new ProgressDialog(LoginActivity.this);
    }



    public void onClick(View view){
        login();
    }

    private void login(){

        progress.setTitle("Cargando");
        progress.setMessage("Espere un momento");
        progress.show();

        Retrofit  retrofit = new Retrofit.Builder()
                .baseUrl("https://SGCD.azurewebsites.net/api/")
                .addConverterFactory(GsonConverterFactory.create())
                .build();
        SGCDAPI sgcd = retrofit.create(SGCDAPI.class);

            Call<Integer> call = sgcd.loginApp(new Usuario(sEmail.getText().toString().trim(),sPass.getText().toString().trim()));


        call.enqueue(new Callback<Integer>() {
            @Override
            public void onResponse(Call<Integer> call, Response<Integer> response) {
                if(response.body().intValue() == 1){

                    progress.dismiss();

                    Intent myIntent = new Intent(getBaseContext(),   MainActivity.class);
                    startActivity(myIntent);

                }
                else{
                   mostrarMensajeToast("Usuario o contrasena invalidos");
                }
            }

            @Override
            public void onFailure(Call<Integer> call, Throwable t) {
                mostrarMensajeToast("Se presento el error "+t.getMessage());
            }
        });
    }

    private void mostrarMensajeToast(String sMensaje){
        toast = Toast.makeText(this,sMensaje,Toast.LENGTH_LONG);
        toast.setGravity(Gravity.TOP,0,0);
        toast.show();
    }

}
