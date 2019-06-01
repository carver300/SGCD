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

public class LoginActivity extends AppCompatActivity {


    private TextInputLayout textUsuario;
    private TextInputLayout textContra;
    Toast toast;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        textUsuario = findViewById(R.id.textInputEmail);
        textContra = findViewById(R.id.textInputPassword);
        //getPosts();
    }

    private boolean validacionEmail(){
        String sEmail = textUsuario.getEditText().getText().toString().trim();

        if(sEmail.isEmpty()){
            textUsuario.setError("Correo no puede ser vacio");
            return false;
        }
        else{
            textUsuario.setError(null);
            return true;
        }
    }

    public boolean validacionPassword(){
        String sPassword = textContra.getEditText().getText().toString().trim();

        if(sPassword.isEmpty()){
            textContra.setError("Password no puede estar varcio");
            return false;
        }
        else if(sPassword.length() < 1){
            textContra.setError("Contrasena no cumple con la longitud requerida");
            return false;
        }
        else{
            textContra.setError(null);
            return true;
        }
    }

    public boolean validacionDatosLogin(){
        if(!validacionEmail() | !validacionPassword()){
            return false;
        }
        else {
            return true;
        }

    }

    public void onClick(View view){
        if(validacionDatosLogin()){
            login();
        }
        else{
            toast = Toast.makeText(this,"Favor de validar los datos proporcionados",Toast.LENGTH_LONG);
            toast.setGravity(Gravity.TOP,0,0);
            toast.show();
        }

    }

    private void login(){
        Retrofit  retrofit = new Retrofit.Builder()
                .baseUrl("https://SGCD.azurewebsites.net/api/")
                .addConverterFactory(GsonConverterFactory.create())
                .build();
        SGCDAPI sgcd = retrofit.create(SGCDAPI.class);

            Call<Integer> call = sgcd.loginApp(new Usuario(textUsuario.getEditText().getText().toString(),textContra.getEditText().getText().toString()));

        call.enqueue(new Callback<Integer>() {
            @Override
            public void onResponse(Call<Integer> call, Response<Integer> response) {
                if(response.body().intValue() == 1){


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
